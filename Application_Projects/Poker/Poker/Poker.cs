using System;
using System.Collections.Generic;

namespace Poker
{
    public class Poker
    {
        private Deck deck;
        private List<List<Card>> playerHands;
        private List<double> playerPoints;
        private const int numCards = 5;
        private int numPlayers;

        public Poker(int numPlayers)
        {
            // instantiating number of players
            this.numPlayers = numPlayers;
            // creating a new shuffled deck
            deck = new Deck();
            // creating players
            playerHands = new List<List<Card>>();
            // instantiating player points
            playerPoints = new List<double>(numPlayers);
            
        }

        /// <summary>
        /// public method to initiate the game of poker
        /// </summary>
        public void Play()
        {
            deal();
            sortPlayerHands();
            //getAllPlayerPoints();

            // test area
            List<Card> testHand = new List<Card>();
            testHand.Add(new Card(3, "S"));
            testHand.Add(new Card(2, "S"));
            testHand.Add(new Card(2, "S"));
            testHand.Add(new Card(2, "S"));
            testHand.Add(new Card(2, "S"));
            Console.WriteLine($"4 of a kind: {isFourKind(testHand)}");
            Console.WriteLine((9*Math.Pow(15,5))+(Math.Pow(15,4)*2)+ (Math.Pow(15, 3)*2)
                +(Math.Pow(15, 2)*2)+ (Math.Pow(15, 1)*2)+ 3);
            // test area
        }

        private void getAllPlayerPoints()
        {
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                // need to check from Royal Flush to Single Hand
            }
        }

        /// <summary>
        /// Check if hand has a royal flush
        /// </summary>
        /// <param name="playerHand"></param>
        /// <returns> points if Royal Flush </returns>
        private double isRoyalFlush(List<Card> playerHand)
        {
            bool royalflushFlag = true;
            double points = 10*(Math.Pow(15,numCards));
            List<int> royalflushRef = new List<int>(new[] { 14, 13, 12, 11, 10 });
            for (int cardIdx = 0; cardIdx < numCards; cardIdx++)
            {
                points += playerHand[cardIdx].Rank * Math.Pow(15, numCards - 1 - cardIdx);
                // check if ranks match a royal flush
                royalflushFlag = royalflushFlag && (playerHand[cardIdx].Rank == royalflushRef[cardIdx]);
                // check if all suits match
                if (cardIdx < numCards-1)
                {
                    royalflushFlag = royalflushFlag && (playerHand[cardIdx].Suit == playerHand[cardIdx + 1].Suit);
                }
            }
            if (royalflushFlag) // if true, means royal flush exists
            {
                return points;
            }
            return 0;
        }
        /// <summary>
        /// Check if hand has a straight flush
        /// </summary>
        /// <param name="playerHand"></param>
        /// <returns> Returns points for straight flush, otherwise returns 0 </returns>
        private double isStraightFlush(List<Card> playerHand)
        {
            bool straightflushFlag = true;
            double points = 9 * (Math.Pow(15, numCards));
            for (int cardIdx = 0; cardIdx < numCards; cardIdx++)
            {
                points += playerHand[cardIdx].Rank * Math.Pow(15, numCards - 1 - cardIdx);
                if (cardIdx < numCards - 1)
                {
                    straightflushFlag = straightflushFlag && (playerHand[cardIdx].Rank == (playerHand[cardIdx + 1].Rank + 1));
                    straightflushFlag = straightflushFlag && (playerHand[cardIdx].Suit == playerHand[cardIdx + 1].Suit);
                }
            }
            if (straightflushFlag) // if true, means 
            {
                return points;
            }
            return 0;
        }
        // 4 of a kind - special rule on points
        private double isFourKind(List<Card> playerHand)
        {
            int cardIdx = 0;
            while (cardIdx+3 < numCards)
            {
                bool fourkindFlag = true;
                for (int idxLoop = 1; idxLoop < 4; idxLoop++)
                {
                    // check if ranks of cards, 4 in a row, match
                    fourkindFlag = fourkindFlag
                        && (playerHand[cardIdx].Rank == playerHand[cardIdx + idxLoop].Rank);
                }
                if (fourkindFlag) // there is a four of a kind
                {
                    // calculate points
                    double points = 9*(Math.Pow(15,numCards));

                    // re-organizing hand to restructure for points
                    int pointPow = numCards - 1;
                    int pointLeftOverPow = pointPow - 4;
                    for (int pointIdx = 0; pointIdx < numCards; pointIdx++)
                    {
                        // within range of 4 of a kind
                        if (pointIdx >= cardIdx && pointIdx <= cardIdx+3)
                        {
                            points += playerHand[pointIdx].Rank * Math.Pow(15, pointPow);
                            pointPow--;
                        }
                        else // leftover card
                        {
                            points += playerHand[pointIdx].Rank * Math.Pow(15, pointLeftOverPow);
                            pointLeftOverPow--;
                        }
                    }


                    return points; // return actual points
                }
                cardIdx++;
            }
            return 0;
        }
        // Full House - special rule
        private double isFullHouse(List<Card> playerHand)
        {
            return 0;
        }
        // Flush
        // Straight
        // 3 of a kind - special rule
        // 2 pair - special rule
        // 1 pair - special rule
        // High Card

        /// <summary>
        /// sorting the hands of each player
        /// </summary>
        private void sortPlayerHands()
        {
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                playerHands[playerIdx].Sort((card1, card2) => card2.Rank.CompareTo(card1.Rank)); 
            }
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
                playerHands.Add(new List<Card>());
            }

            // populating each players hand, round robin style
            for (int num = 0; num < numCards; num++)
            {
                for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
                {
                    playerHands[playerIdx].Add(deck.Deal());
                }
            }
        }

        public override string ToString()
        {
            string pokerString = "";
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                pokerString += $"Player {playerIdx + 1}:";
                foreach (var card in playerHands[playerIdx])
                {
                    pokerString += " " + card;
                }
                pokerString += " \n";
            }
            return pokerString; 
        }
    }
}
