Poker

Created a game replicating the game poker. User is asked to insert the # of players. Once establishing the # of players, the game will deal cards (default is 5) to each player, determine what each player hands consist of (highest rank), then determine which player wins.

The following are the hands possible, in descending order of how much each hand is worth (top are highest ranked hands):
- Royal Flush
- Straight Flush
- 4 of a kind
- Full House
- Flush
- Straight
- 3 of a kind
- 2 Pair
- 1 Pair
- High Card

Some things that were considered:
- Code was implemented so that the number of cards each player has (5) was not hard coded, so that when later changing the number of cards each player could hold was changed that only that variable needed to change, and everything else could stay as is. 
- Something that I considered was, is it necessary to make the code for this specific project hard coded, when I know for most of the time only 5 cards will be dealt. More time and resources was necessary to make the code more general to be able to fit more random use cases.
- For methods handling calculating hands (e.g. Full House, Straight, Two Pair, etc.), there needs to be a better uniform approach. When time permits, need to go back and make code more similar to one another.

How it works:
1. Program will prompt user for the # of players
2. Once # of players is established, the program in the back-end will create a deck, shuffle the deck, hand out cards to each player round robin style
3. The program will determine each players highest hand and display it for each player
4. The winner will be determined by highest hands and the program will display the winner
