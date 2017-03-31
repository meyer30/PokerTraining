using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTraining
{
    /// <summary>
    /// Cards that go in the middle that all player use in Texas hold'em.
    /// </summary>
    public class Community
    {
        #region properties and fields
        private List<Card> cardLis = new List<Card>();

        public List<Card> CardList
        {
            get { return cardLis; }
        }

        public int Count
        {
            get { return cardLis.Count; }
        }

        public Card this[int key]
        {
            get { return this.CardList[key]; }
            set { this.cardLis[key] = value; }
        }
        #endregion

        #region Constructors
        public Community() {}

        public Community(Community c)
        {
            cardLis.AddRange(c.cardLis);
        }
        

        public Community(List<Card> cards)
        {
            this.Add(cards);
        }

        /// <summary>
        /// Creates the CommunityCards based on the unavailableCards and 
        ///  the number of communityCards needed for the list to contain.
        /// </summary>
        /// <param name="unavailableCards"></param>
        /// <param name="numCommCards"></param>
        public Community(List<Card> unavailableCards, int numCommCards)
        {
            unavailableCards = new List<Card>(unavailableCards);
            for(int idx=0; idx<numCommCards; idx++)
            {
                Card c = Card.GetRandom();
                while(c.IsIn(unavailableCards))
                {
                    c = Card.GetRandom();
                }
                this.Add(c);
                unavailableCards.Add(c);
            }
        }


        #endregion

        #region Public Functions
        /// <summary>
        /// Returns the first combonation of CommunityCards
        ///  given the unavailableCards
        /// </summary>
        public Community First(List<Card> unavailableCards)
        {
            Community community = new Community(this);
            Card c = new Card(Suit.clubs, Rank.two);

            while (community.Count < 5)
            {
                while (c.IsIn(unavailableCards))
                {
                    c = c.Next();
                }
                community.Add(c);
                c = c.Next();
            }

            return community;
        }
        
        public void Add(Card nextCard)
        {
            cardLis.Add(nextCard);
        }



        #endregion


        private void Add(List<Card> list)
        {
            this.CardList.AddRange(list);
        }
    };
};