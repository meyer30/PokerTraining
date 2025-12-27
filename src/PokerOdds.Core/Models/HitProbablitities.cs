using static PokerOdds.Core.Enums;

namespace PokerOdds.Core.Models
{
    public class HitProbablitities
    {
        private readonly double[] _counts = new double[Enum.GetValues<PokerHand>().Length];


        public double this[PokerHand hand]
        {
            get => _counts[(int)hand];
            set => _counts[(int)hand] = value;
        }
    }
}
