using static PokerOdds.Core.Enums;

namespace PokerOdds.Core.Models
{
    /// <summary>
    /// Represents a Card in the 52 card deck.
    /// </summary>
    public class Card
    {
        public SuitEnum Suit { get; set; }
        public RankEnum Rank { get; set; }
        public int ZeroBaseRank => (int)Rank - 2;

        public string DisplayName => $"{Rank} of {Suit}";

        public Card(SuitEnum suit, RankEnum value)
        {
            this.Suit = suit;
            this.Rank = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Card other)
            {
                return this.Suit == other.Suit && this.Rank == other.Rank;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Combine the hash codes of Suit and Rank
            return ((int)Suit * 397) ^ (int)Rank;
        }
    };
};
