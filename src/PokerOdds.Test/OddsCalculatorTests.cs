using PokerOdds.Core;
using PokerOdds.Core.Models;

namespace PokerOdds.Test
{
    internal class OddsCalculatorTests
    {

        [Test]
        public void TestCalculator()
        {
            var cards = new List<Card>()
            {
                new Card(Enums.eSuit.clubs, Enums.eRank.two),
                new Card(Enums.eSuit.hearts, Enums.eRank.two),
                new Card(Enums.eSuit.clubs, Enums.eRank.three),
                new Card(Enums.eSuit.hearts, Enums.eRank.three),
                new Card(Enums.eSuit.clubs, Enums.eRank.four),
            };

            var result = OddsCalculator.GetHitCounts(cards);

            Assert.That(Constants.TOTAL_POSSIBLE_CARDS_2_LEFT == result[Enums.ePokerHand.TwoPair]);

        }
    }
}
