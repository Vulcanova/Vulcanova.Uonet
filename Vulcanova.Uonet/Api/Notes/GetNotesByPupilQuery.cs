using System;

namespace Vulcanova.Uonet.Api.Notes
{
    public record GetNotesByPupilQuery(
        int PupilId,
        DateTime LastSyncDate,
        int LastId = int.MinValue,
        int PageSize = 500) : IPaginatedApiQuery<NotesPayload>
    {
        public IPaginatedApiQuery<NotesPayload> NextPage(int lastId)
            => this with { LastId = lastId };

        public const string ApiEndpoint = "mobile/note/byPupil";
        
    }
}