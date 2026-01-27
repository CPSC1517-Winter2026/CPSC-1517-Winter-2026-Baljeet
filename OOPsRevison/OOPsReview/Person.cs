using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        /// First write unit tests for this class
        private string _firstName;
        private string _lastName;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ResidentAddress Address { get; set; }

        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        //default constructor

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            EmploymentPositions = new List<Employment>();
        }

        // greedy constructor

        public Person(string fName, string lName, ResidentAddress address, List<Employment> employments)
        {
            FirstName = fName;
            LastName = lName;
            Address = address;
            EmploymentPositions = employments;

        }


    }
}
