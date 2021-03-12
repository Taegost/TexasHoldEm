using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldEm.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEm.Library.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        Player testPlayer = new Player("Test", 50);

        [TestMethod()]
        public void PlayerTest()
        {
            string expectedResult = "Test has 50 chips and 0 cards in hand.";
            Assert.AreEqual(expectedResult, testPlayer.ToString());
        } // test PlayerTest

        [TestMethod()]
        public void NewHandTest()
        {
            Player newHandTestPlayer = testPlayer;
            newHandTestPlayer.Hand.Add(new Card(Suit.Clubs, CardValue.Ace));
            newHandTestPlayer.NewHand();
            Assert.AreEqual(0, newHandTestPlayer.Hand.Count);
        } // test NewHandTest

        [TestMethod()]
        public void AcceptCardTest_POS()
        {
            Player acceptCardPlayer = testPlayer;
            acceptCardPlayer.AcceptCard(new Card(Suit.Clubs, CardValue.Ace));
            Assert.AreEqual(1, acceptCardPlayer.Hand.Count);
        } // test AcceptCardTest_POS

        [TestMethod()]
        public void AcceptCardTest_NEG()
        {
            Player acceptCardPlayer = testPlayer;
            acceptCardPlayer.AcceptCard(new Card(Suit.Clubs, CardValue.Ace));
            acceptCardPlayer.AcceptCard(new Card(Suit.Clubs, CardValue.Ace));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acceptCardPlayer.AcceptCard(new Card(Suit.Clubs, CardValue.Ace)));
        } // test AcceptCardTest_NEG

        [TestMethod()]
        public void PayOutTest_POS()
        {
            Player payoutPlayer = testPlayer;
            bool returnValue = payoutPlayer.PayOut(25);
            Assert.AreEqual(25, payoutPlayer.Chips);
            Assert.AreEqual(true, returnValue);
        } // test PayOutTest_POS

        [TestMethod()]
        public void PayOutTest_NEG()
        {
            Player payoutPlayer = testPlayer;
            bool returnValue = payoutPlayer.PayOut(51);
            Assert.AreEqual(50, payoutPlayer.Chips);
            Assert.AreEqual(false, returnValue);
        } // test PayOutTest_NEG

        [TestMethod()]
        public void AcceptChipsTest()
        {
            Player acceptChipsPlayer = testPlayer;
            acceptChipsPlayer.AcceptChips(25);
            Assert.AreEqual(75, acceptChipsPlayer.Chips);
        } // test AcceptChipsTest

        [TestMethod()]
        public void ShowHandTest_Empty()
        {
            Player showHandTestPlayer = testPlayer;
            string expectedResult = "No cards in hand";
            Assert.AreEqual(expectedResult, showHandTestPlayer.ShowHand()) ;
        } // test ShowHandTest_Empty

        [TestMethod()]
        public void ShowHandTest_OneCard()
        {
            Player showHandTestPlayer = testPlayer;
            showHandTestPlayer.AcceptCard(new Card(Suit.Clubs, CardValue.Ace));
            string expectedResult = "Ace of Clubs\n";
            Assert.AreEqual(expectedResult, showHandTestPlayer.ShowHand());
        } // test ShowHandTest_OneCard
    }
}