using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeObjectProblems2
{
    internal class Artist
    {
        // Define fields for internal usage
        private string _firstName = null!;
        private string _lastName = null!;

        // Define properties for external usage
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First Name is requried");
                }
                _firstName = value.Trim(); 
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last Name is required");
                }
                _lastName = value.Trim();
            }
        }

        // Define a constructor for initializing the fields/properties with specific values
        public Artist(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
