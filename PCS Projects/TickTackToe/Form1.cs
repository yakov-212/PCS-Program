using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TickTackToe
{

    public partial class Form1 : Form
    {
        int NUM = 3;
        int CATSGAME = 9;
        int turn;
        public bool xo;
        public Token[,] squares = new Token[3, 3];
        bool allowReset = false;
        
        public Form1()
        {
            InitializeComponent();



        }
        private void OnLoad(object sender, EventArgs e)
        {
            TickPanel.ColumnStyles.Clear();
            TickPanel.RowStyles.Clear();
            for (int i = 0; i < NUM; i++)
            {
                TickPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1F));
                TickPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1F));
            }
            for (int i = 0; i < NUM * NUM; i++)
            {
                Token tk = new Token();
                tk.AutoSize = false;
                tk.TextAlign = ContentAlignment.MiddleCenter;
                tk.Dock = DockStyle.Fill;
                tk.BorderStyle = BorderStyle.FixedSingle;
                tk.Margin = new Padding(0);
                tk.BackColor = Color.White;
                tk.TabIndex = i;
                tk.Tag = 0;
                tk.Click += OnClick;
                TickPanel.Controls.Add(tk);
            }
            FillSquares();
        }

        private void OnClick(object sender, EventArgs e)
        {

            Debug.WriteLine("was clicked");
            Token tk = sender as Token;
            if (tk.WasClicked)
            {
                string name = xo ? "O" : "X";
                Color color = xo ? Color.Red : Color.Blue;
                xo = !xo;
                tk.Text = name;
                tk.Name = name;
                tk.Font = new Font("Serif", 40);
                tk.ForeColor = color;
                tk.WasClicked = false;
                CheckWin();
            }

        }
        private void CheckWin()
        {
            int xrow = 0;
            int orow = 0;
            int xcol = 0;
            int ocol = 0;



            for (int i = 0; i < NUM; i++)
            {
                for (int j = 0; j < NUM; j++)
                {
                    if (squares[i, j].Name == "X")
                        xrow++;
                    else if (squares[i, j].Name == "O")
                        orow++;
                    if (squares[j, i].Name == "X")
                        xcol++;
                    else if (squares[j, i].Name == "O")
                        ocol++;
                }
                if (xrow == NUM || xcol == NUM)
                {
                    Win(true);
                }
                else if (orow == NUM || ocol == NUM)
                {
                    Win(false);
                }
                xrow = 0;
                orow = 0;
                xcol = 0;
                ocol = 0;

            }

            for (int i = 0; i < NUM; i++)
            {
                if (squares[i, i].Name == "X")
                    xrow++;
                else if (squares[i, i].Name == "O")
                    orow++;
                if (squares[NUM - 1 - i, i].Name == "X")
                    xcol++;
                else if (squares[NUM - 1 - i, i].Name == "O")
                    ocol++;
            }
            if (xrow == NUM || xcol == NUM)
            {
                Win(true);
            }
            else if (orow == NUM || ocol == NUM)
            {
                Win(false);
            }
            if (++turn == CATSGAME)
            {
                allowReset = true;
                label.Text = "Cats Game";
                label.ForeColor = Color.Purple;
            }



        }
        private void FillSquares()
        {
            for (int i = 0; i < NUM * NUM; i++)
            {

                squares[i / NUM, i % NUM] = (Token)TickPanel.Controls[i];
            }
        }
        private void Win(bool? ox)
        {
            if (ox == null) { return; }
            bool xo = (bool)ox;
            if (xo)
            {
                Debug.WriteLine("X Wins");
                label.Text = "X Wins";
                label.ForeColor = Color.Blue;

            }
            else
            {
                label.Text = "O Wins";
                label.ForeColor = Color.Red;
            }
            UnClick(true);
            allowReset = true;

        }
        private void UnClick(bool notReset)
        {
           
            {
                for (int i = 0; i < squares.Length; i++)
                {
                    if (notReset)
                        squares[i / NUM, i % NUM].Click -= OnClick;
                    else
                    {
                        squares[i / NUM, i % NUM].Click += OnClick;
                        squares[i / NUM, i % NUM].WasClicked = true;
                        squares[i / NUM, i % NUM].Name = "";
                        squares[i / NUM, i % NUM].Text = "";

                    }
                }
            }
            
        }
        private void Reset(Object sender, EventArgs e)
        {
            if (allowReset)
            {
                label.ForeColor = Color.Black;
                label.Text = "TicTacToe";
                UnClick(false);
                allowReset= false;
                xo = false;
                turn = 0;
            }


        }
        public class Token : Label
        {
            public bool WasClicked = true;
        }

        
    }
}
