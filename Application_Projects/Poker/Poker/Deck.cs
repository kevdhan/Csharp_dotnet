using System;
using System.Collections.Generic;

namespace Poker
{
    public class Deck
    {
        private List<Card> playDeck { get; }
        private static Random rnd = new Random();
        private int deckIdx = 0;

        /// <summary>
        /// default constructor, create a deck of 52 cards
        /// </summary>
        public Deck()
        {
            playDeck = new List<Card>();
            foreach (var rank in Card.Ranks)
            {
                foreach (var suit in Card.Suits)
                {
                    playDeck.Add(new Card(rank, suit));
                }
            }
            shuffle();
        }

        /// <summary>
        /// Shuffle cards of deck
        /// </summary>
        private void shuffle()
        {
            int deckSize = playDeck.Count;
            while (deckSize > 1)
            {
                deckSize--;
                int randIdx = rnd.Next(deckSize + 1);
                Card card = playDeck[randIdx];
                playDeck[randIdx] = playDeck[deckSize];
                playDeck[deckSize] = card;
            }
        }

        /// <summary>
        /// determines the decksize
        /// </summary>
        /// <returns> returns the number of cards left in the deck </returns>
        public int DeckSize()
        {
            return 52 - deckIdx;
        }

        /// <summary>
        /// deals a card from the deck
        /// </summary>
        /// <returns> returns a card </returns>
        public Card Deal()
        {
            Card dealCard = playDeck[deckIdx];
            deckIdx++;
            return dealCard;
        }

        // override ToString method to print out all cards in deck
        public override string ToString()
        {
            string deckString = "";
            for (int i = 0; i < playDeck.Count; i++)
            {
                deckString += playDeck[i] + " ";
                if ((i + 1) % 13 == 0)
                {
                    deckString += "\n";
                }
            }

            return deckString;
        }
    }
}
