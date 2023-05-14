using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Vulcanova.Uonet.Signing;

namespace Vulcanova.Uonet.Api
{
    public class ApiClient : IApiClient
    {
        private readonly IRequestSigner _requestSigner;
        private readonly string _apiInstanceUrl;

        public ApiClient(IRequestSigner requestSigner, string apiInstanceUrl)
        {
            _requestSigner = requestSigner;
            _apiInstanceUrl = apiInstanceUrl;
        }

        public async Task<ApiResponse<TResponse>> GetAsync<TResponse>(string url, IApiQuery<TResponse> query)
        {
            url = GetFullRequestUrl(url) + query.ToQueryString();

            var headers = await _requestSigner.CreateSignedHeaders(url);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            
            foreach (var (key, value) in headers)
            {
                requestMessage.Headers.TryAddWithoutValidation(key, value);
            }

            return await SendMessageAsync<TResponse>(requestMessage);
        }

        public async Task<ApiResponse<TResponse>> PostAsync<TResponse>(string url, IApiRequest<TResponse> request)
        {
            url = GetFullRequestUrl(url);
            
            var signed = await _requestSigner.SignPayload(request);
            var json = JsonSerializer.Serialize((object) signed);

            var headers = await _requestSigner.CreateSignedHeaders(json, url);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = signed.ToJsonStringContent()
            };

            foreach (var (key, value) in headers)
            {
                requestMessage.Headers.TryAddWithoutValidation(key, value);
            }

            var result = await SendMessageAsync<TResponse>(requestMessage);

            return result;
        }

        private string GetFullRequestUrl(string relativeUrl) => _apiInstanceUrl + "/" + relativeUrl;

        private static async Task<ApiResponse<TResponse>> SendMessageAsync<TResponse>(HttpRequestMessage requestMessage)
        {
            var responseMessage = await Config.HttpClient.SendAsync(requestMessage);
            var content = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.Content.Headers.ContentType is { MediaType: "text/html" } or null)
            {
                if (content.Contains("<title>Przerwa techniczna</title>"))
                {
                    throw new MaintenanceBreakException(content);
                }

                throw new UnexpectedApiResponseException(content);
            }

            var result = JsonSerializer.Deserialize<ApiResponse<TResponse>>(content);

            if (result!.Status.Code != 0)
            {
                throw new VulcanException(result.Status.Code, result.Status.Message);
            }

            return result;
        }
    }
}