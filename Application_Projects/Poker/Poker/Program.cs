using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool correctInput = false;
            int numPlayers = 0;
            while (!correctInput)
            {
                Console.Write("Enter number of players: ");
                try
                {
                    numPlayers = Int32.Parse(Console.ReadLine());
                    correctInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine();

            Poker pokerGame = new Poker(numPlayers);
            pokerGame.Play();
        }
    }
}
