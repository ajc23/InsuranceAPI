using System.Net;
using System.Net.Http;
using FluentValidation;
using Insurance.Api.Helpers;
using Insurance.Models.Claim;
using Insurance.Service;
using ValidationException = Insurance.Api.Exceptions.ValidationException;

namespace Insurance.Api.RequestHandlers
{
    public class ClaimRequestHandler : IClaimRequestHandler
    {
        private IClaimService service;
        private IValidatorFactory validatorFactory { get; }

        public ClaimRequestHandler(IClaimService service, IValidatorFactory validatorFactory)
        {
            this.service = service;
            this.validatorFactory = validatorFactory;
        }
        
        public HttpResponseMessage GetClaim(SearchClaimRequest request)
        {
            var validator = validatorFactory.GetValidator<SearchClaimRequest>();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var response = service.GetClaim(request);

                if (response != null)
                {
                    return response.AsHttpResponseMessage(HttpStatusCode.OK);
                }
                return response.AsHttpResponseMessage(HttpStatusCode.NotFound);
            }

            throw new ValidationException(validationResult);            
        }

        public HttpResponseMessage SubmitClaim(CreateClaimRequest request)
        {
            var validator = validatorFactory.GetValidator<CreateClaimRequest>();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var response = service.SubmitClaim(request);

                if (response != null)
                {
                    return response.AsHttpResponseMessage(HttpStatusCode.Created);
                }
                return response.AsHttpResponseMessage(HttpStatusCode.NotFound);
            }

            throw new ValidationException(validationResult);
        }
    }
}