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
        public static Card AceDiamonds = new Card(Suit.diamonds, Value.ace);
        public static Card AceHearts = new Card(Suit.hearts, Value.ace);
        public static Card AceSpades = new Card(Suit.spades, Value.ace);
        public static Card AceClubs = new Card(Suit.clubs, Value.ace);

        public static Card KingClubs = new Card(Suit.clubs, Value.king);
        public static Card KingDiamonds = new Card(Suit.diamonds, Value.king);
        public static Card KingHearts = new Card(Suit.hearts, Value.king);
        public static Card KingSpades = new Card(Suit.spades, Value.king);

        public static Card QueenClubs = new Card(Suit.clubs, Value.queen);
        public static Card QueenHearts = new Card(Suit.diamonds, Value.queen);
        public static Card QueenDiamonds = new Card(Suit.diamonds, Value.queen);

        public static Card JackClubs = new Card(Suit.clubs, Value.jack);
        public static Card JackDiamonds = new Card(Suit.diamonds, Value.jack);
        
        public static Card TenClubs = new Card(Suit.clubs, Value.ten);
        public static Card TenDiamonds = new Card(Suit.diamonds, Value.ten);
        public static Card TenHearts = new Card(Suit.hearts, Value.ten);

        public static Card NineClubs = new Card(Suit.clubs, Value.nine);
        public static Card NineDiamonds = new Card(Suit.diamonds, Value.nine);

        public static Card EightDiamonds = new Card(Suit.diamonds, Value.eight);



        public static Card FiveClubs = new Card(Suit.clubs, Value.five);
        public static Card FiveDiamonds = new Card(Suit.diamonds, Value.five);

        public static Card FourClubs = new Card(Suit.clubs, Value.four);
        public static Card ThreeClubs = new Card(Suit.clubs, Value.three);
        public static Card TwoClubs = new Card(Suit.clubs, Value.two);
    };
};