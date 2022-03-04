using System.Net;

namespace Insurance.Api.Exceptions
{
    public class InternalServerErrorException : HttpException
    {
        public InternalServerErrorException(string message) : base(message, HttpStatusCode.InternalServerError)
        {
        }
    }
}
