using System;
using System.Collections.Generic;
using System.Text;

namespace TexasHoldEm.Library
{
    public class Player
    {
        public string Name { get; set; }
        public int Chips { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Player(string name, int chips)
        {
            Name = name;
            Chips = chips;
        } // constructor

        public void NewHand()
        {
            Hand = new List<Card>();
        } // method NewHand

        public void AcceptCard(Card newCard)
        {
            // With this application, the exception criteria should never be reached, so if it is, it is a true exception
            if (Hand.Count == 3) { throw new ArgumentOutOfRangeException("The player already has 3 cards and can not have any more"); }
            Hand.Add(newCard);
        } // method AcceptCard

        public bool HasCards()
        {
            return Hand.Count > 0;
        } // method HasCards

        public bool PayOut(int amount)
        {
            if (Chips - amount >= 0)
            {
                Chips -= amount;
                return true;
            }
            else
            { return false; }
        } // method PayOut

        public void AcceptChips(int payout)
        {
            Chips += payout;
        } // method AcceptChips

        public string ShowHand()
        {
            string returnStr = "";
            if (Hand.Count > 0)
            {
                foreach (Card card in Hand)
                { returnStr += $"{card.ToString()}\n"; }
            }
            else
            {
                returnStr = "No cards in hand";
            }
            return returnStr.Trim();
        } // method ShowHand

        public override string ToString()
        {
            string returnStr = $"{Name} has {Chips} chips and {Hand.Count} card(s) in hand.";
            return returnStr;
        } // method ToString
    } // class Player
}
