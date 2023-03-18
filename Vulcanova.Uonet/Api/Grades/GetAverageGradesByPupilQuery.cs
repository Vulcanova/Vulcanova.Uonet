namespace Vulcanova.Uonet.Api.Grades
{
    public record GetAverageGradesByPupilQuery(
        int UnitId,
        int PupilId,
        int PeriodId,
        int PageSize,
        int LastId = int.MinValue) : IPaginatedApiQuery<AverageGradePayload>
    {
        public IPaginatedApiQuery<AverageGradePayload> NextPage(int lastId)
            => this with {LastId = lastId};

        public const string ApiEndpoint = "mobile/grade/average/byPupil";
    }
}