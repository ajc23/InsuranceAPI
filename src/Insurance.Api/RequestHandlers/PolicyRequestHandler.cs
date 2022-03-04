using System.Net;
using System.Net.Http;
using FluentValidation;
using Insurance.Api.Helpers;
using Insurance.Models.Policy;
using Insurance.Service;
using ValidationException = Insurance.Api.Exceptions.ValidationException;

namespace Insurance.Api.RequestHandlers
{
    public class PolicyRequestHandler : IPolicyRequestHandler
    {
        private IPolicyService service;
        private IValidatorFactory validatorFactory;

        public PolicyRequestHandler(IPolicyService service, IValidatorFactory validatorFactory)
        {
            this.service = service;
            this.validatorFactory = validatorFactory;
        }

        public HttpResponseMessage GetPolicy(SearchPolicyRequest request)
        {
            var validator = validatorFactory.GetValidator<SearchPolicyRequest>();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var response = service.FindPolicy(request);
                if (response != null)
                {
                    return response.AsHttpResponseMessage(HttpStatusCode.OK);
                }
                return response.AsHttpResponseMessage(HttpStatusCode.NotFound);
            }

            throw new ValidationException(validationResult);
        }
    }
}