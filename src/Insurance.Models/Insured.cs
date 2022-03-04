using System;

namespace Insurance.Models
{
    public class Insured
    {
        public Guid InsuredId { get; set; }

        public Title Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
