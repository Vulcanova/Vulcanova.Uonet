using System;

namespace Vulcanova.Uonet.Api.Grades
{
    public record GetBehaviourGradesByPupilQuery(
        int UnitId,
        int PupilId,
        int PeriodId,
        DateTime LastSyncDate,
        int PageSize,
        int LastId = int.MinValue) : IPaginatedApiQuery<GradePayload>
    {
        public IPaginatedApiQuery<GradePayload> NextPage(int lastId)
            => this with {LastId = lastId};

        public const string ApiEndpoint = "mobile/grade/behaviour/byPupil";
    }
}