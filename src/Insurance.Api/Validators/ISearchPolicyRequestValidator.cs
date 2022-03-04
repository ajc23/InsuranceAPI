using FluentValidation;
using Insurance.Models.Policy;

namespace Insurance.Api.Validators
{
    public interface ISearchPolicyRequestValidator : IValidator<SearchPolicyRequest>
    {
    }
}