using System.Net;

namespace Insurance.Api.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(int policyNumber) : base($"Unable to find policyNumber {policyNumber}", HttpStatusCode.NotFound)
        {
        }

        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
