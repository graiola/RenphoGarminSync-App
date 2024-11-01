using RenphoGarminSync.Renpho.Shared.Models;
using System;

namespace RenphoGarminSync.Renpho.Shared.Exceptions
{
    public class RenphoException : Exception
    {
        public RenphoStatusCode StatusCode { get; }

        public RenphoException(RenphoStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
