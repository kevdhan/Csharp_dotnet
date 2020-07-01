using System;

namespace WhileIteration
{
    class Program
    {
        static void Main(string[] args)
        {
            /* For iteration - iterate for a set # of times
             * 
             * While iteration - iterate until some condition is met - TRUE
             *
            */
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
                Console.WriteLine();
            }            
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1) Print Numbers");
            Console.WriteLine("2) Guessing Game");
            Console.WriteLine("3) Exit");
            string result = Console.ReadLine();
            if (result == "1")
            {
                PrintNumbers();
            }
            else if (result == "2")
            {
                GuessingGame();
            }
            else if (result == "3")
            {
                return false;
            }
            Console.ReadLine();
            Console.Clear();
            return true;
        }

        private static void PrintNumbers()
        {
            Console.Clear();
            Console.WriteLine("Print numbers!");
            Console.WriteLine("Type a number: ");
            int result = int.Parse(Console.ReadLine()); // parse data to convert from string to int
            int counter = 1;
            while (counter < result)
            {
                Console.Write(counter);
                Console.Write("-");
                counter++;
            }
            Console.Write(counter);
            Console.WriteLine();
        }

        private static void GuessingGame()
        {
            Console.Clear();
            Console.WriteLine("Guessing game!");

            Random myRandom = new Random(); // creating a new instance of the class Random
            int randomNumber = myRandom.Next(1, 11); // random number between 1 & 10
            // int random = (new Random()).Next();

            int guesses = 0;
            bool incorrect = true;

            do // do statement
            {
                Console.WriteLine("Guess a number between 1 and 10: ");
                string result = Console.ReadLine();
                guesses++;

                if (result == randomNumber.ToString()) // converting rand num to string
                {
                    incorrect = false;
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }

            } while (incorrect); // will loop as long as number was incorrectly guessed

            Console.WriteLine("Correct! It took you {0} guesses.", guesses);
        }

    }
}
