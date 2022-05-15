using System;

namespace Vulcanova.Uonet.Api
{
    public class VulcanException : Exception
    {
        public int StatusCode { get; }

        public VulcanException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}