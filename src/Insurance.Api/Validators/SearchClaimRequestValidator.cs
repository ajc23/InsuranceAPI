using FluentValidation;
using Insurance.Models.Claim;

namespace Insurance.Api.Validators
{
    public class SearchClaimRequestValidator : AbstractValidator<SearchClaimRequest>, ISearchClaimRequestValidator
    {
        public SearchClaimRequestValidator()
        {
            RuleFor(x => x.ClaimNumber)
                .Must(x => x > 0)
                .WithMessage("Please specify a ClaimNumber");
        }
    }
}