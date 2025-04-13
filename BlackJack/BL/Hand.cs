using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BL
{
    public class Hand
    {
        private List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }
        public void Clear()
        {
            cards.Clear();
        }
        public void AddCard(Card c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c), "Cards cannot be Null");
            }
            cards.Add(c);
        }
        public void RemoveCard(Card c)
        {
            if (c == null)
            {
                throw new ArgumentNullException(nameof(c), "Cards cannot be Null");
            }
            cards.Remove(c);
        }
        public void RemoveCard(int position)
        {
            if (position < 0 || position >= cards.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
            }
            cards.RemoveAt(position);
        }
        public int GetCardCount()
        {
            return cards.Count;
        }
        public Card GetCard(int position)
        {
            if (position < 0 || position >= cards.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
            }
            return cards[position];
        }
        public void SortBySuit()
        {
            cards.Sort((card1, card2) =>
            {
                int suitComparison = card1.suit.CompareTo(card2.Suit);
                if (suitComparison != 0)
                {
                    return suitComparison;
                }
                return card1.value.CompareTo(card2.value);
            });
        }
        public void SortByValue()
        {
            cards.Sort((card1, card2) => card1.value.CompareTo(card2.value));
        }
        public virtual int getCardCount()
        {
            int value = 0;
            int aceCount = 0;
            foreach (var card in cards)
            {
                if (card.IsAce())
                {
                    aceCount++;
                    value += 11;
                }
                else if (card.IsFaceCard())
                {
                    value += 10;
                }
                else
                {
                    value += card.value;
                }
            }
            while (value > 21 && aceCount > 0)
            {
                value -= 10; 
                aceCount--;
            }

            return value;
        }
        public bool IsBust()
        {
            return getCardCount() > 21;
        }
        public bool IsBlackjack()
        {
            return cards.Count == 2 && GetCardCount() == 21;
        }
      
       
        public class BlackjackHand : Hand
        {
    private int val;
    private bool ace;
    private int card;

    public BlackjackHand()
    {
        val = 0;
        ace = false;
        card = getCardCount();
    }

    public int getBlackjackValue()
    {
        val = 0;
        ace = false;

        for (int i = 0; i < getCardCount(); i++)
        {
            Card card = GetCard(i);
            int cardValue = card.getValue();

            if (card.IsAce())
            {
                val += 11;
                ace = true;
            }
            else if (card.IsFaceCard())
            {
                val += 10;
            }
            else
            {
                val += cardValue;
            }
        }

            while (val > 21 && ace)
            {
            val -= 10;
            ace = false;
            }

             return val;
        }
    }
        public override string ToString()
        {
            return string.Join(" ", cards);
        }
    }
}

