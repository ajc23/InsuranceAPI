using System;
using System.Collections.Generic;
using Insurance.Models;
using Insurance.Models.Claim;
using Insurance.Service.ExtensionMethods;

namespace Insurance.Service
{
    public class ClaimService : IClaimService
    {
        public SearchClaimResponse GetClaim(SearchClaimRequest request)
        {
            var random = new Random(10000);
            var insured = new List<Insured>
            {
                new Insured
                {
                    InsuredId = Guid.NewGuid(),
                    Title = Title.Mr,
                    FirstName = "Joe",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Today.AddYears(-34).AddDays(-25)
                }
            };

            return new SearchClaimResponse
            {
                ClaimNumber = random.Next(),     
                CoverCause = "DelayedDeparture",
                Insured = insured,
                Status = ClaimStatus.Open.Description()
            };
        }

        public CreateClaimResponse SubmitClaim(CreateClaimRequest request)
        {
            var random = new Random(10000);

            return new CreateClaimResponse
            {
                ClaimNumber = random.Next(),
                Status = ClaimStatus.Pending.Description()
            };
        }
    }
}
