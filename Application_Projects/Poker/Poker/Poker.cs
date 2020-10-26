using System;
using System.Collections.Generic;

namespace Poker
{
    public class Poker
    {
        private Deck deck;
        private List<List<Card>> playerHands;
        private List<(string Hand, double Point)> playerPoints; 
        private const int numCards = 5;
        private int numPlayers;

        public Poker(int numPlayers)
        {
            // creating a new shuffled deck
            deck = new Deck();

            if (numPlayers < 1 || numPlayers > (deck.DeckSize()/numPlayers))
            {
                throw new ArgumentOutOfRangeException($"Number of Players must be greather >= 1 " +
                     $" and <= {deck.DeckSize() / numCards}");
            }

            // instantiating number of players
            this.numPlayers = numPlayers;
            // creating players
            playerHands = new List<List<Card>>();
            // instantiating player points
            playerPoints = new List<(string, double)>();
            
        }

        /// <summary>
        /// public method to initiate the game of poker
        /// </summary>
        public void Play()
        {
            deal();
            sortPlayerHands();
            getAllPlayerPoints();
            printGame();
        }

        private void printGame()
        {
            // print out player's card
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                Console.Write($"Player{playerIdx+1}:");
                var playerHand = playerHands[playerIdx];
                // printing each player's cards
                for (int cardIdx = 0; cardIdx < numCards; cardIdx++)
                {
                    Console.Write($" {playerHand[cardIdx]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // print out player's highest hand, and determine who won
            double highestPoint = 0;
            int winner = 0;
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                Console.WriteLine($"Player{playerIdx + 1}: {playerPoints[playerIdx].Hand}");

                // checking for which player had highest point
                if (playerPoints[playerIdx].Point > highestPoint)
                {
                    highestPoint = playerPoints[playerIdx].Point;
                    winner = playerIdx;
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Player {winner + 1} wins");
        }

        /// <summary>
        /// gets the highest points possible for each player's hand
        /// </summary>
        private void getAllPlayerPoints()
        {
            // go through each player's hand to find highest hand
            for (int playerIdx = 0; playerIdx < numPlayers; playerIdx++)
            {
                // need to check from Royal Flush to Single Hand
                var playerHand = playerHands[playerIdx];
                if (isRoyalFlush(playerHand) != 0)
                {
                    playerPoints.Add(("Royal Flush", isRoyalFlush(playerHand)));
                }
                else if (isStraightFlush(playerHand) != 0)
                {
                    playerPoints.Add(("Straight Flush",isStraightFlush(playerHand)));
                }
                else if (isFourKind(playerHand) != 0)
                {
                    playerPoints.Add(("Four of a Kind",isFourKind(playerHand)));
                }
                else if (isFullHouse(playerHand) != 0)
                {
                    playerPoints.Add(("Full House", isFullHouse(playerHand)));
                }
                else if (isFlush(playerHand) != 0)
                {
                    playerPoints.Add(("Flush", isFlush(playerHand)));
                }
                else if (isStraight(playerHand) != 0)
                {
                    playerPoints.Add(("Straight", isStraight(playerHand)));
                }
                else if (isThreeKind(playerHand) != 0)
                {
                    playerPoints.Add(("Three of a Kind", isThreeKind(playerHand)));
                }
                else if (isTwoPair(playerHand) != 0)
                {
                    playerPoints.Add(("Two Pair", isTwoPair(playerHand)));
                }
                else if (isOnePair(playerHand) != 0)
                {
                    playerPoints.Add(("One Pair", isOnePair(playerHand)));
                }
                else
                {
                    playerPoints.Add(("High Card", isHighCard(playerHand)));
                }
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
                        && (playerHand[cardIdx] == playerHand[cardIdx + idxLoop]);
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
            bool threeKindFlag = false, twoPairFlag = false;
            int threeKindIdx = 0, twoPairIdx = 0;

            // check for 3 & 2 pair
            for (int cardIdx = 0; cardIdx < numCards - 1; cardIdx++)
            {
                // 3 pair not found yet
                if (!threeKindFlag && (cardIdx < numCards - 2))
                {
                    // 3 pair is found
                    if (playerHand[cardIdx] == playerHand[cardIdx+1]
                        && playerHand[cardIdx] == playerHand[cardIdx+2])
                    {
                        threeKindFlag = true;
                        threeKindIdx = cardIdx;
                        cardIdx += 2;
                    }
                }
                // 2 pair not found
                else if (!twoPairFlag)
                {
                    if (playerHand[cardIdx] == playerHand[cardIdx+1])
                    {
                        twoPairFlag = true;
                        twoPairIdx = cardIdx;
                    }
                }
            }

            // calculate points if 3 kind and Pair is found
            if (threeKindFlag && twoPairFlag)
            {
                var points = 7 * Math.Pow(15, numCards);
                int pointPowFirst = numCards - 1, pointPowSecond = pointPowFirst - 3;
                int pointPowLeftover = numCards - 6; // there are 5 cards in a full house
                for (int cardIdx = 0; cardIdx < numCards; cardIdx++)
                {
                    // 3 kind
                    if (cardIdx >= threeKindIdx && cardIdx <= threeKindIdx + 2)
                    {
                        points += playerHand[cardIdx].Rank * Math.Pow(15, pointPowFirst);
                        pointPowFirst--;
                    }
                    // pair
                    else if (cardIdx >= twoPairIdx && cardIdx <= twoPairIdx + 1)
                    {
                        points += playerHand[cardIdx].Rank * Math.Pow(15, pointPowSecond);
                        pointPowSecond--;
                    }
                    else
                    {
                        points += playerHand[cardIdx].Rank * Math.Pow(15, pointPowLeftover);
                    }
                }
                return points;
            }
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
        private double isStraight(List<Card> playerHand)
        {
            bool straightFlag = false;
            int straightIdx = 0, cardIdx = 0;
            while (!straightFlag && (cardIdx < numCards - 4))
            {
                straightFlag = true; // assumes current card + next 4 are in a straight
                for (int straightCounter = cardIdx; straightCounter < cardIdx + 4; straightCounter++)
                {
                    // checking if cards are decreasing, by 1
                    if (playerHand[straightCounter].Rank != playerHand[straightCounter + 1].Rank + 1)
                    {
                        straightFlag = false; // straight does not exist, set flag to false
                    }
                }
                if (straightFlag) // there is a straight
                {
                    straightIdx = cardIdx; // obtain index of 1 card in straight
                }
                cardIdx++;
            }

            // if there is a straight, calculate points
            if (straightFlag)
            {
                // get points
                var points = 5 * Math.Pow(15, numCards);
                int pointPow = numCards - 1; // power points for card in straight
                int pointPowLeftover = pointPow - 5; // there are 3 cards in a 3 kind
                for (int pointcardIdx = 0; pointcardIdx < numCards; pointcardIdx++)
                {
                    // card is part of straight
                    if (pointcardIdx >= straightIdx && pointcardIdx <= straightIdx + 4)
                    {
                        points += playerHand[pointcardIdx].Rank * Math.Pow(15, pointPow);
                        pointPow--;
                    }
                    // card is NOT part of straight
                    else
                    {
                        points += playerHand[pointcardIdx].Rank * Math.Pow(15, pointPowLeftover);
                        pointPowLeftover--;
                    }
                }
                return points;
            }
            return 0;
        }
        // 3 of a kind - special rule
        private double isThreeKind(List<Card> playerHand)
        {
            bool threekindFlag = false;
            int pairIdx = 0, cardIdx = 0;
            while (!threekindFlag && cardIdx < numCards - 2)
            {
                // checking if 3 of a kind
                if (playerHand[cardIdx] == playerHand[cardIdx + 1]
                    && playerHand[cardIdx] == playerHand[cardIdx + 2])
                {
                    pairIdx = cardIdx; // obtaining index of beginning of 3 of a kind pair
                    threekindFlag = true;
                }
                cardIdx++;
            }

            // if there is a 3 of a kind, calculate points
            if (threekindFlag)
            {
                // get points
                var points = 4 * Math.Pow(15, numCards);
                int pointPow = numCards - 1;
                int pointPowLeftover = pointPow - 3; // there are 3 cards in a 3 kind
                for (int pointcardIdx = 0; pointcardIdx < numCards; pointcardIdx++)
                {
                    if (pointcardIdx >= pairIdx && pointcardIdx <= pairIdx + 2)
                    {
                        points += playerHand[pointcardIdx].Rank * Math.Pow(15, pointPow);
                        pointPow--;
                    }
                    else
                    {
                        points += playerHand[pointcardIdx].Rank * Math.Pow(15, pointPowLeftover);
                        pointPowLeftover--;
                    }
                }
                return points;
            }
            return 0;
        }
        // 2 pair - special rule
        private double isTwoPair(List<Card> playerHand)
        {
            bool firstPairFlag = false, secondPairFlag = false;
            int firstPairIdx = 0, secondPairIdx = 0;

            for (int cardIdx = 0; cardIdx < numCards-1; cardIdx++)
            {
                // only do process, if second pair has not been found
                // reasoning is in case there is a possible 3 pair, you only want to get
                // top 2 pairs
                if (!secondPairFlag)
                {
                    if (firstPairFlag) // if firstPair was found, check for second
                    {
                        if (playerHand[cardIdx] == playerHand[cardIdx + 1])
                        {
                            secondPairFlag = true;
                            secondPairIdx = cardIdx;
                        }
                    }
                    else // still need to look for first pair
                    {
                        if (playerHand[cardIdx] == playerHand[cardIdx + 1])
                        {
                            firstPairFlag = true;
                            firstPairIdx = cardIdx;
                            cardIdx++;
                        }
                    }
                }
            }

            // calculate points
            if (secondPairFlag) // if there ended up being 2 pairs
            {
                var points = 3 * Math.Pow(15, numCards);
                int pointPowFirst = numCards - 1, pointPowSecond = pointPowFirst - 2;
                int pointPowLeftover = numCards - 5; // there are 4 cards for 2 pairs
                for (int cardIdx = 0; cardIdx < numCards; cardIdx++)
                {
                    // first pair
                    if (cardIdx >= firstPairIdx && cardIdx <= firstPairIdx + 1)
                    {
                        points += playerHand[cardIdx].Rank * Math.Pow(15, pointPowFirst);
                        pointPowFirst--;
                    }
                    else if (cardIdx >= secondPairIdx && cardIdx <= secondPairIdx + 1)
                    {
                        points += playerHand[cardIdx].Rank * Math.Pow(15, pointPowSecond);
                        pointPowSecond--;
                    }
                    else
                    {
                        points += playerHand[cardIdx].Rank * Math.Pow(15, pointPowLeftover);
                    }
                }
                return points;
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
                bool onePairFlag = playerHand[cardIdx] == playerHand[cardIdx + 1];
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
            // round robin - each player gets 1 card each round
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
