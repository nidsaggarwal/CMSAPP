using System;
using System.Collections.Generic; 
using Domain.SeedWork;

namespace Domain.Aggregates.Posts
{
    public partial class Quiz : AggregateRoot<Guid>
    {

        public const short MAX_TITLE_LENGTH = 500;


        private Quiz   (string fileName)
        {
            FileName = fileName;
        }

        private Quiz(string content, string title, bool isContentFirst, string tags, string fileName)
        {
            Content             = content;
            Title               = title;  
            IsContentFirst      = isContentFirst;
            Tags                = tags;
            FileName            = fileName;
        }


        public string               Content             { get; private set; }

        public string               Title               { get; private set; }

        public bool                 IsContentFirst      { get; private set; }

        public string               Tags                { get; private set; }

        public string               FileName            { get; private set; }
    }
}
