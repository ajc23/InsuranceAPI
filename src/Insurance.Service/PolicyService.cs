using System;
using System.Collections.Generic;
using Insurance.Models;
using Insurance.Models.Policy;

namespace Insurance.Service
{
    public class PolicyService : IPolicyService
    {
        public SearchPolicyResponse FindPolicy(SearchPolicyRequest request)
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

            return new SearchPolicyResponse
            {
                PolicyNumber = random.Next(),     
                Insured = insured,
                StartDate = DateTime.Today.AddDays(-20),
                EndDate = DateTime.Today.AddDays(-20).AddYears(1)
            };
        }
    }
}
