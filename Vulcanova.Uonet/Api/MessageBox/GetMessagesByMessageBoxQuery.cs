using System;

namespace Vulcanova.Uonet.Api.MessageBox
{
    // This query appears to be supporting pagination,
    // but the type of the response (`MessagePayload`) entity's ID is `Guid`
    // while the query expects the type of `LastId` param to be `int`.
    // How do I convert a Guid to an integer? ¯\_(ツ)_/¯
    public record GetMessagesByMessageBoxQuery(
        Guid Box,
        MessageBoxFolder Folder,
        DateTime LastSyncDate,
        int LastId = int.MinValue,
        int PageSize = 500) : IApiQuery<MessagePayload[]>
    {
        public const string ApiEndpoint = "mobile/messagebox/message/byBox";
    }

    public enum MessageBoxFolder
    {
        Received = 1,
        Sent,
        Deleted
    }
}