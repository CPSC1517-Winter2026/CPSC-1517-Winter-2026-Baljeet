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


        public void ChangeFullName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddEmployment(Employment employment) {

            if (employment == null)
                throw new ArgumentNullException($"Employment can't be a null value : {employment}");

            if (EmploymentPositions.Any(ep => ep.Title.Equals(employment.Title)
                                                        && employment.StartDate == employment.StartDate))
            {
                throw new ArgumentException($" duplicate employment position: {employment.Title} and start date as : {employment.StartDate} ");
            }
        
            EmploymentPositions.Add(employment);
        }
    }
}
