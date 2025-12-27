using PokerOdds.Core.Models;
using static PokerOdds.Core.Enums;

namespace PokerOdds.Core
{
    public class CardRepository
    {
        public static IEnumerable<Card> Deck =>
            from suit in Enum.GetValues<eSuit>()
            from rank in Enum.GetValues<eRank>()
            select new Card(suit, rank);
    }
}
