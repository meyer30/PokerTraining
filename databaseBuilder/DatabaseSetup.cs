using PokerTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaseBuilder
{
    class DatabaseSetup
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello");

            Card pocket1;
            pocket1 = new Card(Suit.hearts, Rank.ace);
            Console.WriteLine(pocket1.Rank);

            pocket1.Rank++;
            Console.WriteLine(pocket1.Rank);

            Console.ReadLine();
        }

        /// <summary>
        //This fills the database "deals table "
        //It will not hold every possible deal, because certain deals have redudant odds of winning
        //for example K Hearts, Ace Hearts, would have the same odds as K Spades, Ace Spades.
        /// </summary>
        public void fillDealTable()
        {
            Card pocket1, pocket2;

            //foreach pocket combination
            //foreach commmunity
            //  save to database


            //First create all combinations where the pocket is the same suit.
            pocket1 = new Card(Suit.hearts, Rank.two);
            pocket2 = new Card(Suit.hearts, Rank.three);
            
            for(Rank rank1 = Rank.two; rank1 < Rank.ace; rank1++)
            {
                pocket1.Rank = rank1;
                for (Rank rank2 = rank1 + 1; rank2 <= Rank.ace; rank2++)
                {
                    pocket2.Rank = rank2;

                    DealAllCombos(pocket1, pocket2);
                }
            }



            //Second create all combinations where the pockets do not match.
            pocket1 = new Card(Suit.hearts, Rank.two);
            pocket2 = new Card(Suit.diamonds, Rank.two);

            for (Rank rank1 = Rank.two; rank1 <= Rank.ace; rank1++)
            {
                pocket1.Rank = rank1;
                for (Rank rank2 = rank1; rank2 <= Rank.ace; rank2++)
                {
                    pocket2.Rank = rank2;
                    DealAllCombos(pocket1, pocket2);
                }
            }
        }

        /// <summary>
        /// Deal all combination for pocket 1, pocket2. 
        /// </summary>
        /// <param name="pocket1"></param>
        /// <param name="pocket2"></param>
        private void DealAllCombos(Card pocket1, Card pocket2)
        {
            Card flop1, flop2, flop3, turn, river;
            List<Card> unavailableCards = new List<Card>();

            unavailableCards.Add(pocket1);
            unavailableCards.Add(pocket2);


            flop1 = new Card(Suit.clubs, Rank.two);


            while (flop1 != null)
            {
                // if flop 
                if (!flop1.IsIn(unavailableCards))
                {
                    
                }
                flop1 = flop1.Next();
            }
            


            
        }
    }
}
