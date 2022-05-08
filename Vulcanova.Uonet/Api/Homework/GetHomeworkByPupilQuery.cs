using System;

namespace Vulcanova.Uonet.Api.Homework
{
    public record GetHomeworkByPupilQuery(
        int PupilId,
        int PeriodId,
        DateTime LastSyncDate,
        int LastId = int.MinValue,
        int PageSize = 500): IPaginatedApiQuery<HomeworkPayload>
    {
        public IPaginatedApiQuery<HomeworkPayload> NextPage(int lastId)
            => this with {LastId = lastId};

        public const string ApiEndpoint = "mobile/homework/byPupil";
    }
} 