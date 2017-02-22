using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerTraining;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTrainTesting
{
    [TestClass]
    public class PocketTest
    {
        static Pocket p;
        static Community c;
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize]
        public static void InitHandTest(TestContext t)
        {
            p = new Pocket(TestData.JackClubs, TestData.JackDiamonds);
            c = new Community(new List<Card>()
            {
                TestData.AceClubs,
                TestData.KingClubs,
                TestData.KingDiamonds,
            });
        }

        [TestMethod]
        public void OneOpponentTest()
        {
            double calcOddsWinning = p.GetOddsWin(c, 1);
            double actualOddsWinning = .7319 + .031;
            double dif = Math.Abs(actualOddsWinning - calcOddsWinning);

            Assert.IsTrue(isWithin2Percent(actualOddsWinning, calcOddsWinning));
        }

        [TestMethod]
        public void TwoOpponentTest()
        {
            double calcOddsWinning = p.GetOddsWin(c, 2);
            double actualOddsWinning = .5559 + .0303;
            double dif = Math.Abs(actualOddsWinning - calcOddsWinning);

            Assert.IsTrue(isWithin2Percent(actualOddsWinning, calcOddsWinning));
        }


        private bool isWithin2Percent(double actualOdds, double calcOdds)
        {
            if ((Math.Abs(actualOdds - calcOdds) < .02))
            {
                return true;
            }
            else
            {
                TestContext.WriteLine("Message...");

                Debug.WriteLine(actualOdds + " " + calcOdds);
                return false;
                
            }
        }
    }
}
