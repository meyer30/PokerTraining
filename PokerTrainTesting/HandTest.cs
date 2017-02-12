using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerTraining;
using System.Collections.Generic;

namespace PokerTrainTesting
{
    [TestClass]
    public class HandTest
    {
        #region Fields

        static Hand
            strtFlushH1, strtFlushH2, strtFlushH3,
            fourKindH1, fourKindH2, fourKindH3,
            fullH1, fullH2, fullH3,
            flushH1, flushH2, flushH3,
            strtH1, strtH2, strtH3,
            threeH1, threeH2, threeH3,
            twoPH1, twoPH2, twoPH3,
            onePH1, onePH2, onePH3,
            highH1, highH2, highH3;
        #endregion

        #region initializers

        [ClassInitialize]
        public static void InitHandTest(TestContext t)
        {
            InitStraightFlushHands();

            InitFourKindHands();

            InitFullHouseHands();

            InitFlushHands();

            InitStraightHands();

            InitThreeKindHands();

            Init2PairHands();

            InitOnePairHands();

            InitHighCardHands();
        }


        #region InitHandTest Helpers

        private static void InitStraightFlushHands()
        {
            strtFlushH1 = new Hand(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,
                TestData.TenClubs,
                TestData.NineClubs,
                                TestData.EightDiamonds
            });

            strtFlushH2 = new Hand(new List<Card>()
            {
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,
                TestData.TenClubs,
                TestData.NineClubs,
                                TestData.EightDiamonds
            });
            strtFlushH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs,
                TestData.QueenClubs,

