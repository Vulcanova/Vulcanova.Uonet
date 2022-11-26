using System;

namespace Vulcanova.Uonet.Api.MessageBox
{
    public class MessageBoxPayload
    {
        public int Id { get; set; }
        public Guid GlobalKey { get; set; }
        public string Name { get; set; }
    }
}