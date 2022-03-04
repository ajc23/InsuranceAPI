using System;
using System.Net;

namespace Insurance.Api.Exceptions
{
    public abstract class HttpException: Exception
    {
        public HttpException(string mesage, HttpStatusCode statusCode):base(mesage)
        {
            HttpStatusCode = statusCode;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
