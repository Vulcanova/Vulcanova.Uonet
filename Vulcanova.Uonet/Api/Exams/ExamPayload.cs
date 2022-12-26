using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.Exams
{
    public class ExamPayload : IPaginatedResource
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTimeInfo DateCreated { get; set; }
        public DateTimeInfo DateModify { get; set; }
        public DateTimeInfo Deadline { get; set; }
        public Teacher Creator { get; set; }
        public Subject Subject { get; set; }
        public int PupilId { get; set; }
    }
}