using System;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Name Game");

            Console.Write("What's your first name? ");
            string firstName = Console.ReadLine();

            Console.Write("What's your last name? ");
            string lastName = Console.ReadLine();

            Console.Write("In what city were you born? ");
            string city = Console.ReadLine();

            /*
            // reverse first name
            char[] firstNameArray = firstName.ToCharArray(); // converting string into an array of char's
            Array.Reverse(firstNameArray);

            char[] lastNameArray = lastName.ToCharArray();
            Array.Reverse(lastNameArray);

            char[] cityArray = city.ToCharArray();
            Array.Reverse(cityArray);

            // adding the reversed strings into 1 string
            string result = "";

            foreach (char item in firstNameArray)
            {
                result += item;
            }
            result += " ";

            foreach (char item in lastNameArray)
            {
                result += item;
            }
            result += " ";

            foreach (char item in cityArray)
            {
                result += item;
            }
            */

            Console.Write("Results: ");

            ReverseString(firstName);
            ReverseString(lastName);
            ReverseString(city);
        }

        /* creating method to reduce redundancy in code
         * 1. Taking in a string
         * 2. converting it into an array of chars
         * 3. reversing the order
         * 4. printing out the char's
         */
        private static void ReverseString(string message) // adding input parameter to method
        {


            // reversing string
            char[] messageArray = message.ToCharArray(); // converting string into an array of char's
            Array.Reverse(messageArray);

            // adding char's in array to string
            foreach (char item in messageArray)
            {
                //result += item;
                Console.Write(item);
            }
            Console.Write(" "); // adding space
        }
    }
}
