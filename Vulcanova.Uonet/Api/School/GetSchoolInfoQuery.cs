using System;

namespace Vulcanova.Uonet.Api.School
{
    public record GetSchoolInfoQuery(
        int LoginId,
        DateTime LastSyncDate) : IApiQuery<object>
    {
        public const string ApiEndpoint = "mobile/school/info";
    }
}