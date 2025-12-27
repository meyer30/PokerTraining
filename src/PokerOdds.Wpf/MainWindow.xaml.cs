using PokerOdds.Core;
using PokerOdds.Core.Models;
using System.Windows;
using static PokerOdds.Core.Enums;

namespace PokerOdds.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void RunBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                if (vm.SelectedCard1 == null ||
                    vm.SelectedCard2 == null ||
                    vm.SelectedCard3 == null ||
                    vm.SelectedCard4 == null ||
                    vm.SelectedCard5 == null)
                {
                    var result = MessageBox.Show("Not all cards selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var curCards = new List<Card> {
                    vm.SelectedCard1,
                    vm.SelectedCard2,
                    vm.SelectedCard3,
                    vm.SelectedCard4,
                    vm.SelectedCard5
                };

                if (curCards.Distinct().Count() != 5)
                {
                    var result = MessageBox.Show("5 Distinct cards must be selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ResultsBox.Items.Clear();


                var results = OddsCalculator.GetHitCounts(curCards);

                int totalPossibleCards = 1081;  //47*46/2 because 5 cards are played

                var probs = OddsCalculator.GetProbablitities(results, totalPossibleCards);


                foreach (PokerHand hand in Enum.GetValues<PokerHand>())
                    ResultsBox.Items.Add($"{hand.ToString()} - {probs[hand]:F2}");
            }
        }
    }
}