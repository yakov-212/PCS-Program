using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankspace
{
    internal class Checking : Account
    {
        public int Fee { get; set; }
        public int NumOfTransact { get; set; }

        int transact;

        public Checking() : this(10, 2)
        {
        }

        public Checking(int fee, int numOfTransact)
        {
            this.Fee = fee;
            this.NumOfTransact = numOfTransact;
        }
        public override void Withdraw(int amt)
        {
            base.Withdraw(amt);
            transact++;
        }

        public override string EndOfMonth()
        {
            if (transact > NumOfTransact)
            {
                base.Withdraw(Fee, TransactType.Fee);
            }
            transact = 0;
            return base.EndOfMonth();
        }
    }
}