                TestData.FiveClubs,
                TestData.FourClubs,
                TestData.ThreeClubs,
                TestData.TwoClubs
            });

        }

        private static void InitFourKindHands()
        {
            fourKindH1 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts, TestData.AceSpades,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs
            });
            fourKindH2 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts, TestData.AceSpades,
                
                TestData.QueenClubs,
                TestData.JackClubs,
                TestData.NineDiamonds
            });
            fourKindH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs, TestData.KingDiamonds, TestData.KingHearts, TestData.KingSpades,
                TestData.QueenClubs,
                TestData.JackClubs
            });
        }

        private static void InitFullHouseHands()
        {
            fullH1 = new Hand(new List<Card>()
                {
                    TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                    TestData.KingClubs, TestData.KingDiamonds,
                    TestData.QueenClubs,
                    TestData.JackClubs
                });
            fullH2 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,
                TestData.QueenClubs, TestData.QueenDiamonds,
                TestData.JackClubs
            });
            fullH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds,
                TestData.KingClubs,TestData.KingDiamonds,TestData.KingHearts,
                TestData.QueenClubs,
                TestData.JackClubs
            });
        }

        private static void InitFlushHands()
        {
            flushH1 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,

                TestData.NineClubs,
            });
            flushH2 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,
                ///
                ///
                TestData.TwoClubs,
            });
            flushH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,
                TestData.QueenClubs,

                TestData.TenClubs,
                TestData.NineClubs,
            });
        }

        private static void InitStraightHands()
        {
            strtH1 = new Hand(new List<Card>()
            {
                                    TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,TestData.KingDiamonds,
                TestData.QueenClubs,
                TestData.JackClubs,
                TestData.TenClubs
            });
            strtH2 = new Hand(new List<Card>()
            {
                TestData.KingClubs,TestData.KingDiamonds,
                TestData.QueenClubs,
                TestData.JackClubs,
                TestData.TenClubs,
                                  TestData.NineDiamonds
            });
            strtH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                

                TestData.FiveDiamonds,
                TestData.FourClubs,
                TestData.ThreeClubs,
                TestData.TwoClubs,
            });
        }

        private static void InitThreeKindHands()
        {
            threeH1 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,
                ///

                                TestData.FiveDiamonds,
            });
            threeH2 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds, TestData.AceHearts,
                TestData.KingClubs,
                
                TestData.JackClubs,
                TestData.TenClubs,
                                    TestData.NineDiamonds
            });
            threeH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs,TestData.KingDiamonds, TestData.KingHearts,
                
                TestData.JackClubs,
                TestData.TenClubs,
                                    TestData.NineDiamonds
            });
        }

        private static void Init2PairHands()
        {
            twoPH1 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds,
                TestData.KingClubs,TestData.KingDiamonds,
                TestData.QueenClubs,
                                    TestData.JackDiamonds,

                ///
                TestData.TwoClubs
            });
            twoPH2 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds,
                TestData.KingClubs,TestData.KingDiamonds,

                TestData.JackClubs,
                                    TestData.TenDiamonds,
                TestData.NineClubs
            });
            twoPH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs,TestData.KingDiamonds,
                TestData.QueenClubs,TestData.QueenDiamonds,
                TestData.JackClubs,

                                    TestData.NineDiamonds
            });
        }

        private static void InitOnePairHands()
        {
            onePH1 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,

                                    TestData.NineDiamonds,
                                    TestData.EightDiamonds,
            });
            onePH2 = new Hand(new List<Card>()
            {
                TestData.AceClubs, TestData.AceDiamonds,
                TestData.KingClubs,
                TestData.QueenClubs,

                TestData.TenClubs,
                                    TestData.NineDiamonds,
                                    TestData.EightDiamonds,
            });
            onePH3 = new Hand(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs,TestData.KingDiamonds,
                TestData.QueenClubs,
                TestData.JackClubs,

                                    TestData.NineDiamonds,
                                    TestData.EightDiamonds,
            });
        }

        private static void InitHighCardHands()
        {
            highH1 = new Hand(new List<Card>()
            {
                                    TestData.AceDiamonds,
                TestData.KingClubs,
                TestData.QueenClubs,
                TestData.JackClubs,

                                    TestData.NineDiamonds,
                                    TestData.EightDiamonds,
                ///
                TestData.TwoClubs,
            });
            highH2 = new Hand(new List<Card>()
            {
                                    TestData.AceDiamonds,

                                    TestData.QueenDiamonds,
                TestData.JackClubs,
                TestData.TenClubs,
                                    TestData.NineDiamonds,
                ///
                TestData.ThreeClubs,
                TestData.TwoClubs,
            });
            highH3 = new Hand(new List<Card>()
            {
                ///
                                    TestData.KingDiamonds,
                                    TestData.QueenDiamonds,
                TestData.JackClubs,
                TestData.TenClubs,
                                    TestData.EightDiamonds,
                ///
                TestData.ThreeClubs,
                TestData.TwoClubs,
            });
        }
        #endregion

        #endregion

        #region Test Methods
        [TestMethod]
        public void Knows_StraightFlush()
        {
            Assert.AreEqual(HandCat.straightFlush, strtFlushH1.Category);
            Assert.AreEqual(HandCat.straightFlush, strtFlushH2.Category);
            Assert.AreEqual(HandCat.straightFlush, strtFlushH3.Category);
        }

        [TestMethod]
        public void Ranks_StraightFlush()
        {
            Assert.IsTrue(strtFlushH1.Rank > strtFlushH2.Rank);
            Assert.IsTrue(strtFlushH2.Rank > strtFlushH3.Rank);
        }

        [TestMethod]
        public void Knows_FourOfKind()
        {
            Assert.AreEqual(HandCat.fourOfKind, fourKindH1.Category);
            Assert.AreEqual(HandCat.fourOfKind, fourKindH2.Category);
            Assert.AreEqual(HandCat.fourOfKind, fourKindH3.Category);
        }

        [TestMethod]
        public void Ranks_FourOfKind()
        {
            Assert.IsTrue(fourKindH1.Rank > fourKindH2.Rank);
            Assert.IsTrue(fourKindH2.Rank > fourKindH3.Rank);
        }


        [TestMethod]
        public void Knows_FullHouse()
        {
            Assert.AreEqual(HandCat.fullHouse, fullH1.Category);
            Assert.AreEqual(HandCat.fullHouse, fullH2.Category);
            Assert.AreEqual(HandCat.fullHouse, fullH3.Category);
        }


        [TestMethod]
        public void Ranks_FullHouse()
        {
            Assert.IsTrue(fullH1.Rank > fullH2.Rank);
            Assert.IsTrue(fullH2.Rank > fullH3.Rank);
        }

        [TestMethod]
        public void Knows_Flush()
        {
            Assert.AreEqual(HandCat.flush, flushH1.Category);
            Assert.AreEqual(HandCat.flush, flushH2.Category);
            Assert.AreEqual(HandCat.flush, flushH3.Category);
        }


        [TestMethod]
        public void Ranks_Flush()
        {
            Assert.IsTrue(flushH1.Rank > flushH2.Rank);
            Assert.IsTrue(flushH2.Rank > flushH3.Rank);
        }

        [TestMethod]
        public void Knows_Straight()
        {
            Assert.AreEqual(HandCat.straight, strtH1.Category);
            Assert.AreEqual(HandCat.straight, strtH2.Category);
            Assert.AreEqual(HandCat.straight, strtH3.Category);
        }

        [TestMethod]
        public void Ranks_Straight()
        {
            Assert.IsTrue(strtH1.Rank > strtH2.Rank);
            Assert.IsTrue(strtH2.Rank > strtH3.Rank);
        }

        [TestMethod]
        public void Knows_ThreeOfKind()
        {
            Assert.AreEqual(HandCat.threeOfKind, threeH1.Category);
            Assert.AreEqual(HandCat.threeOfKind, threeH2.Category);
            Assert.AreEqual(HandCat.threeOfKind, threeH3.Category);
        }

        [TestMethod]
        public void Ranks_ThreeOfKind()
        {
            Assert.IsTrue(threeH1.Rank > threeH2.Rank);
            Assert.IsTrue(threeH2.Rank > threeH3.Rank);
        }

        [TestMethod]
        public void Knows_TwoPair()
        {
            Assert.AreEqual(HandCat.twoPair, twoPH1.Category);
            Assert.AreEqual(HandCat.twoPair, twoPH2.Category);
            Assert.AreEqual(HandCat.twoPair, twoPH3.Category);
        }


        [TestMethod]
        public void Ranks_TwoPair()
        {
            Assert.IsTrue(twoPH1.Rank > twoPH2.Rank);
            Assert.IsTrue(twoPH2.Rank > twoPH3.Rank);
        }

        [TestMethod]
        public void Knows_Pair()
        {
            Assert.AreEqual(HandCat.pair, onePH1.Category);
            Assert.AreEqual(HandCat.pair, onePH2.Category);
            Assert.AreEqual(HandCat.pair, onePH3.Category);
        }


        [TestMethod]
        public void Ranks_Pair()
        {
            Assert.IsTrue(onePH1.Rank > onePH2.Rank);
            Assert.IsTrue(onePH2.Rank > onePH3.Rank);
        }

        [TestMethod]
        public void Knows_HighCard()
        {
            Assert.AreEqual(HandCat.highCard, highH1.Category);
            Assert.AreEqual(HandCat.highCard, highH2.Category);
            Assert.AreEqual(HandCat.highCard, highH3.Category);
        }


        //[TestMethod]
        //public void Ranks_HighCard()
        //{
            

        //}

        [TestMethod]
        public void HighCard_Compare()
        {
            Assert.AreSame(highH1.Compare(strtFlushH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(fourKindH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(flushH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(strtH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(threeH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(twoPH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(onePH1), Outcome.Lose);
            Assert.AreSame(highH1.Compare(highH2), Outcome.Win);
            Assert.AreSame(highH2.Compare(highH3), Outcome.Win);
        }
        #endregion
    };
};