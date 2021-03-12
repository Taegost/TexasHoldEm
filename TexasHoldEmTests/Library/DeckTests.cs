using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TexasHoldEm.Library.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void CorrectCardCount()
        {
            Deck deck = new Deck();
            Assert.AreEqual(52, deck.Cards.Count);
        } // test CorrectCardCount

        [TestMethod()]
        public void ShuffleTest()
        {
            Deck deck = new Deck();
            List<Card> originalList = deck.Cards.ToList();
            deck.Shuffle();
            Assert.IsFalse(originalList.SequenceEqual(deck.Cards));
        } // test ShuffleTest
    }
}