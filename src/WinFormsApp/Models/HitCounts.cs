namespace WinFormsApp1.Models
{
    internal class HitCounts
    {
        public int FlushHits { get; set; }
        public int StraightHits { get; set; }

        public int PairHits { get; set; }
        public int TwoPairHits { get; set;}
        public int ThreeOfKindHits { get; set; }

        public int FullHouseHits { get; set; }
        public int FourOfKindHits { get; set; }
    }
}
