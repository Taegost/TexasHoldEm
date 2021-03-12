using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TexasHoldEm.Library
{
    public class Game
    {
        private PlayingField PlayField { get; set; }
        private bool Continue { get; set; } = true;
        private Player Player
        {
            get
            { return PlayField.Gambler; }
        }
        static Random randomGenerator = new Random();

        public Game(PlayingField playField)
        {
            PlayField = playField;
        } // constructor

        public void Launch()
        {
            WriteLine($"Thank you for choosing to play, {Player.Name}.\n" +
                $"You have paid your buy-in and received 50 chips.\n");
            do
            {
                if (!PlayField.TimeForShowdown())
                {
                    PlayRound();
                }
                else
                {
                    PlayField.ShowDown();
                } // if (!PlayField.TimeForShowdown())
            } while (Continue);
        } // method Launch

        public void ResetHand()
        {
            PlayField.ResetHands();
        } // method ResetHand

        private PokerAction ChooseAction()
        {
            bool finished = false;
            HashSet<int> availableActions = new HashSet<int>();
            do
            {
                WriteLine();
                WriteLine("What would you like to do?");
                foreach (PokerAction action in (PokerAction[])Enum.GetValues(typeof(PokerAction)))
                {
                    WriteLine($"{(int)action}) {action.ToString()}");
                    availableActions.Add((int)action);
                } // foreach (Action action in (Action[])Enum.GetValues(typeof(Action)))
                int chosenAction;
                bool parsed = Int32.TryParse(ReadKey().KeyChar.ToString(), out chosenAction);
                WriteLine();
                if ((parsed) && (availableActions.Contains(chosenAction)))
                {
                    return (PokerAction)chosenAction;
                }
                else
                {
                    WriteLine("Please choose a valid option");
                }
            } while (!finished);

            // This code should never be reached, but just in case it is, let's exit the program.
            return PokerAction.Quit;
        } // method ChooseAction

        private void TakePlayerBet()
        {
            bool finished = false;
            if (Player.Chips == 0)
            {
                WriteLine("Sorry, you don't have enough chips to bet, automatically performing a Check.");
                finished = true;
            } // if (Player.Chips == 0)
            do
            {
                WriteLine("Please enter your bet: ");
                int bet;
                int maxBet = Player.Chips;
                Int32.TryParse(ReadLine().ToString(), out bet);
                if ((bet > 0) && (bet <= maxBet))
                {
                    PlayField.ProcessBet(ref PlayField.Gambler, bet);
                    finished = true;
                }
                else
                {
                    WriteLine($"Please enter a valid bet from 1 to {maxBet}");
                }
            } while (!finished);
        } // method TakePlayerBet

        private void DeclareLoser(Player loser)
        {
            WriteLine($"{loser.Name} loses because they are out of chips and is unable to play.");
            Continue = false;
        } // method DeclareWinner

        private void PlayRound()
        {
            Player outOfChips = PlayField.AnyPlayerOutOfChips();
            if (outOfChips == null)
            {
                PlayField.DealRound();
                PlayField.ShowTable();
                PokerAction chosenAction = ChooseAction();
                switch (chosenAction)
                {
                    case PokerAction.Quit:
                        Continue = false;
                        break;
                    case PokerAction.Bet:
                        TakePlayerBet();
                        break;
                    case PokerAction.Check:
                        WriteLine("Checking this round, got it!");
                        break;
                    case PokerAction.Fold:
                        WriteLine("Folding, Dealer wins");
                        PlayField.GivePotToWinner(ref PlayField.Dealer);
                        ResetHand();
                        break;
                } // switch (chosenAction)
                TakeDealerAction();
            } // if (outOfChips == null)
            else
            {
                DeclareLoser(outOfChips);
            } // if (outOfChips == null)

        } // method PlayRound

        private void TakeDealerAction()
        {
            // The dealer acts randomly
            int action = randomGenerator.Next(0, 3);
            switch ((PokerAction)action)
            {
                case PokerAction.Bet:
                    int bet = randomGenerator.Next(1, PlayField.Dealer.Chips + 1);
                    PlayField.ProcessBet(ref PlayField.Dealer, bet);
                    break;
                case PokerAction.Check:
                    WriteLine($"{PlayField.Dealer.Name} is checking this round");
                    break;
                case PokerAction.Fold:
                    WriteLine($"{PlayField.Dealer.Name} is folding, {Player.Name} wins this round");
                    PlayField.GivePotToWinner(ref PlayField.Gambler);
                    ResetHand();
                    break;
                default:
                    // This should never happen and is here to catch any edge cases
                    throw new ArgumentException("Invalid option chosen by the dealer");
                    break;
            } // switch ((PokerAction)action)
        } // method TakeDealerAction
    } // class Game
}
