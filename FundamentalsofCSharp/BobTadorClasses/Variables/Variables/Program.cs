using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            // c# data types: https://www.w3schools.com/cs/cs_data_types.asp 

            // math operations
            int x = 7;
            int y = x + 3;
            Console.WriteLine(y);


            // variable naming convention: camel case


            // get first name
            Console.WriteLine("What is your name?");
            Console.Write("Type your first name: ");
            string firstName;
            firstName = Console.ReadLine();

            // get last name
            string myLastName;
            Console.Write("Type your last name: ");
            myLastName = Console.ReadLine();

            // get last name, different method... usually better to declare variables as you need them.
            Console.Write("Type your last name: ");
            string myLastName2 = Console.ReadLine();

            // print
            Console.WriteLine("Hello, " + firstName + " " + myLastName);
        }
    }
}
