using System;

namespace Vulcanova.Uonet.Api.LuckyNumber
{
    public record GetLuckyNumberQuery(long ConstituentId, DateTime Day) : IApiQuery<LuckyNumberPayload>
    {
        public const string ApiEndpoint = "mobile/school/lucky";
    }
}