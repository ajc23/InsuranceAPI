using System;

namespace Insurance.Api.Exceptions
{
    public class BadDataException : Exception
    {
        public BadDataException(string message) : base(message)
        {
        }
    }
}