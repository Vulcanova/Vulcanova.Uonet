using System;

namespace Vulcanova.Uonet.Api.Exams
{
    public record GetExamsByPupilQuery(
        int UnitId,
        int PupilId,
        DateTime LastSyncDate,
        int PageSize,
        int LastId = int.MinValue) : IPaginatedApiQuery<ExamPayload>
    {
        public IPaginatedApiQuery<ExamPayload> NextPage(int lastId)
            => this with {LastId = lastId};

        public const string ApiEndpoint = "mobile/exam/byPupil";
    }
}