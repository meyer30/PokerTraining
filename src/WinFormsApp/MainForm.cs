using Models;
using System.Text;
using WinFormsApp1.Models;
using static WinFormsApp1.Constants;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void GetResults(object sender, EventArgs e)
        {
            int totalPossibleCards = 2162;  //47*46 because 5 cards are played


            var curCards = new List<Card>() //todo hook up with the dropdowns
            {
                DeckInteractor.GetCard(SuitEnum.clubs, RankEnum.two),
                DeckInteractor.GetCard(SuitEnum.clubs, RankEnum.three),
                DeckInteractor.GetCard(SuitEnum.hearts, RankEnum.four),
                DeckInteractor.GetCard(SuitEnum.clubs, RankEnum.five),
                DeckInteractor.GetCard(SuitEnum.clubs, RankEnum.six)
            };

            HitCounts results = GetHitCounts(curCards);

            double probFlush = (double)results.FlushHits / (double)totalPossibleCards * 100;

            resultsTxtBx.Text = @$"Flush probabilty {probFlush}%";
        }

        private HitCounts GetHitCounts(List<Card> curCards)
        {
            HitCounts results = new HitCounts();

            var remainingCards = Constants.Deck.Where(d => !curCards.Contains(d)).ToArray();

            var countEachType = GetCountOfEachRank(curCards);

            for (int idx1 = 0; idx1 < remainingCards.Length - 1; idx1++)
            {
                Card turnCard = remainingCards[idx1];

                countEachType[turnCard.ZeroBaseRank]++;

                for (int idx2 = idx1 + 1; idx2 < remainingCards.Length; idx2++)
                {
                    Card riverCard = remainingCards[idx2];

                    countEachType[riverCard.ZeroBaseRank]++;

                    if (IsFlush(curCards, turnCard, riverCard))
                        results.FlushHits++;
                    if (IsStraight(countEachType))
                        results.StraightHits++;
                    
                    if (IsPair(countEachType))
                    {
                        results.PairHits++;
                        if (IsTwoPair(countEachType))
                        {
                            results.TwoPairHits++;
                        }
                        if (IsFullHouse(countEachType))
                        {
                            results.FullHouseHits++;
                            results.ThreeOfKindHits++;
                        }
                    }
                    if (Is3ofAKind(countEachType))
                        results.ThreeOfKindHits++;
                    if (Is4ofAKind(countEachType))
                        results.FourOfKindHits++;

                    countEachType[riverCard.ZeroBaseRank]--;
                }

                countEachType[turnCard.ZeroBaseRank]--;
            }

            return results;
        }

        private bool IsFlush(List<Card> curCards, Card p1, Card p2)
        {
            int[] suitCount = { 0, 0, 0, 0 };

            for (int idx = 0; idx < curCards.Count; idx++)
            {
                suitCount[(int)curCards[idx].mySuit2]++;
            }
            suitCount[(int)p1.mySuit2]++;
            suitCount[(int)p2.mySuit2]++;

            return suitCount.Any(s => s >= 5);
        }

        private bool IsStraight(int[] countEachType)
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

        private bool IsPair(int[] countEachType)
        {
            return countEachType.Any(s => s == 2);
        }


        private bool Is3ofAKind(int[] countEachType)
        {
            return countEachType.Any(s => s == 3);
        }


        private bool Is4ofAKind(int[] countEachType)
        {
            return countEachType.Any(s => s == 4);
        }


        private bool IsFullHouse(int[] countEachType)
        {
            return IsPair(countEachType) && Is3ofAKind(countEachType);
        }


        private bool IsTwoPair(int[] countEachType)
        {
            return countEachType.Where(s => s == 2).Count() >= 2;
        }

        /// <summary>
        /// Returns 0 based rank count.  
        /// Index 0 represents 2card
        /// Index 12 represents ace
        /// </summary>
        /// <param name="cardLis"></param>
        /// <returns></returns>
        private int[] GetCountOfEachRank(List<Card> cardLis)
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