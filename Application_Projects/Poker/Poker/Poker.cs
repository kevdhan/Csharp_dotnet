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
            testHand.Add(new Card(6, "S"));
            testHand.Add(new Card(4, "S"));
            testHand.Add(new Card(5, "S"));
            testHand.Add(new Card(5, "S"));
            testHand.Add(new Card(7, "S"));
            testHand.Sort((card1, card2) => card2.Rank.CompareTo(card1.Rank));
            // playerHands[playerIdx].Sort((card1, card2) => card2.Rank.CompareTo(card1.Rank));
            Console.WriteLine($"1 Pair: {isHighCard(testHand)}");
            Console.WriteLine((1*Math.Pow(15,5))+(Math.Pow(15,4)*7)+(Math.Pow(15,3)*6)
                +(Math.Pow(15, 2)*5)+ (Math.Pow(15, 1)*5)+ 4);
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
                    double points = 8*(Math.Pow(15,numCards));

                    // going down player's hand to calculate points
                    // cardIdx == the index in players hand where condition was met
                    int pointPow = numCards - 1;
                    int pointLeftOverPow = pointPow - 4; // minus 4, b/c 4 cards make 4kind
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
        // Full House - 3 Same Cards, 2 same cards - special rule
        private double isFullHouse(List<Card> playerHand)
        {
            return 0;
        }
        // Flush - 5 cards all same suit. Numerical Order does not matter
        private double isFlush(List<Card> playerHand)
        {
            int cardIdx = 0;
            while (cardIdx + 4 < numCards)
            {
                bool flushFlag = true;
                for (int idxLoop = 1; idxLoop < 5; idxLoop++)
                {
                    // check if suits of cards, 5 in a row, match
                    flushFlag = flushFlag
                        && (playerHand[cardIdx].Suit == playerHand[cardIdx + idxLoop].Suit);
                }
                if (flushFlag) // there is a five of a kind
                {
                    // calculate points
                    double points = 6 * (Math.Pow(15, numCards));

                    // going down player's hand to calculate points
                    // cardIdx == the index in players hand where condition was met
                    int pointPow = numCards - 1;
                    int pointLeftOverPow = pointPow - 5; // minus 5 because 5 cards make a flush
                    for (int pointIdx = 0; pointIdx < numCards; pointIdx++)
                    {
                        // within range of 5 cards w/same suits
                        if (pointIdx >= cardIdx && pointIdx <= cardIdx + 4)
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
        // Straight - 5 cards in numerical order, but not all same suit
        // 3 of a kind - special rule
        // 2 pair - special rule
        private double isTwoPair(List<Card> playerHand)
        {
            int cardIdx = 0;
            while (cardIdx + 1 < numCards)
            {
                // check if pair, check 2 cards
                bool onePairFlag = playerHand[cardIdx].Rank == playerHand[cardIdx + 1].Rank;
                Console.WriteLine($"{onePairFlag}: {playerHand[cardIdx].Rank}, {cardIdx}");
                if (onePairFlag) // there is a pair
                {
                    // calculate points
                    double points = 2 * (Math.Pow(15, numCards));

                    // going down player's hand to calculate points
                    // cardIdx == the index in players hand where condition was met
                    int pointPow = numCards - 1;
                    int pointLeftOverPow = pointPow - 2; // minus 2 b/c 2 cards make a flush
                    for (int pointIdx = 0; pointIdx < numCards; pointIdx++)
                    {
                        // within range of 2 cards w/same rank
                        if (pointIdx >= cardIdx && pointIdx <= cardIdx + 1)
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
        // 1 pair - special rule
        private double isOnePair(List<Card> playerHand)
        {
            int cardIdx = 0;
            while (cardIdx + 1 < numCards)
            {
                // check if pair, check 2 cards
                bool onePairFlag = playerHand[cardIdx].Rank == playerHand[cardIdx + 1].Rank;
                Console.WriteLine($"{onePairFlag}: {playerHand[cardIdx].Rank}, {cardIdx}");
                if (onePairFlag) // there is a pair
                {
                    // calculate points
                    double points = 2 * (Math.Pow(15, numCards));

                    // going down player's hand to calculate points
                    // cardIdx == the index in players hand where condition was met
                    int pointPow = numCards - 1;
                    int pointLeftOverPow = pointPow - 2; // minus 2 b/c 2 cards make a flush
                    for (int pointIdx = 0; pointIdx < numCards; pointIdx++)
                    {
                        // within range of 2 cards w/same rank
                        if (pointIdx >= cardIdx && pointIdx <= cardIdx + 1)
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
        // High Card
        private double isHighCard(List<Card> playerHand)
        {
            var points = Math.Pow(15, numCards);
            var pointPow = numCards - 1;
            // calculating points for hand
            for (int cardIdx = 0; cardIdx < numCards; cardIdx++, pointPow--)
            {
                points += (playerHand[cardIdx].Rank * Math.Pow(15, pointPow));
            }
            return points;
        }

        /// <summary>
        /// sorting the hands of each player, in descending order by Rank
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
