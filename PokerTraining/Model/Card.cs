using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTraining
{
    public enum Suit
    {
        clubs = 0,
        diamonds = 1,
        hearts = 2,
        spades = 3,
    }

    public enum Value
    {
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
        jack = 11,
        queen = 12,
        king = 13,
        ace = 14,
    }


    /// <summary>
    /// Represents a Card in the 52 card deck.
    /// </summary>
    public class Card
    {
        #region Fields and Properties
        private Suit s;
        private Value v;


        public int GetRank
        {
            get { return (int)this.v - 2; }
        }

        public Suit GetSuit 
        { 
            get { return this.s; }
        }
        #endregion

        #region Constructors
        public Card() { }
        
        public Card(Suit suit, Value value)
        {
            this.s = suit;
            this.v = value;
        }
        #endregion

        #region Static Constructors
        /// <summary>
        /// Sets the card to the next value or suit or null
        /// based on order
        /// </summary>
        internal Card Next()
        {
            if (this.v != Value.ace)
            {
                this.v++;
            }
            else if (this.s != Suit.spades)
            {
                this.v = Value.two;
                this.s++;
            }
            else
            {
                return null;
            }

            return this;
        }

        /// <summary>
        /// Returns a randomn card in the 52 card deck
        /// </summary>
        internal static Card GetRandom()
        {
            Random rand = new Random();
            Suit s = (Suit) rand.Next(0,3);
            Value v = (Value)rand.Next(2, 14);
            return new Card(s, v);
        }

        /// <summary>
        /// Returns a randomn card in the 52 card deck that is also not in cLis
        /// </summary>
        internal static Card GetRandom(List<Card> unavailCards)
        {
            Card c = Card.GetRandom();
            while (c.IsSame(unavailCards))
            {
                c = Card.GetRandom();
            }
            return c;
        }

        internal Card Next(List<Card> unavailbCards)
        {
            Card nextCard = this.Next();
            while (nextCard != null && nextCard.IsSame(unavailbCards))
            {
                nextCard = nextCard.Next();
            }
            return nextCard;
        }

        /// <summary>
        /// Returns a the first card that is also not in the unavailableCards
        /// </summary>
        internal static Card First(List<Card> unavailableCards)
        {
            Card firstCard = new Card(Suit.clubs, Value.two);
            while (firstCard.IsSame(unavailableCards))
            {
                firstCard = firstCard.Next(unavailableCards);
            }
            return firstCard;
        }
        #endregion

        #region Public Functions
        public bool IsSame(List<Card> unavailbCards)
        {
            foreach (Card c in unavailbCards)
            {
                if (this.IsSame(c))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if the given card is the same.
        /// </summary>
        public bool IsSame(Card c)
        {
            return (this.s == c.s && this.v == c.v);
        }
        #endregion
    };
};
