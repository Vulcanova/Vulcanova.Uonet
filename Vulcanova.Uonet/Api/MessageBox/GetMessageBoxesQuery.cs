namespace Vulcanova.Uonet.Api.MessageBox
{
    public record GetMessageBoxesQuery : IApiQuery<MessageBoxPayload[]>
    {
        public const string ApiEndpoint = "mobile/messagebox";
    }
}