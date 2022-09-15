namespace Vulcanova.Uonet.Api.Presence
{
    public record JustifyLessonRequest(
        string Reason,
        int LessonClassId,
        int PupilId,
        int UnitId) : IApiRequest<JustifyLessonResponse>
    {
        public const string ApiEndpoint = "api/mobile/presence/justification/lesson";
    }
}