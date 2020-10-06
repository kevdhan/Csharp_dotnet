using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Poker
{
    class Program
    {
        // Test Area //
        enum testEnum
        {
            Apple,
            Turkey
        }
        // Test Area //

        static void Main(string[] args)
        {
            // Test Area //
            Card card = new Card();
            Card card2 = new Card(8, "S");

            ImmutableArray<int> Ranks = ImmutableArray.Create(new int[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
            Console.WriteLine(Ranks[0]);

            Console.WriteLine(testEnum.Apple);

            Console.WriteLine(card);
            Console.WriteLine(card2);
            Console.WriteLine(card.Rank);

            if (Ranks.Contains(11))
            {
                Console.WriteLine("Success");
            }

            Console.WriteLine(card > card2);

            Deck testDeck = new Deck();
            Console.WriteLine(testDeck);

            Console.WriteLine(26 % 13);

            List<List<int>> test2DList = new List<List<int>>();
            test2DList.Add(new List<int>());
            test2DList[0].Add(55);

            Console.WriteLine(test2DList[0][0]);

            Console.WriteLine(new Poker(3));

            // Test Area //
        }
    }
}
