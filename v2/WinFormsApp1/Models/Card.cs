using static WinFormsApp1.constants;

namespace Models
{


    /// <summary>
    /// Represents a Card in the 52 card deck.
    /// </summary>
    public class Card
    {
        public SuitEnum mySuit2 { get; set; }
        public RankEnum myRank2 { get; set; }

        public Card(SuitEnum suit, RankEnum value)
        {
            this.mySuit2 = suit;
            this.myRank2 = value;
        }

        public int ZeroBaseRank => (int)myRank2 - 2;
    };
};
