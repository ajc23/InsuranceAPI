using Insurance.Models.Claim;

namespace Insurance.Service
{
    public interface IClaimService
    {
        SearchClaimResponse GetClaim(SearchClaimRequest request);

        CreateClaimResponse SubmitClaim(CreateClaimRequest request);
    }
}