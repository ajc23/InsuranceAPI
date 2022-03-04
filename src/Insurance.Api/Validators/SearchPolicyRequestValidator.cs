using FluentValidation;
using Insurance.Models.Policy;

namespace Insurance.Api.Validators
{
    public class SearchPolicyRequestValidator : AbstractValidator<SearchPolicyRequest>, ISearchPolicyRequestValidator
    {
        public SearchPolicyRequestValidator()
        {
            RuleFor(x => x.PolicyNumber)
                .Must(x => x > 0)
                .WithMessage("Please specify a PolicyNumber");

            RuleFor(x => x.DateOfBirth)
                .Must(x => x != null)
                .WithMessage("Please specify a DateOfBirth");
        }
    }
}