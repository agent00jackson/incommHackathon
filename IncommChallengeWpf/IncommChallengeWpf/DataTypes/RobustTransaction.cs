using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncommChallengeWpf.DataTypes
{
   public class RobustTransaction
    {
        private IncommTransaction IncommTransaction;

        public string CounterParty
        {
            get => IncommTransaction.CounterParty;
        }

        public string Amount
        {
            get
            {
                int amt = IncommTransaction.Amount;
                if (IncommTransaction.Type == "debit")
                    amt *= -1;
                double ret = (double)amt / 100;
                return string.Format("${0:0.00}", ret);
            }
        }

        public string Description
        {
            get => IncommTransaction.Description;
        }

        public RobustTransaction(IncommTransaction it)
        {
            IncommTransaction = it;
        }
    }
}
