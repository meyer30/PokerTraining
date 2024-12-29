using Models;
using static WinFormsApp1.constants;

namespace WinFormsApp1
{
    internal class DeckInteractor
    {
        public static Card GetCard(SuitEnum suit, RankEnum value)
        {
            return Deck.First(c => c.mySuit2 == suit && c.myRank2 == value);
        }
    }
}
