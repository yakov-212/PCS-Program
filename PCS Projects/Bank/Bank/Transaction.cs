using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankspace
{
    public enum TransactType : short
    {
        Withdraw = 10,
        Deposit = 20,
        Fee = 30,
        Interest = 40
    }
    internal class Transaction
    {

        //public const int WITHDRAW = 0;
        //public const int DEPOSIT = 1;
        //public const int FEE = 2;
        //public const int LAST = 3;
        //public int Ttype { get; }

        public TransactType Ttype { get; }
        public int Amt { get; }

        public DateTime Date { get; }

        public Transaction(int amt, TransactType ttype)
        {
            Amt = amt;
            Ttype = ttype;
            Date = DateTime.Now; //new DateTime();
        }

        //string ConvertType(int type) {
        //    switch (type) {
        //        case WITHDRAW:
        //            return "Withdraw";
        //        case DEPOSIT:
        //            return "Deposit";
        //        case FEE:
        //            return "Fee";
        //        default:
        //            return "Unknown";
        //    }
        //}

        //public override string? ToString() {
        //    return $"Amt: {Math.Abs(Amt)} Type: {ConvertType(Ttype)} Date: {Date.ToString("G")/*Date.ToString("MM-dd-yyyy")*/}";
        //}

        public override string? ToString()
        {
            return $"Amt: {Math.Abs(Amt)} Type: {Ttype} Date: {Date.ToString("G")/*Date.ToString("MM-dd-yyyy")*/}";
        }
    }
}