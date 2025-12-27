using PokerOdds.Core;
using PokerOdds.Core.Models;
using System.ComponentModel;

namespace PokerOdds.Wpf
{
    internal class MainWindowViewModel
    {
        public IEnumerable<Card> Deck => CardRepository.Deck;

        public Card SelectedCard1 { get; set; }

        public Card SelectedCard2 { get; set; }

        public Card SelectedCard3 { get; set; }

        public Card SelectedCard4 { get; set; }

        public Card SelectedCard5 { get; set; }
    }
}
