using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Winsoft.Gaming.GenericPokerFormationChecker;

namespace TexasHoldEm.Library
{
    public class PlayingField
    {
        public Player Gambler;
        public Player Table;
        public Player Dealer;
        public Deck Deck { get; set; }

        public PlayingField(string playerName)
        {
            Gambler = new Player(playerName, 50);
            Table = new Player("Table", 0);
            Dealer = new Player("Dealer", 50);
            Deck = new Deck();
            ResetHands();
        } // constructor

        public void ResetHands()
        {
            Deck.Shuffle();
            Gambler.NewHand();
            Table.NewHand();
            Dealer.NewHand();
        } // method ResetHands

        public Player? AnyPlayerOutOfChips()
        {
            if (Gambler.Chips == 0) { return Gambler; }
            if (Dealer.Chips == 0) { return Dealer; }
            return null;
        } // method AnyPlayerOutOfChips

        public bool TimeForShowdown()
        {
            return Table.Hand.Count == 3;
        } // method TimeForShowdown

        public void ShowTable(bool showDealerHand)
        {
            WriteLine(Dealer.ToString());
            if ((Dealer.HasCards()) && (showDealerHand)) { WriteLine($"\n{Dealer.ShowHand()}\n--==--\n"); }
            WriteLine(Table.ToString());
            if (Table.HasCards()) { WriteLine($"\n{Table.ShowHand()}\n--==--\n"); }
            WriteLine(Gambler.ToString());
            if (Gambler.HasCards()) { WriteLine($"\n{Gambler.ShowHand()}\n--==--\n"); }
        } // method ShowTable(bool showDealerHand)

        public void ShowTable()
        {
            ShowTable(false);
        } // method ShowTable

        public void DealRound()
        {
            int tableCards = Table.Hand.Count;
            if (tableCards < 3)
            {
                WriteLine("Dealing cards, please be patient");

                // Dealer and gambler only get 2 cards
                if (tableCards < 2)
                {
                    Gambler.AcceptCard(Deck.DealCard());
                    Dealer.AcceptCard(Deck.DealCard());
                } // if (tableCards < 2)
                Table.AcceptCard(Deck.DealCard());
            } // if (tableCards < 4)

        } // method DealRound

        public void ProcessBet(ref Player player, int bet)
        {
            WriteLine($"{player.Name} is betting {bet}");
            player.PayOut(bet);
            Table.AcceptChips(bet);
        } // method ProcessBet

        public void GivePotToWinner(ref Player winner)
        {
            int pot = Table.Chips;
            WriteLine($"{winner.Name} wins {pot} chips!");
            Table.PayOut(pot);
            winner.AcceptChips(pot);
        } // method GivePotToWinner

        private string MapPlayerCards(Player player)
        {
            string returnStr = "";
            for (int i = 0;i < player.Hand.Count;i++)
            {
                returnStr += CardMapper.MapCard(player.Hand[i]);
                if (i < player.Hand.Count -1) { returnStr += ", "; }
            } // for (int i = 0;i < player.Hand.Count - 1;i++)
            return returnStr;
        } // method MapPlayerCards

        private string ParseHandForChecking(Player player)
        {
            string returnStr = $"{MapPlayerCards(player)}, {MapPlayerCards(Table)}";
            return returnStr;
        } // method ParseHandForChecking

        public void ShowDown()
        {
            WriteLine("Showdown time!");

            string playerMappedHand = ParseHandForChecking(Gambler);
            string dealerMappedHand = ParseHandForChecking(Dealer);
            FormationChecker playerChecker = new FormationChecker(playerMappedHand);
            playerChecker.CheckFormation();
            FormationChecker dealerChecker = new FormationChecker(dealerMappedHand);
            dealerChecker.CheckFormation();

            string playerHand = $"{Gambler.ShowHand()}\n{Table.ShowHand()}";
            string dealerHand = $"{Dealer.ShowHand()}\n{Table.ShowHand()}";
            string playerFormation = playerChecker.GetFormationDescription().Formation.ToString();
            string dealerFormation = dealerChecker.GetFormationDescription().Formation.ToString();
            WriteLine($"{Gambler.Name} has:\n{playerHand}\nFormation: {playerFormation}");
            WriteLine($"{Dealer.Name} has:\n{dealerHand}\nFormation: {dealerFormation}");

            int playerScore = playerChecker.GetFormationDescription().Score;
            int dealerScore = dealerChecker.GetFormationDescription().Score;
            Player winner;
            string winningFormation;
            if (dealerScore >= playerScore)
            {
                winner = Dealer;
                winningFormation = dealerFormation;
            }
            else
            {
                winner = Gambler;
                winningFormation = playerFormation;
            } // if (dealerScore >= playerScore)

            WriteLine($"{winner.Name} wins this hand with {winningFormation}!");
            GivePotToWinner(ref winner);
            ResetHands();
        } // method ShowDown
    } // class PlayingField
}
