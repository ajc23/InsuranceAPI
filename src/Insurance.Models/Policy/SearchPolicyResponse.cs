using System;
using System.Collections.Generic;

namespace Insurance.Models.Policy
{
    public class SearchPolicyResponse
    {
        public int PolicyNumber { get; set; }

        public List<Insured> Insured { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
