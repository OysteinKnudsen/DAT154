using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedSOLID
{
    class PersonDataCapture
    {
        public static Person Capture()
        {
            Person user = new Person();

            Console.WriteLine("What is your name?");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            user.LastName = Console.ReadLine();

            return user;
        }
    }
}
