using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BL
{
    public class Card
    {
        public  int value;
        public int suit;

        public object Suit { get; internal set; }

        public Card(int value, int suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public int getValue()
        {
            return value;
        }
        public bool IsFaceCard()
        {
            return value >= 11 && value <= 13;
        }
        public bool IsAce()
        {
            return value == 1;
        }
        public int getSuit()
        {
            return suit;
        }
        public string getValueAsString()
        {
            if (value == 1)
            {
                return "Ace";
            }
            else if (value == 11)
            {
                return "Jack";
            }
            else if (value == 12)
            {
                return "Queen";
            }
            else if (value == 13)
            {
                return "King";
            }
            else
            {
                return value.ToString();
            }
        }

        public string getSuitAsString()
        {
            if (suit == 1)
            {
                return "Clubs";
            }
            else if (suit == 2)
            {
                return "Diamonds";
            }
            else if (suit == 3)
            {
                return "Spades";
            }
            else
            {
                return "Hearts";
            }
        }

        public override string ToString()
        {
            return getValueAsString() + " of " + getSuitAsString();
        }


    }
}
