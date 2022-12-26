using System;
using System.Collections.Generic;
using Vulcanova.Uonet.Api.Common.Models;

namespace Vulcanova.Uonet.Api.Homework
{
    public class HomeworkPayload : IPaginatedResource
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
        public int IdPupil { get; set; }
        public int IdHomework { get; set; }
        public string Content { get; set; }
        public bool IsAnswerRequired { get; set; }
        public DateTimeInfo DateCreated { get; set; }
        public DateTimeInfo Date { get; set; }
        public DateTimeInfo Deadline { get; set; }
        public DateTimeInfo AnswerDate { get; set; }
        public DateTimeInfo AnswerDeadline { get; set; }
        public Teacher Creator { get; set; }
        public Subject Subject { get; set; }
        public List<object> Attachments { get; set; }
    }
}