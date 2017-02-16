using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTraining
{
    /// <summary>
    /// This represents the 2 cards dealt to a player
    /// in Texas Hold'em.
    /// </summary>
    public class Pocket
    {
        #region Fields and Properties
        private List<Card> cardLis = new List<Card>();
        public List<Card> CardList 
        {
            get { return cardLis; } 
        }
        public Card this[int key]
        {
            get { return this.CardList[key]; }
            set { this.cardLis[key] = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Generates a 2 random cards different cards and adds them to cardLis
        /// </summary>
        public Pocket()
        {
            Card c1 = Card.GetRandom(), c2 = Card.GetRandom();
            while(c1.IsSame(c2))
            {
                c2 = Card.GetRandom();
            }
            this.cardLis.Add(c1);
            this.cardLis.Add(c2);
        }

        /// <summary>
        /// Generates a new pair of PocketCards for 2 random cards.
        /// Cards can will not include cards included in the unavailbCards
        /// </summary>
        public Pocket(List<Card> unavailbCards)
        {
            Card c1 = Card.GetRandom(), c2 = Card.GetRandom();
            while(c1.IsSame(unavailbCards))
            {
                c1 = Card.GetRandom();
            }
            unavailbCards.Add(c1);
            while(c2.IsSame(unavailbCards))
            {
                c2 = Card.GetRandom();
            }

            this.cardLis.Add(c1);
            this.cardLis.Add(c2);
        }

        public Pocket(Card c1, Card c2)
        {
            if(c1.IsSame(c2))
            {
                throw new Exception("Pocket cards cannot contain two of same card.");
            }
            else
            {
                this.cardLis.Add(c1);
                this.cardLis.Add(c2);
            }
        }

        #endregion

        #region public functions

        /// <summary>
        /// Returns a fraction value for the percentage chance of winning a hand,
        /// given the users hand the cards in the middle
        /// </summary>
        public double GetOddsWin(Community commCards)
        {
            int numSituationsWinning = 0, totSituations = 0, numPosDeals;
            List<Card> unavailbCards = new List<Card>(this.cardLis);
            unavailbCards.AddRange(commCards.CardList);

            Card c1 = new Card(Suit.clubs, Value.two);
            Card c2 = new Card(Suit.diamonds, Value.two);
            Pocket oppPocket = new Pocket(c1, c2);

            while (oppPocket[0] != null)
            {
                if (!oppPocket.Contains(unavailbCards))
                {
                    numSituationsWinning += GetNumChancesShouldPlay(oppPocket, commCards, out numPosDeals);
                    totSituations += numPosDeals;
                }

                oppPocket[1] = oppPocket[1].Next();
                if(oppPocket[1]==null)
                {
                    oppPocket[0] = oppPocket[0].Next();
                    if(oppPocket[0] != null)
                    {
                        oppPocket[1] = oppPocket[0].Next();
                    }
                }
            }

            return (double)numSituationsWinning / (double)totSituations;
        }


        #endregion

        #region private helper functions
        private int GetNumChancesShouldPlay(Pocket oppCards, Community commCards, out int numPosDeals)
        {
            int numChancesShouldPlay = 0;
            numPosDeals = 0;

            if (commCards.Count == 5)
            {
                if (!this.FindOutcome(oppCards,commCards).Equals(Outcome.Lose))
                { 
                    numChancesShouldPlay = 1;
                }
                numPosDeals = 1;
            }
            else
            {
                List<Card> unavailableCards = new List<Card>(this.CardList);
                unavailableCards.AddRange(oppCards.CardList);
                unavailableCards.AddRange(commCards.CardList);
                Card nextCommCard = Card.First(unavailableCards);
                int numPosSubDeals;
                while (nextCommCard != null)
                {
                    Community curMiddle = new Community(commCards);
                    curMiddle.Add(nextCommCard);
                    numChancesShouldPlay += GetNumChancesShouldPlay(oppCards, curMiddle, out numPosSubDeals);
                    numPosDeals += numPosSubDeals;
                    nextCommCard = nextCommCard.Next(unavailableCards);
                }
            }

            return numChancesShouldPlay;
        }

                
        /// <summary>
        /// Returns the outcome of this pocket playing against the opponents pocket
        /// </summary>
        /// <param name="oppCards"></param>
        /// <param name="commCards"></param>
        /// <returns></returns>
        private Outcome FindOutcome(Pocket oppCards, Community commCards)
        {
            Hand myHand = new Hand(this, commCards);
            Hand oppHand = new Hand(oppCards, commCards);
            
            return myHand.FindOutcome(oppHand);
        }


        private bool Contains(List<Card> unavailbCards)
        {
            foreach (Card c in unavailbCards)
            {
                if (this.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Returns true if PocketCards contains the specified card.
        /// </summary>
        private bool Contains(Card c)
        {
            foreach(Card pocketCard in this.CardList)
            {
                if(pocketCard.IsSame(c))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    };
};