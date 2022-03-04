using Insurance.Models.Policy;

namespace Insurance.Service
{
    public interface IPolicyService
    {
        SearchPolicyResponse FindPolicy(SearchPolicyRequest request);
    }
}