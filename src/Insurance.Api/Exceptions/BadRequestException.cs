using System.Net;

namespace Insurance.Api.Exceptions
{
    public class BadRequestException: HttpException
    {
        public BadRequestException(string message):base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
