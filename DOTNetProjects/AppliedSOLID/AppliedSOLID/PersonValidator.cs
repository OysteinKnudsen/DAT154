using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedSOLID
{
    class PersonValidator
    {
        public static bool Validate(Person person)
        {
            //Check to see if first and last names are valid
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                Console.WriteLine("Invalid first name");
                StandardMessages.EndApplication();
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                Console.WriteLine("Invalid last name");
                StandardMessages.EndApplication();
                return false;
            }

            return true;
        }
    }
}
