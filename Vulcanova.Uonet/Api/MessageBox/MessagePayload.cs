using System;
using System.Collections.Generic;
using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.MessageBox
{
    public class MessagePayload
    {
        public Guid Id { get; set; }
        public Guid GlobalKey { get; set; }
        public Guid ThreadKey { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTimeInfo DateSent { get; set; }
        public DateTimeInfo DateRead { get; set; }
        // TODO: What does this value mean?
        public int Status { get; set; }
        public Correspondent Sender { get; set; }
        public List<Correspondent> Receiver { get; set; }
        public List<Attachment> Attachments { get; set; }
        // TODO: What is the max importance value? What do these values mean?
        public int Importance { get; set; }
    }

    public class Attachment
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class Extras
    {
        public string DisplayedClass { get; set; }
    }

    public class Correspondent
    {
        public Guid GlobalKey { get; set; }
        public string Name { get; set; }
        public int? HasRead { get; set; }
        public Extras Extras { get; set; }
    }
}