# TexasHoldEm
A simple Texas Hold'em application to be used as a code sample.

## Notes:
- The annotations on the curly braces are a visual aid for me, my brain has a hard time parsing them without assistance
- I made the decision to use a 3rd party hand evaluator rather than rolling my own since this is a problem that has been solved many times in the past and handling all of the scenarios properly would take more time than I felt I should for that piece, which allowed me to polish other areas instead
- The ending was a little rushed (the ShowDown and Dealer logic) which is why there's more duplication of code there than in other places due to time constraints
- I originally intended for there to be more unit testing, but unfortunately, time got in the way again

## The parameters were as follows:

Please create a C# console application that allows a single person to play a game of Texas Holdem Poker against the computer.
The computer opponent does not need to implement any smarts (not looking for AI), you can just use a random number generator to make decisions.
The game should perform all of the following:

- Display a list of sample winning combinations:
- Royal Flush
- Straight Flush
- Four of a Kind
- Full House
- Flush
- Straight
- Three of a kind
- Two Pair
- Pair

1) Ask the user for a player name.
2) Inform the player that “Buy In is $50, each chip is $1”; get their “ok” to begin playing
3) Perform a shuffle of the cards. NOTE: the deck of cards should be a standard deck having 4 suits with 13 ranks, so 52 cards
4) Deal 2 cards to the player (cards displayed for player)
5) Deal 2 cards to the computer (do not display cards to player but do notify the player that the cards have been dealt)
6) Human player goes first; allow player to check, bet, or fold
7) Have computer check, bet, or fold; depending on human player’s action
8) Reveal cards from deck (first reveal 3 cards, then a 4th, then a last card)
9) Repeat steps 7 thru 9 until there is a winner
10) Award the winner the chips
11) Continue playing until player quits or has no more chips, or has all of the chips
