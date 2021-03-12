using System;
using System.Collections.Generic;
using System.Text;

namespace TexasHoldEm.Library
{
    public class Card
    {
        public Suit Suit { get; set; }
        public CardValue Value { get; set; }

        public Card (Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        } // constructor

        public override string ToString()
        {
            return $"{Value.ToString()} of {Suit.ToString()}";
        }
    } // class Card
}
