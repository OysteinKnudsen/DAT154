using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedSOLID
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ask user for information
            StandardMessages.WelcomeMessage();

            Person user = new Person();

            Console.WriteLine("What is your name?");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("What is your last name?");
            user.LastName = Console.ReadLine();


            //Check to see if first and last names are valid
            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                Console.WriteLine("Invalid first name");
                StandardMessages.EndApplication();
                return;
            }

            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                Console.WriteLine("Invalid last name");
                StandardMessages.EndApplication();
                return;
            }


        }
    }
}
