using System;

namespace Insurance.Models.Policy
{
    public class SearchPolicyRequest
    {
        public int PolicyNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
