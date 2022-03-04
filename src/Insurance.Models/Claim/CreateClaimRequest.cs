using System;

namespace Insurance.Models.Claim
{
    public class CreateClaimRequest
    {
        public int PolicyNumber { get; set; } 

        public string CoverCause { get; set; }

        public Guid InsuredId { get; set; }

        public DateTime? IncidentDate { get; set; }
    }
}
