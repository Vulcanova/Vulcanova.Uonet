using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.Info
{
    public class SchoolInfoEntryPayload
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public DateTimeInfo DateCreated { get; set; }
        public DateTimeInfo Date { get; set; }
        public int Availability { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
    }
}