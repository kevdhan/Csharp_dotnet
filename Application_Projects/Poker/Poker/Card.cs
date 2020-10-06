using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Poker
{
    public class Card
    {
        // Immutable Array of Ranks
        public static ImmutableArray<int> Ranks = ImmutableArray.Create(new int[] {2,3,4,5,6,7,8,9,10,11,12,13,14});

        public static ImmutableArray<string> Suits = ImmutableArray.Create(new string[] { "C", "D", "H", "S" });

        // Card read-only properties
        public int Rank { get; }
        public string Suit { get; }

        /// <summary>
        /// default constructor
        /// </summary>
        public Card()
        {
            Rank = 12;
            Suit = "S";
        }

        /// <summary>
        /// Constructor with input for Rank and Suit
        /// </summary>
        /// <param name="Rank"></param>
        /// <param name="Suit"></param>
        public Card(int Rank, String Suit)
        {
            if (Ranks.Contains(Rank)) // making sure rank is in Ranks
            {
                this.Rank = Rank;
            }
            else
            {
                this.Rank = 12;
            }
            this.Suit = Suit;
        }

        /// <summary>
        /// overriding ToString() method
        /// </summary>
        /// <returns> returns the Rank and Suit of a card </returns>
        public override string ToString()
        {
            switch (Rank)
            {
                case 11:
                    return "J" + Suit;
                case 12:
                    return "Q" + Suit;
                case 13:
                    return "K" + Suit;
                case 14:
                    return "A" + Suit;
                default:
                    return "" + Rank + Suit;
            }
        }

        public override bool Equals(Object obj)
        {
            var card = obj as Card;

            return (this.Rank == card.Rank && this.Suit == card.Suit);
        }

        // need to better implement this override method
        public override int GetHashCode()
        {
            return 0;
        }

        public static bool operator == (Card card1, Card card2)
        {
            return (card1.Rank == card2.Rank);
        }

        public static bool operator != (Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public static bool operator > (Card card1, Card card2)
        {
            return (card1.Rank > card2.Rank);
        }

        public static bool operator < (Card card1, Card card2)
        {
            return (card1.Rank > card2.Rank);
        }

    }
}
