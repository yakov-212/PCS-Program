using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankspace
{
    public abstract class Account
    {

        int startTransacts;

        private string name;

        public string Name
        {
            get { return name; }
        }

        protected Account()
        {
            name = $"{++numGenerator:d6}";
        }

        public override string? ToString()
        {
            return $"{GetType().Name} - {name}";
        }


        //Transaction[] transacts = new Transaction[100];
        //int count;
        List<Transaction> transacts = new List<Transaction>();
        private static int numGenerator;


        protected int Balance { get; private set; }
        private void ProcessTransaction(int amt, TransactType type)
        {
            //transacts[count++] = new Transaction(amt, type);
            transacts.Add(new Transaction(amt, type));
            Balance += amt;
        }
        public virtual void Deposit(int amt, TransactType type)
        {
            ProcessTransaction(amt, type);
        }
        public virtual void Deposit(IList<int> deposits)
        {
            //ProcessTransaction(amt, type);
            //Type t =  transacts.GetType();
            // Type t2 = typeof(Account);
        }
        public virtual void Withdraw(int amt, TransactType type)
        {
            ProcessTransaction(-amt, type);
        }
        public virtual void Deposit(int amt)
        {
            //Deposit(amt, Transaction.DEPOSIT);
            Deposit(amt, /*(TransactType)20*/ TransactType.Deposit);
        }
        public virtual void Withdraw(int amt)
        {
            Withdraw(amt, TransactType.Withdraw);
        }
        public virtual string EndOfMonth()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The Balance is {Balance}\n");
            sb.Append("---------Transactions----------\n");
            for (int i = startTransacts; i < transacts.Count; i++)
            {
                sb.Append($"{transacts[i]}\n");
            }
            startTransacts = transacts.Count;
            return sb.ToString();
            //Console.WriteLine(sb);

            //string s = $"The Balance is {Balance}\n";
            //s += "---------Transactions----------\n";
            //for (int i = 0; i < count; i++) {
            //    s += $"{transacts[i]}\n";
            //}
            //Console.WriteLine(s);
        }
    }
}