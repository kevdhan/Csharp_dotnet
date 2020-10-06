using System;
using System.Collections.Generic;

namespace Poker
{
    public class Poker
    {
        private Deck deck;
        private List<List<Card>> players;
        private const int numCards = 5;
        private int numPlayers;

        public Poker(int numPlayers)
        {
            // instantiating number of players
            this.numPlayers = numPlayers;
            // creating a new shuffled deck
            deck = new Deck();
            // creating players
            players = new List<List<Card>>();
            // dealing cards to each player
            deal();
            
        }

        /// <summary>
        /// instantiating each players hand and dealing
        /// </summary>
        /// <param name="numPlayers"></param>
        private void deal()
        {
            // initializing each players hand
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                players.Add(new List<Card>());
            }

            // populating each players hand, round robin style
            for (int num = 0; num < numCards; num++)
            {
                for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
                {
                    players[playerIdx].Add(deck.Deal());
                }
            }
        }

        public override string ToString()
        {
            string pokerString = "";
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                pokerString += $"Player {playerIdx + 1}:";
                foreach (var card in players[playerIdx])
                {
                    pokerString += " " + card;
                }
                pokerString += " \n";
            }
            return pokerString;
        }
    }
}
