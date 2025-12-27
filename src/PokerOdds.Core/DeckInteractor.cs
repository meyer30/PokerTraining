using PokerOdds.Core.Models;
using static PokerOdds.Core.CardRepository;
using static PokerOdds.Core.Enums;

namespace PokerOdds.Core
{
    public class DeckInteractor
    {
        public static Card GetCard(SuitEnum suit, RankEnum value)
        {
            return Deck.First(c => c.Suit == suit && c.Rank == value);
        }
    }
}
