namespace PokerOdds.Core
{
    public class Enums
    {
        public enum ePokerHand
        {
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind
        }

        public enum eSuit
        {
            clubs = 0,
            diamonds = 1,
            hearts = 2,
            spades = 3,
        }

        public enum eRank
        {
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            ten = 10,
            jack = 11,
            queen = 12,
            king = 13,
            ace = 14,
        }
    }
}
