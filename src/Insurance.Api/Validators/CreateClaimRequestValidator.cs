using System;
using FluentValidation;
using Insurance.Api.Helpers;
using Insurance.Models.Claim;

namespace Insurance.Api.Validators
{
    public class CreateClaimRequestValidator : AbstractValidator<CreateClaimRequest>, ICreateClaimRequestValidator
    {
        public CreateClaimRequestValidator()
        {
            RuleFor(x => x.PolicyNumber)
                .Must(x => x > 0)
                .WithMessage("Please specify a PolicyNumber");

            RuleFor(x => x.InsuredId)
                .Must(x => x != Guid.Empty)
                .WithMessage("Please specify an InsuredId");

            RuleFor(x => x.CoverCause)
                .Must(x => !x.IsNullEmptyOrWhiteSpace())
                .WithMessage("Please specify a CoverCause");

            RuleFor(x => x.IncidentDate)
                .Must(x => x != null)
                .WithMessage("Please specify an IncidentDate");
        }
    }
}