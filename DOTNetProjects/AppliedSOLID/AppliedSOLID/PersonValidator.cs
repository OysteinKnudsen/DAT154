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
                StandardMessages.DisplayValidationErrorFor(person.FirstName);
                return false;
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                StandardMessages.DisplayValidationErrorFor(person.LastName.ToString());
                return false;
            }

            return true;
        }
    }
}
