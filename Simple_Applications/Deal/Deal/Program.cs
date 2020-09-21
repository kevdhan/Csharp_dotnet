using System;

namespace Deal
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask user how many times they want to play
            Console.Write("Enter number of times you want to play: ");
            var numgames = double.Parse(Console.ReadLine());

            Console.WriteLine($"{"Prize", -10} {"Guess", -10} {"View", -10} {"New Guess", -10}");

            var numwins = 0;

            Random randnum = new Random();

            // User guess, prize, and view is randomly generated
            for (int i = 1; i < numgames+1; i++)
            {
                var prize = randnum.Next(1, 4);
                var guess = randnum.Next(1, 4);
                var view = randnum.Next(1, 4);
                while (view == prize || view == guess)
                {
                    view = randnum.Next(1, 4);
                }

                var newGuess = randnum.Next(1, 4);
                while (newGuess == guess || newGuess == view)
                {
                    newGuess = randnum.Next(1, 4);
                }

                Console.WriteLine($"{prize, 3} {guess, 10} {view, 9} {newGuess, 12}");

                if (newGuess == prize)
                {
                    numwins++;
                }
            }

            Console.WriteLine($"Probability of winning if you switch = "
                + string.Format("{0:0.##}", numwins/numgames));

            Console.WriteLine($"Probability of winning if you DO NOT switch = "
                + string.Format("{0:0.##}", 1 - (numwins / numgames)));
        }
    }
}
