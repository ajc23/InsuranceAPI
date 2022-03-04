using FluentValidation;
using Insurance.Models.Claim;

namespace Insurance.Api.Validators
{
    public interface ISearchClaimRequestValidator : IValidator<SearchClaimRequest>
    {
    }
}