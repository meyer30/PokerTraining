using PokerOdds.Core.Models;
using static PokerOdds.Core.Enums;

namespace PokerOdds.Core
{
    public class OddsCalculator
    {
        public static HitProbablitities GetProbablitities(HitCounts counts, int totalNumCards)
        {
            HitProbablitities hitProbablitities = new HitProbablitities();

            foreach (PokerHand hand in Enum.GetValues<PokerHand>())
            {
                hitProbablitities[hand] = (double)counts[hand] / (double)totalNumCards * 100;
            }

            return hitProbablitities;
        }

        public static HitCounts GetHitCounts(List<Card> curCards)
        {
            HitCounts results = new HitCounts();

            var remainingCards = CardRepository.Deck.Where(d => !curCards.Contains(d)).ToArray();

            var countEachType = GetCountOfEachRank(curCards);

            int numPossiblities = 0;

            for (int turnCardIdx = 0; turnCardIdx < remainingCards.Length - 1; turnCardIdx++)
            {
                Card turnCard = remainingCards[turnCardIdx];

                countEachType[turnCard.ZeroBaseRank]++;

                for (int riverCardIdx = turnCardIdx + 1; riverCardIdx < remainingCards.Length; riverCardIdx++)
                {
                    Card riverCard = remainingCards[riverCardIdx];

                    countEachType[riverCard.ZeroBaseRank]++;

                    if (IsFlush(curCards, turnCard, riverCard))
                        results[PokerHand.Flush]++;

                    if (IsStraight(countEachType))
                        results[PokerHand.Straight]++;

                    if (IsPair(countEachType))
                    {
                        results[PokerHand.Pair]++;

                        if (IsTwoPair(countEachType))
                            results[PokerHand.TwoPair]++;

                        if (IsFullHouse(countEachType))
                        {
                            results[PokerHand.FullHouse]++;
                            results[PokerHand.ThreeOfAKind]++;
                        }
                    }
                    if (Is3ofAKind(countEachType))
                        results[PokerHand.ThreeOfAKind]++;

                    if (Is4ofAKind(countEachType))
                        results[PokerHand.FourOfAKind]++;

                    countEachType[riverCard.ZeroBaseRank]--;

                    numPossiblities++;
                }

                countEachType[turnCard.ZeroBaseRank]--;
            }

            return results;
        }

        private static bool IsFlush(List<Card> curCards, Card p1, Card p2)
        {
            int[] suitCount = { 0, 0, 0, 0 };

            for (int idx = 0; idx < curCards.Count; idx++)
            {
                suitCount[(int)curCards[idx].Suit]++;
            }

            suitCount[(int)p1.Suit]++;
            suitCount[(int)p2.Suit]++;

            return suitCount.Any(s => s >= 5);
        }

        private static bool IsStraight(int[] countEachType)
        {
            //first there is an ace, start count at 0.
            int curNumInRow = (countEachType[12] > 0) ? 1 : 0;

            for (int idx = 0; idx < countEachType.Length; idx++)
            {
                if (countEachType[idx] > 0)
                    curNumInRow++;
                else
                    curNumInRow = 0;

                if (curNumInRow >= 5)
                    return true;
            }

            return false;
        }

        private static bool IsPair(int[] cntOfEachRank) =>
            cntOfEachRank.Any(s => s == 2);
        
        private static bool Is3ofAKind(int[] cntOfEachRank) => 
            cntOfEachRank.Any(s => s == 3);

        private static bool Is4ofAKind(int[] cntOfEachRank) => 
            cntOfEachRank.Any(s => s == 4);      

        private static bool IsFullHouse(int[] cntOfEachRank) =>
            IsPair(cntOfEachRank) && Is3ofAKind(cntOfEachRank);

        private static bool IsTwoPair(int[] cntOfEachRank) => 
            cntOfEachRank.Where(s => s == 2).Count() >= 2;
        

        /// <summary>
        /// Returns 0 based rank count.  
        /// Index 0 represents 2card
        /// Index 12 represents ace
        /// </summary>
        /// <param name="cardLis"></param>
        /// <returns></returns>
        private static int[] GetCountOfEachRank(List<Card> cardLis)
        {
            int[] countOfEachRank = new int[13];

            for (int curRank = 0; curRank < 13; curRank++)
            {
                countOfEachRank[curRank] = 0;
            }

            for (int idx = 0; idx < cardLis.Count; idx++)
                countOfEachRank[(int)cardLis[idx].ZeroBaseRank]++;

            return countOfEachRank;
        }
    }
}
