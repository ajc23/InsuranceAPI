using System.Net.Http;
using Insurance.Models.Claim;

namespace Insurance.Api.RequestHandlers
{
    public interface IClaimRequestHandler
    {
        HttpResponseMessage GetClaim(SearchClaimRequest request);

        HttpResponseMessage SubmitClaim(CreateClaimRequest request);
    }
}