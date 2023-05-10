using System;
using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.Notes
{
    public class NotesPayload : IPaginatedResource
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public int IdPupil { get; set; }
        public bool Positive { get; set; }
        public DateTimeInfo DateValid { get; set; }
        public DateTimeInfo DateModify { get; set; }
        public Teacher Creator { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public int? Points { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? DefaultPoints { get; set; }
    }
}
