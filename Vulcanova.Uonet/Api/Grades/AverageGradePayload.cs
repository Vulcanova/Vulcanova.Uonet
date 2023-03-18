using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.Grades
{
    public class AverageGradePayload : IPaginatedResource
    {
        public int Id { get; set; }
        public int PeriodId { get; set; }
        public int PupilId { get; set; }
        public Subject Subject { get; set; }
        public string Average { get; set; }
        public object Points { get; set; }
    }
}