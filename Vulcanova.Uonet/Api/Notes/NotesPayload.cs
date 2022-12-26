using System;
using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.Notes
{
    public class NotesPayload : IPaginatedResource
    {
        public int Id { get; }
        public Guid Key { get; set; }
        public int IdPupil { get; set; }
        public bool Positive { get; set; }
        public DateTimeInfo DateValid { get; set; }
        public DateTimeInfo DateModify { get; set; }
        public Teacher Creator { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public object Points { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Type { get; set; }
        public object DefaultPoints { get; set; }
    }
}