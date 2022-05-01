using System;

namespace Vulcanova.Uonet.Api.Homework
{
    public record GetHomeworkByPupilQuery(
        int PupilId,
        int PeriodId,
        DateTime LastSyncDate,
        int LastId = int.MinValue,
        int PageSize = 500): IApiQuery<HomeworkPayload[]>
    {
        public const string ApiEndpoint = "mobile/homework/byPupil";
    }
} 