using PokerTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTrainTesting
{
    public static class TestData
    {
        public static Card AceDiamonds = new Card(Suit.diamonds, Rank.ace);
        public static Card AceHearts = new Card(Suit.hearts, Rank.ace);
        public static Card AceSpades = new Card(Suit.spades, Rank.ace);
        public static Card AceClubs = new Card(Suit.clubs, Rank.ace);

        public static Card KingClubs = new Card(Suit.clubs, Rank.king);
        public static Card KingDiamonds = new Card(Suit.diamonds, Rank.king);
        public static Card KingHearts = new Card(Suit.hearts, Rank.king);
        public static Card KingSpades = new Card(Suit.spades, Rank.king);

        public static Card QueenClubs = new Card(Suit.clubs, Rank.queen);
        public static Card QueenHearts = new Card(Suit.diamonds, Rank.queen);
        public static Card QueenDiamonds = new Card(Suit.diamonds, Rank.queen);

        public static Card JackClubs = new Card(Suit.clubs, Rank.jack);
        public static Card JackDiamonds = new Card(Suit.diamonds, Rank.jack);
        
        public static Card TenClubs = new Card(Suit.clubs, Rank.ten);
        public static Card TenDiamonds = new Card(Suit.diamonds, Rank.ten);
        public static Card TenHearts = new Card(Suit.hearts, Rank.ten);

        public static Card NineClubs = new Card(Suit.clubs, Rank.nine);
        public static Card NineDiamonds = new Card(Suit.diamonds, Rank.nine);

        public static Card EightDiamonds = new Card(Suit.diamonds, Rank.eight);



        public static Card FiveClubs = new Card(Suit.clubs, Rank.five);
        public static Card FiveDiamonds = new Card(Suit.diamonds, Rank.five);

        public static Card FourClubs = new Card(Suit.clubs, Rank.four);
        public static Card ThreeClubs = new Card(Suit.clubs, Rank.three);
        public static Card TwoClubs = new Card(Suit.clubs, Rank.two);
    };
};