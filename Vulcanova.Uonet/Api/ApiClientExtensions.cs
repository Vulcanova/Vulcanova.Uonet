using System.Collections.Generic;
using System.Linq;

namespace Vulcanova.Uonet.Api
{
    public static class ApiClientExtensions
    {
        /// <summary>
        /// This extension sends the query and continues to query the API until all pages are read
        /// </summary>
        /// <param name="client"><c>IApiClient</c> implementation</param>
        /// <param name="url">The url to query</param>
        /// <param name="query">The query object</param>
        /// <typeparam name="T">Resource type</typeparam>
        /// <returns>An async enumerable of read pages</returns>
        public static async IAsyncEnumerable<T[]> GetAllPagesAsync<T>(this IApiClient client, string url, IPaginatedApiQuery<T> query) where T : IPaginatedResource
        {
            while (true)
            {
                var response = await client.GetAsync(url, query);
                var data = response.Envelope;

                yield return data;

                if (data.Length < query.PageSize) yield break;

                var newMaxId = data.Max(d => d.Id);

                query = query.NextPage(newMaxId);
            }
        }

        /// <summary>
        /// This extension sends the query and continues to query the API until all pages are read
        /// </summary>
        /// <param name="client"><c>IApiClient</c> implementation</param>
        /// <param name="url">The url to query</param>
        /// <param name="query">The query object</param>
        /// <typeparam name="T">Resource type</typeparam>
        /// <returns>An async enumerable of individual items from read pages</returns>
        public static async IAsyncEnumerable<T> GetAllAsync<T>(this IApiClient client, string url, IPaginatedApiQuery<T> query)
            where T : IPaginatedResource
        {
            await foreach (var page in client.GetAllPagesAsync(url, query))
            {
                foreach (var item in page)
                {
                    yield return item;
                }
            }
        }
    }
}