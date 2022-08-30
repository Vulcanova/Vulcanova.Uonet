using System;

namespace Vulcanova.Uonet.Api.Notes
{
    public record GetNotesByPupilQuery(
        int PupilId,
        DateTime LastSyncDate,
        int LastId = int.MinValue,
        int PageSize = 500) : IPaginatedApiQuery<NotesPayload>
    {
        public const string ApiEndpoint = "mobile/note/byPupil";

        public IPaginatedApiQuery<NotesPayload> NextPage(int lastId)
        {
            return this with { LastId = lastId };
        }
    }
}