using System;
using System.Collections.Generic;
using System.Text;

namespace TexasHoldEm.Library
{
    public class Deck
    {
        private static Random random = new Random();

        public List<Card> Cards { get; set; } = new List<Card>();
        private int DealtIndex { get; set; } = 0;

        public Deck()
        {
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (CardValue value in (CardValue[])Enum.GetValues(typeof(CardValue)))
                {
                    Cards.Add(new Card(suit, value));
                } // foreach (CardValues value in (CardValues[])Enum.GetValues(typeof(CardValues)))
            } // foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
        } // constructor

        public void Shuffle()
        {
            DealtIndex = 0;
            for (int i = Cards.Count - 1; i > 0; --i)
            {
                int k = random.Next(i + 1);
                Card tempCard = Cards[i];
                Cards[i] = Cards[k];
                Cards[k] = tempCard;
            } // for (int i = Cards.Count - 1; i > 0; --i)
        } // method Shuffle

        public Card DealCard()
        {
            // With this application, the exception criteria should never be reached, so if it is, it is a true exception
            if (DealtIndex == Cards.Count - 1) { throw new ArgumentOutOfRangeException("There are no more un-dealt cards, please shuffle the deck before proceeding."); }
            Card nextCard = Cards[DealtIndex];
            DealtIndex++;
            return nextCard;
        } // method DealCard
    } // class Deck
}
