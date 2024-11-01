using RenphoGarminSync.Garmin.Shared.Models;
using System;

namespace RenphoGarminSync.Garmin.Shared.Exceptions
{
    public class GarminException : Exception
    {
        public GarminStatusCode StatusCode { get; }

        public GarminException(GarminStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
