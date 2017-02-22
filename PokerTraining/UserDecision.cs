using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokerTraining
{
    public class UserDecision
    {
        private double potOdds;
        private double oddsWinning;
        private bool correctDecision;

        public UserDecision(double potOdds, double oddsWinning, bool userCalled)
        {
            this.potOdds = potOdds;
            this.oddsWinning = oddsWinning;
            this.correctDecision = (oddsWinning >= potOdds);
        }
    }
}