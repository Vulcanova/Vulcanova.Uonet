using System;
using System.Collections.Generic;
using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.MessageBox
{
    public class SendMessageRequest : IApiRequest<MessagePayload>
    {
        public Guid Id { get; set; }
        public Guid GlobalKey { get; set; }
        public string Partition { get; set; }
        public Guid ThreadKey { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public Guid Owner { get; set; }
        public DateTimeInfo DateSent { get; set; }
        public DateTimeInfo DateRead { get; set; }
        public SendMessageRequestCorrespondent Sender { get; set; }
        public List<SendMessageRequestCorrespondent> Receiver { get; set; }
        public List<Attachment> Attachments { get; set; }

        public const string ApiEndpoint = "mobile/messagebox/message";
    }

    public class SendMessageRequestCorrespondent
    {
        public string Id { get; set; }
        public string Partition { get; set; }
        public Guid Owner { get; set; }
        public Guid GlobalKey { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Initials { get; set; }
        public int HasRead { get; set; }
    }
}