using System.Collections.Generic;

namespace Insurance.Models.Claim
{
    public class SearchClaimResponse
    {
        public int ClaimNumber { get; set; }

        public string CoverCause { get; set; }

        public List<Insured> Insured { get; set; }

        public string  Status { get; set; }
    }
}
