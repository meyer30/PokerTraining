using static PokerOdds.Core.Enums;

namespace PokerOdds.Core.Models
{
    /// <summary>
    /// Stores the number of available cards that would cause a poker hand to "hit" or become valid
    /// </summary>
    public class HitCounts
    {
        private readonly int[] _counts = new int[Enum.GetValues<ePokerHand>().Length];

        public int this[ePokerHand hand]
        {
            get => _counts[(int)hand];
            set => _counts[(int)hand] = value;
        }
    }
}
