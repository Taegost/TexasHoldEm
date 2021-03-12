using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldEm.Library
{
    // The hand evaluator I am using requires the hands to be passed in a specific way, so this class
    // maps my paradigm to theirs
    public static class CardMapper
    {

        public static string MapCard(Card card)
        {
            // Sometimes C# is a little funky about using the output of a conglomorate operation like this next line
            // so I tend to prefer to glom the value into a new variable, then use that variable by itself in the 
            // next call.
            string returnStr = $"{MapSuit(card.Suit)}{MapValue(card.Value)}";
            return returnStr;
        } // method MapCard

        private static string MapSuit(Suit suit)
        {
            switch (suit)
            {
                case Suit.Clubs:
                    return "CLB";
                    break;
                case Suit.Diamonds:
                    return "DMN";
                    break;
                case Suit.Hearts:
                    return "HRT";
                    break;
                case Suit.Spades:
                    return "SPD";
                    break;
                default:
                    return "UNK";
                    break;
            } // switch (suit)
        } // method MapSuit

        private static string MapValue(CardValue value)
        {
            switch (value)
            {
                case CardValue.Two:
                    return "02";
                    break;
                case CardValue.Three:
                    return "03";
                    break;
                case CardValue.Four:
                    return "04";
                    break;
                case CardValue.Five:
                    return "05";
                    break;
                case CardValue.Six:
                    return "06";
                    break;
                case CardValue.Seven:
                    return "07";
                    break;
                case CardValue.Eight:
                    return "08";
                    break;
                case CardValue.Nine:
                    return "09";
                    break;
                case CardValue.Ten:
                    return "10";
                    break;
                case CardValue.Jack:
                    return "KN";
                    break;
                case CardValue.Queen:
                    return "QU";
                    break;
                case CardValue.King:
                    return "KI";
                    break;
                case CardValue.Ace:
                    return "AC";
                    break;
                default:
                    return "UNK";
                    break;
            } // switch (value)
        } // method MapValue
    } // method CardMapper
}
