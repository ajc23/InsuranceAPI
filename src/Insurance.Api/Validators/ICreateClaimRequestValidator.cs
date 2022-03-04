using FluentValidation;
using Insurance.Models.Claim;

namespace Insurance.Api.Validators
{
    public interface ICreateClaimRequestValidator : IValidator<CreateClaimRequest>
    {
    }
}