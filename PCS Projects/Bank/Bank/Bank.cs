using System.Text;
using System.Xml.Linq;

namespace Bankspace
{
    public class Bank
    {
        List<Account> accounts;
        private static Bank bankInst;

        public static Bank GetBankInstance()
        {
            if (bankInst == null)
                bankInst = new Bank();
            return bankInst;
        }
        private Bank()
        {
            accounts = new List<Account>() {
                new Checking(),
                new Savings()
            };
        }

        public Account GetActiveAccount(int n)
        {
            return accounts[n];
        }

        //static void Main(string[] args) {
        //    //List<List<Account>> list = new List<List<Account>>(); 
        //   Account check = new Checking();
        //   Account save = new Savings();
        //    check.Deposit(100);
        //    check.Withdraw(10);
        //    check.Withdraw(10);
        //    check.Withdraw(10);
        //    check.EndOfMonth();

        //    save.Deposit(100);
        //    save.EndOfMonth();

        //    string[]names = Enum.GetNames(typeof(TransactType));
        //    foreach (string name in names) {
        //        Console.WriteLine(name);
        //    }   
        //    short[] shorts = (short[])Enum.GetValues(typeof(TransactType));
        //    foreach (var srt in shorts) {
        //        Console.WriteLine(srt);
        //    }
        //    TransactType[] tts = (TransactType[])Enum.GetValuesAsUnderlyingType(typeof(TransactType));
        //    foreach (var tt in tts) {
        //        Console.WriteLine(tt);
        //    }
        //    Console.WriteLine(Enum.IsDefined(typeof(TransactType), "Fee"));
        //    Console.WriteLine(Enum.IsDefined(typeof(TransactType), (short)60));
        //    TransactType t = (TransactType)Enum.Parse(typeof(TransactType), "Deposit");
        //    Console.WriteLine(t);
        //    string s = "";
        //    long t1 = Environment.TickCount;
        //    for (int i = 0; i < 50000; i++) {
        //        s += i;
        //    }
        //    long t2 = Environment.TickCount;
        //    Console.WriteLine(t2 - t1);
        //    long t3 = Environment.TickCount;
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < 50000; i++) {
        //        sb.Append( i);
        //    }
        //    long t4 = Environment.TickCount;
        //    Console.WriteLine(t4 - t3);
        //}
    }
}