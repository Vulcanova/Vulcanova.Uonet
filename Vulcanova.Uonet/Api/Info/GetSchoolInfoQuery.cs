using System;

namespace Vulcanova.Uonet.Api.Info
{
    public record GetSchoolInfoQuery(
        int LoginId,
        DateTime LastSyncDate) : IApiQuery<SchoolInfoEntryPayload[]>
    {
        public const string ApiEndpoint = "mobile/school/info";
    }
}