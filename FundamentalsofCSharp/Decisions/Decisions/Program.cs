using System;

namespace Decisions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bob's Big Giveaway");
            Console.Write("Choose a door: 1, 2 or 3: ");
            string userValue = Console.ReadLine();
            string message; // making it readily available
            if (userValue == "1")
            {
                message = "You won a new car!";
            }
            else if (userValue == "2")
            {
                message = "you won a boat!";
            }
            else if (userValue == "3")
            {
                message = "you won a new cat!";
            }
            else
            {
                message = "wrong input. Error! ";
                message += "YOU LOSE!";
            }

            Console.WriteLine(message);
            Console.WriteLine();

            // asking the question continuously, utilizing while loop
            Console.Write("Choose a door: 1, 2 or 3: ");
            string userValue2 = Console.ReadLine();
            while (userValue2 != "1" && userValue2 != "2" && userValue2 != "3")
            {
                Console.Write("Please choose a door: 1, 2 or 3: ");
                userValue2 = Console.ReadLine();
            }
            Console.WriteLine("yay");
            Console.WriteLine();


            //
            Console.WriteLine("Bob's Big Giveaway");
            Console.Write("Choose a door: 1, 2 or 3: ");
            string userValue3 = Console.ReadLine();

            // if the user's input is "1" --> TRUE, then message3 will get value "boat", else --> FALSE | "strand of line"
            string message3 = (userValue3 == "1") ? "boat" : "strand of lint"; // basically if else

            /* https://stackoverflow.com/questions/530539/what-does-0-mean-when-found-in-a-string-in-c
             * More info on {0}
            */
            Console.WriteLine("You won a {0}.", message3); // formatted version
            Console.WriteLine("You entered : {0}, therefore you won a {1}.", userValue3, message3);
            Console.Write("You won a " + message3 + "."); // concatenated version
            /*
            Console.Write("You won a ");
            Console.Write(message3);
            Console.Write(".");
            */
            // Console.ReadLine();
        }
    }
}
