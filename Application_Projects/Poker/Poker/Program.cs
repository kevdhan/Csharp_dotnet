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

            Console.WriteLine("In this game of poker, 1 deck of cards is used (52 cards)," +
                " where each player gets 5 cards each. This means, only 1-10 players may" +
                " play at a time.");

            while (!correctInput)
            {
                Console.Write("Enter number of players (1-10): ");
                // trying to parse user input into an integer
                try
                {
                    numPlayers = Int32.Parse(Console.ReadLine());

                    Poker pokerGame = new Poker(numPlayers);
                    pokerGame.Play();

                    correctInput = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
