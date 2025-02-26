using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankspace
{
    internal class Savings : Account
    {
        public int InterestRate { get; set; }

        public Savings() : this(1)
        {
        }

        public Savings(int interestRate)
        {
            InterestRate = interestRate;
        }

        public override string EndOfMonth()
        {
            Deposit(Balance * InterestRate / 100, TransactType.Interest);
            return base.EndOfMonth();
        }
    }
}