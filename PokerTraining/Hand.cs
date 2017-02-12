using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTraining
{
    public enum HandCat
    {
        highCard = 1,
        pair = 2,
        twoPair = 3,
        threeOfKind = 4,
        straight = 5,
        flush = 6,
        fullHouse = 7,
        fourOfKind = 8,
        straightFlush = 9,
    };

    public enum Outcome
    {
        Lose = -1,
        Tie = 0,
        Win = 1,
    };

    /// <summary>
    /// Represents a 5 card poker hand.
    /// flush, straight, full house, pair, etc...
    /// </summary>
    public class Hand
    {
        #region Properties
        public HandCat Category
        {
            get;
            private set;
        }

        public int Rank
        {
            get;
            private set;
        }
        #endregion

        #region Constructors
        public Hand(Pocket p, Community c) : this(Combine(p, c)) { }

        public Hand(List<Card> cardLis)
        {
            HandCat cat;
            int rank = -1;

            Suit suit;
            int[] countEachType = GetCountEachType(cardLis);

            if (HasFlush(cardLis, out suit))
            {
                countEachType = GetCountEachType(GetSuitedCards(cardLis, suit));

                if (HasStraight(countEachType, out rank))
                {
                    this.Category = HandCat.straightFlush;
                    this.Rank = rank;
                }
                else
                {
                    this.Category = HandCat.flush;
                    this.Rank = GetFlushRank(countEachType);
                }
            }
            else if (HasStraight(countEachType, out rank))
            {
                this.Category = HandCat.straight;
                this.Rank = rank;
            }
            else if (HasPair(countEachType, out cat))
            {
                this.Category = cat;
                this.Rank = GetRank(cat,countEachType);
            }
            else
            {
                this.Category = HandCat.highCard;
                this.Rank = GetHighCardRank(countEachType);
            }
        }

        #endregion

        #region Public Functions
        public int Beats(Hand oppHand)
        {
            if (this.Category > oppHand.Category)
            {
                return 1;
            }
            else if (this.Category < oppHand.Category)
            {
                return -1;
            }
            else if (this.Rank > oppHand.Rank)
            {
                return 1;
            }
            else if (this.Rank < oppHand.Rank)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Constructor Helpers


        private int GetFlushRank(int[] countEachType)
        {
            int rank = -1;
            double cardWeight = 5;
            for (int idx = 12; idx >= 0; idx--)
            {
                if (countEachType[idx] > 0)
                {

                    rank += (idx + 1) * (int)Math.Pow(13, cardWeight);
                    cardWeight--;
                }
                if (cardWeight == 0)
                {
                    break;
                }
            }

            return rank;
        }

        private bool HasPair(int[] countEachType, out HandCat cat)
        {
            cat = HandCat.highCard;
            bool done = false;

            for (int idx = 12; idx >= 0; idx--)
            {
                int curCount = countEachType[idx];
                switch (curCount)
                {
                    case 4:
                        cat = HandCat.fourOfKind;
                        done = true;
                        break;
                    case 3:
                        if (cat.Equals(HandCat.pair) || cat.Equals(HandCat.twoPair))
                        {
                            cat = HandCat.fullHouse;
                            done = true;
                        }
                        else if (cat.Equals(HandCat.highCard))
                        {
                            cat = HandCat.threeOfKind;
                        }
                        break;
                    case 2:
                        if (cat.Equals(HandCat.threeOfKind))
                        {
                            cat = HandCat.fullHouse;
                            done = true;
                        }
                        else if (cat.Equals(HandCat.pair))
                        {
                            cat = HandCat.twoPair;
                        }
                        else if (cat.Equals(HandCat.highCard))
                        {
                            cat = HandCat.pair;
                        }
                        break;
                    default:
                        break;
                }
                if (done)
                {
                    break;
                }
            }

            return !cat.Equals(HandCat.highCard);
        }

        /// <summary>
        /// Returns true if the list of cards contains a flush
        ///  sets the suit that contains the flush
        /// </summary>
        private bool HasFlush(List<Card> cardLis, out Suit flushSuit)
        {
            bool hasFlush = false;
            flushSuit = Suit.clubs;
            int[] suitCount = { 0, 0, 0, 0 };

            for (int idx = 0; idx < cardLis.Count; idx++)
            {
                suitCount[(int)cardLis[idx].GetSuit]++;
            }

            for (int idx = 0; idx < 4; idx++)
            {
                if (suitCount[idx] >= 5)
                {
                    hasFlush = true;
                    flushSuit = (Suit)idx;
                    break;
                }
            }

            return hasFlush;
        }


        /// <summary>
        /// Returns true if there are 5 cards in a row
        /// </summary>
        private bool HasStraight(int[] countEachType, out int rank)
        {
            bool hasStraight = false;
            rank = -1;

            int curNumInRow = 0;
            for (int idx = 0; idx < countEachType.Length; idx++)
            {
                if (countEachType[idx] > 0)
                {
                    curNumInRow++;
                }
                else
                {
                    curNumInRow = 0;
                }

                if (curNumInRow >= 5)
                {
                    hasStraight = true;
                    rank = idx;
                }
                else if (idx == 3 && curNumInRow == 4 && countEachType[12] > 0)
                {
                    hasStraight = true;
                    rank = idx;
                }
            }

            return hasStraight;
        }


        #region GetRank and Helpers
        /// <summary>
        /// Returns the rank for a HandCat for 4kind, fullhouse, threekind, 2pair or 1pair.
        /// </summary>
        private int GetRank(HandCat cat, int[] countEachType)
        {
            switch (cat)
            {
                case HandCat.fourOfKind:
                    return Get4KindRank(countEachType);
                case HandCat.fullHouse:
                    return GetFullHouseRank(countEachType);
                case HandCat.threeOfKind:
                    return Get3KindRank(countEachType);
                case HandCat.twoPair:
                    return Get2PairRank(countEachType);
                case HandCat.pair:
                    return Get1PairRank(countEachType);
                default:
                    throw new Exception("GetRank called with invalid cat of type '" + cat.ToString() + "'.");
            }
        }

        private int Get1PairRank(int[] countEachType)
        {
            int rankPair = -1, rankK1 = -1, rankK2 = -1, rankK3 = -1;
            for (int idx = 12; idx >= 0; idx--)
            {
                if (countEachType[idx] == 2 && rankPair < 0)
                {
                    rankPair = idx;
                }
                else if (countEachType[idx] == 1)
                {
                    if (rankK1 < 0)
                    {
                        rankK1 = idx;
                    }
                    else if (rankK2 < 0)
                    {
                        rankK2 = idx;
                    }
                    else if (rankK3 < 0)
                    {
                        rankK3 = idx;
                    }
                }

                if (rankPair > 0 && rankK1 > 0 && rankK2 > 0 && rankK3 > 0)
                {
                    break;
                }
            }
            return 13 * 13 * 13 * (rankPair + 1) + 13 * 13 * (rankK1 + 1) + 13 * (rankK2 + 1) + (rankK3 + 1);
        }

        private int Get2PairRank(int[] countEachType)
        {
            int rank2a = -1, rank2b = -1, rankK = -1;
            for (int idx = 12; idx >= 0; idx--)
            {
                if (countEachType[idx] == 2)
                {
                    if (rank2a < 0)
                    {
                        rank2a = idx;
                    }
                    else if (rank2b < 0)
                    {
                        rank2b = idx;
                    }
                }
                else if (countEachType[idx] == 1 && rankK < 0)
                {
                    rankK = idx;
                }

                if (rank2a > 0 && rank2b > 0 && rankK > 0)
                {
                    break;
                }
            }
            return 13 * 13 * (rank2a + 1) + 13 * (rank2b + 1) + (rankK + 1);
        }

        private int Get3KindRank(int[] countEachType)
        {
            int rank3 = -1, rankK1 = -1, rankK2 = -1;
            for (int idx = 12; idx >= 0; idx--)
            {
                if (countEachType[idx] == 3 && rank3 < 0)
                {
                    rank3 = idx;
                }
                else if (countEachType[idx] == 1)
                {
                    if (rankK1 < 0)
                    {
                        rankK1 = idx;
                    }
                    else if (rankK2 < 0)
                    {
                        rankK2 = idx;
                    }
                }

                if (rank3 > 0 && rankK1 > 0 && rankK2 > 0)
                {
                    break;
                }
            }
            return 13 * 13 * (rank3 + 1) + 13 * (rankK1 + 1) + (rankK2 + 1);
        }

        private int GetFullHouseRank(int[] countEachType)
        {
            int rank3 = -1, rank2 = -1;
            for (int idx = 12; idx >= 0; idx--)
            {
                if (countEachType[idx] == 3 && rank3 < 0)
                {
                    rank3 = idx;
                }
                else if (countEachType[idx] == 2 && rank2 < 0)
                {
                    rank2 = idx;
                }

                if (rank3 > 0 && rank2 > 0)
                {
                    break;
                }
            }
            return 13 * (rank3 + 1) + (rank2 + 1);
        }

        private int Get4KindRank(int[] countEachType)
        {
            int rank4 = -1, rankKicker = -1;
            for (int idx = 12; idx >= 0; idx--)
            {
                if (countEachType[idx] == 4)
                {
                    rank4 = idx;
                }
                else if (countEachType[idx] > 0 && rankKicker < idx)
                {
                    rankKicker = idx;
                }

                if (rank4 > 0 && rankKicker > 0)
                {
                    break;
                }
            }
            return 13 * (rank4 + 1) + (rankKicker + 1);
        }

        #endregion

        
        private int GetHighCardRank(int[] countEachType)
        {
            int rank = 0, kickerNum = 5;
            for (int idx = 12; idx >= 0; idx--)
            {
                if(countEachType[idx]>0)
                {
                    int weight = (int)Math.Pow(13, kickerNum);
                    rank += weight * (idx + 1);
                    kickerNum--;
                }
                if(kickerNum<1)
                {
                    break;
                }
            }

            return rank;
        }



        private List<Card> GetSuitedCards(List<Card> cardLis, Suit selSuit)
        {
            for (int idx = 0; idx < cardLis.Count; )
            {
                if (cardLis[idx].GetSuit.Equals(selSuit))
                {
                    idx++;
                }
                else
                {
                    cardLis.RemoveAt(idx);
                }
            }
            return cardLis;
        }

        private int[] GetCountEachType(List<Card> cardLis)
        {
            int[] countOfEachType = new int[13];
            for (int idx = 0; idx < 13; idx++)
            {
                countOfEachType[idx] = 0;
            }
            for (int idx = 0; idx < cardLis.Count; idx++)
            {
                Card c = cardLis[idx];
                countOfEachType[c.GetRank]++;
            }

            return countOfEachType;
        }



        private static List<Card> Combine(Pocket p, Community c)
        {
            List<Card> cardLis = new List<Card>(p.CardList);
            cardLis.AddRange(c.CardList);
            return cardLis;
        }

        /// <summary>
        /// Returns whether this hand will win/lose/tie w/ competitor's hand
        /// </summary>
        /// <param name="opponentHand"></param>
        /// <returns></returns>
        public Outcome Compare(Hand oppHand)
        {
            if (this.Category > oppHand.Category)
            {
                return Outcome.Win;
            }
            else if (this.Category < oppHand.Category)
            {
                return Outcome.Lose;
            }
            else if (this.Rank > oppHand.Rank)
            {
                return Outcome.Win;
            }
            else if (this.Rank < oppHand.Rank)
            {
                return Outcome.Lose;
            }
            else
            {
                return Outcome.Tie;
            }
        }
        #endregion
    };
};