using System;

namespace Vulcanova.Uonet.Api
{
    public class UnexpectedApiResponseException : Exception
    {
        public string Content { get; }

        public UnexpectedApiResponseException(string content) : base("Unexpected API response")
        {
            Content = content;
        }
    }
}