using Models;

namespace WinFormsApp1
{
    public class Constants
    {
        public enum SuitEnum
        {
            clubs = 0,
            diamonds = 1,
            hearts = 2,
            spades = 3,
        }

        public enum RankEnum
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

        public static readonly IEnumerable<Card> Deck = new List<Card>()
        {
			new Card(SuitEnum.clubs, RankEnum.two),
			new Card(SuitEnum.clubs, RankEnum.three),
			new Card(SuitEnum.clubs, RankEnum.four),
			new Card(SuitEnum.clubs, RankEnum.five),
			new Card(SuitEnum.clubs, RankEnum.six),
			new Card(SuitEnum.clubs, RankEnum.seven),
			new Card(SuitEnum.clubs, RankEnum.eight),
			new Card(SuitEnum.clubs, RankEnum.nine),
			new Card(SuitEnum.clubs, RankEnum.ten),
			new Card(SuitEnum.clubs, RankEnum.jack),
			new Card(SuitEnum.clubs, RankEnum.queen),
			new Card(SuitEnum.clubs, RankEnum.king),
			new Card(SuitEnum.clubs, RankEnum.ace),
			new Card(SuitEnum.diamonds, RankEnum.two),
			new Card(SuitEnum.diamonds, RankEnum.three),
			new Card(SuitEnum.diamonds, RankEnum.four),
			new Card(SuitEnum.diamonds, RankEnum.five),
			new Card(SuitEnum.diamonds, RankEnum.six),
			new Card(SuitEnum.diamonds, RankEnum.seven),
			new Card(SuitEnum.diamonds, RankEnum.eight),
			new Card(SuitEnum.diamonds, RankEnum.nine),
			new Card(SuitEnum.diamonds, RankEnum.ten),
			new Card(SuitEnum.diamonds, RankEnum.jack),
			new Card(SuitEnum.diamonds, RankEnum.queen),
			new Card(SuitEnum.diamonds, RankEnum.king),
			new Card(SuitEnum.diamonds, RankEnum.ace),
			new Card(SuitEnum.hearts, RankEnum.two),
			new Card(SuitEnum.hearts, RankEnum.three),
			new Card(SuitEnum.hearts, RankEnum.four),
			new Card(SuitEnum.hearts, RankEnum.five),
			new Card(SuitEnum.hearts, RankEnum.six),
			new Card(SuitEnum.hearts, RankEnum.seven),
			new Card(SuitEnum.hearts, RankEnum.eight),
			new Card(SuitEnum.hearts, RankEnum.nine),
			new Card(SuitEnum.hearts, RankEnum.ten),
			new Card(SuitEnum.hearts, RankEnum.jack),
			new Card(SuitEnum.hearts, RankEnum.queen),
			new Card(SuitEnum.hearts, RankEnum.king),
			new Card(SuitEnum.hearts, RankEnum.ace),
			new Card(SuitEnum.spades, RankEnum.two),
			new Card(SuitEnum.spades, RankEnum.three),
			new Card(SuitEnum.spades, RankEnum.four),
			new Card(SuitEnum.spades, RankEnum.five),
			new Card(SuitEnum.spades, RankEnum.six),
			new Card(SuitEnum.spades, RankEnum.seven),
			new Card(SuitEnum.spades, RankEnum.eight),
			new Card(SuitEnum.spades, RankEnum.nine),
			new Card(SuitEnum.spades, RankEnum.ten),
			new Card(SuitEnum.spades, RankEnum.jack),
			new Card(SuitEnum.spades, RankEnum.queen),
			new Card(SuitEnum.spades, RankEnum.king),
			new Card(SuitEnum.spades, RankEnum.ace)
		};
    }
}
