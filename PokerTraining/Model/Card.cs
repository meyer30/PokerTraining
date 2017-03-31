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

    public enum Rank
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
        private Suit mySuit;
        private Rank myRank;
        
        public Suit Suit
        {
            get { return this.mySuit; }
        }

        public Rank Rank
        {
            get { return this.myRank; }
            set { this.myRank = value; }
        }

        public int ZeroBasedRank
        {
            get { return (int)this.myRank - 2; }
        }

        /// <summary>
        /// Used for building database
        /// </summary>
        public new String ToString
        {
            get { return this.myRank.ToString() + this.mySuit.ToString(); }
        }
        #endregion

        #region Constructors
        public Card() { }
        
        public Card(Suit suit, Rank value)
        {
            this.mySuit = suit;
            this.myRank = value;
        }
        #endregion

        #region Static Constructors

        public Card Next(List<Card> unavailbCards)
        {
            Card nextCard = this.Next();
            while (nextCard != null && nextCard.IsIn(unavailbCards))
            {
                nextCard = nextCard.Next();
            }
            return nextCard;
        }


        /// <summary>
        /// Sets the card to the next value or suit or null
        /// based on order
        /// </summary>
        internal Card Next()
        {
            if (this.myRank != PokerTraining.Rank.ace)
            {
                this.myRank++;
            }
            else if (this.mySuit != Suit.spades)
            {
                this.myRank = PokerTraining.Rank.two;
                this.mySuit++;
            }
            else
            {
                return null;
            }

            return this;
        }

        /// <summary>
        /// Returns a randomn card in the 52 card deck that is also not in cLis
        /// </summary>
        internal static Card GetRandom(List<Card> unavailCards)
        {
            Card c = Card.GetRandom();
            while (c.IsIn(unavailCards))
            {
                c = Card.GetRandom();
            }
            return c;
        }


        /// <summary>
        /// Returns a randomn card in the 52 card deck
        /// </summary>
        internal static Card GetRandom()
        {
            Random rand = new Random();
            Suit s = (Suit) rand.Next(0,3);
            Rank v = (Rank)rand.Next(2, 14);
            return new Card(s, v);
        }
        

        /// <summary>
        /// Returns a the first card that is also not in the unavailableCards
        /// </summary>
        internal static Card First(List<Card> unavailableCards)
        {
            Card firstCard = new Card(Suit.clubs, PokerTraining.Rank.two);
            while (firstCard.IsIn(unavailableCards))
            {
                firstCard = firstCard.Next(unavailableCards);
            }
            return firstCard;
        }
        #endregion

        #region Public Functions
        public bool IsIn(List<Card> cardList)
        {
            foreach (Card curCard in cardList)
            {
                if (this.IsSame(curCard))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if the other card is the same.
        /// </summary>
        public bool IsSame(Card otherCard)
        {
            if (this.myRank != otherCard.Rank)
            {
                return false;
            }
            else if(this.mySuit != otherCard.mySuit)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    };
};
