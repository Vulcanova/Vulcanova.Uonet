using System;

namespace Vulcanova.Uonet.Api.MessageBox
{
    public record ChangeMessageStatusRequest(
        Guid BoxKey, 
        Guid MessageKey,
        ChangeMessageStatusRequest.SetMessageStatus Status) : IApiRequest<bool>
    {
        public enum SetMessageStatus
        {
            Read = 1
        }

        public const string ApiEndpoint = "mobile/messagebox/message/status";
    }
}