using System.Net.Http;
using Insurance.Models.Policy;

namespace Insurance.Api.RequestHandlers
{
    public interface IPolicyRequestHandler
    {
        HttpResponseMessage GetPolicy(SearchPolicyRequest request);
    }
}