using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Bankspace
{
    public partial class Form1 : Form
    {
        private Color[] colors;
        private int[] buttonnum;
        private bool gate;
        private int n;
        Account activeAccount;
        Bank bank;
        public Form1()
        {
            InitializeComponent();
            buttonnum = new int[Controls.Count];
            colors = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Yellow, Color.Black, Color.White };
            bank = Bank.GetBankInstance();
            activeAccount = bank.GetActiveAccount(0);
            activeAccountLbl.Text = activeAccount.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ChangeColor(object sender, EventArgs e)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] == sender)
                {
                    if (buttonnum[i] > 5)
                        buttonnum[i] = 0;

                    Controls[i].BackColor = colors[buttonnum[i]++];

                }
            }


        }

        private void OnTransactionClick(object sender, EventArgs e)
        {
            string s = TransactTB.Text;
            int amt;
            if (Int32.TryParse(s, out amt))
            {
                if (sender.Equals(depButton))
                {
                    activeAccount.Deposit(amt);
                }
                else
                {
                    activeAccount.Withdraw(amt);
                }
            }
            TransactTB.Clear();
        }
        private void OnEomClick(object sender, EventArgs e)
        {
            string s = activeAccount.EndOfMonth();
            SummaryTB.AppendText(s);
        }

        private void SummaryTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void AccountChange(object sender, EventArgs e)
        {
                gate = !gate;
                n = gate ? 1 : 0;
                activeAccount = bank.GetActiveAccount(n);
                activeAccountLbl.Text = activeAccount.ToString();           

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            gate = !gate;
            n = gate ? 1 : 0;
            activeAccount = bank.GetActiveAccount(n);
            if (activeAccountLbl.Text == activeAccount.ToString())
                gate = !gate;
            else
                activeAccountLbl.Text = activeAccount.ToString();
        }
    }
    //public partial class BankForm : Form
    //{
    //    Bank bank;
    //    Account activeAccount;
    //    public BankForm()
    //    {
    //        bank = Bank.GetBankInstance();
    //        activeAccount = bank.GetActiveAccount();
    //        InitializeComponent();
    //        activeAccountLbl.Text = activeAccount.ToString();

    //    }

    //    private void OnTransactionClick(object sender, EventArgs e)
    //    {
    //        string s = TransactTB.Text;
    //        int amt;
    //        if (Int32.TryParse(s, out amt))
    //        {
    //            if (sender.Equals(depButton))
    //            {
    //                activeAccount.Deposit(amt);
    //            }
    //            else
    //            {
    //                activeAccount.Withdraw(amt);
    //            }
    //        }
    //        TransactTB.Clear();
    //    }

    //    private void OnEomClick(object sender, EventArgs e)
    //    {
    //        string s = activeAccount.EndOfMonth();
    //        SummaryTB.AppendText(s);
    //    }
    //}
}
