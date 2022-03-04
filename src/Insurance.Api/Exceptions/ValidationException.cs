using System.Net;
using FluentValidation.Results;

namespace Insurance.Api.Exceptions
{
    public class ValidationException : HttpException
    {
        public ValidationException(ValidationResult validationResult) : base("Error occurred validating entity", (HttpStatusCode)422)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; set; }
    }
}
