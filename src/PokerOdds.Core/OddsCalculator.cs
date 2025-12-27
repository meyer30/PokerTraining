using PokerOdds.Core.Models;
using static PokerOdds.Core.Enums;

namespace PokerOdds.Core
{
    public class OddsCalculator
    {
        public static HitProbablitities GetProbablitities(HitCounts counts, int totalNumCards)
        {
            HitProbablitities hitProbablitities = new HitProbablitities();

            foreach (ePokerHand hand in Enum.GetValues<ePokerHand>())
            {
                hitProbablitities[hand] = (double)counts[hand] / (double)totalNumCards * 100;
            }

            return hitProbablitities;
        }

        public static HitCounts GetHitCounts(List<Card> curCards)
        {
            HitCounts results = new HitCounts();

            var remainingCards = CardRepository.Deck.Where(d => !curCards.Contains(d)).ToArray();

            var countEachRank = GetCountOfEachRank(curCards);

            for (int turnCardIdx = 0; turnCardIdx < remainingCards.Length - 1; turnCardIdx++)
            {
                Card turnCard = remainingCards[turnCardIdx];

                countEachRank[turnCard.ZeroBaseRank]++;

                for (int riverCardIdx = turnCardIdx + 1; riverCardIdx < remainingCards.Length; riverCardIdx++)
                {
                    Card riverCard = remainingCards[riverCardIdx];

                    countEachRank[riverCard.ZeroBaseRank]++;


                    if (IsFlush(curCards, turnCard, riverCard))
                        results[ePokerHand.Flush]++;


                    if (IsStraight(countEachRank))
                        results[ePokerHand.Straight]++;

                    if (IsPair(countEachRank))
                    {
                        results[ePokerHand.Pair]++;

                        if (IsTwoPair(countEachRank))
                            results[ePokerHand.TwoPair]++;

                        if (IsFullHouse(countEachRank))
                        {
                            results[ePokerHand.FullHouse]++;
                            results[ePokerHand.ThreeOfAKind]++;
                        }
                    }

                    if (Is3ofAKind(countEachRank))
                        results[ePokerHand.ThreeOfAKind]++;

                    if (Is4ofAKind(countEachRank))
                        results[ePokerHand.FourOfAKind]++;


                    countEachRank[riverCard.ZeroBaseRank]--;
                }

                countEachRank[turnCard.ZeroBaseRank]--;
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
            cntOfEachRank.Any(s => s >= 2);
        
        private static bool Is3ofAKind(int[] cntOfEachRank) => 
            cntOfEachRank.Any(s => s >= 3);

        private static bool Is4ofAKind(int[] cntOfEachRank) => 
            cntOfEachRank.Any(s => s == 4);      

        private static bool IsFullHouse(int[] cntOfEachRank) =>
            IsPair(cntOfEachRank) && Is3ofAKind(cntOfEachRank);

        private static bool IsTwoPair(int[] cntOfEachRank) => 
            cntOfEachRank.Where(s => s >= 2).Count() >= 2;
        

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

            foreach (Card card in cardLis)
            {
                countOfEachRank[card.ZeroBaseRank]++;
            }
            
            return countOfEachRank;
        }
    }
}
