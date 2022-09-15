namespace Vulcanova.Uonet.Api.Presence
{
    public record JustifyLessonResponse
    {
        public string Reason { get; set; }
        public int LessonClassId { get; set; }
        public int PupilId { get; set; }
        public int LoginId { get; set; }
    }
}