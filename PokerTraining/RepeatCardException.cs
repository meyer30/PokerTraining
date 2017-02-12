using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerTraining
{
    class RepeatCardException : Exception
    {
        private string Message;

        public RepeatCardException(string m)
        {
            Message = m;
        }
    };
};
