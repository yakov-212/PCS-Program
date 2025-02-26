using System.Windows.Forms;

namespace TickTackToe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GamePanel = new TableLayoutPanel();
            label = new Label();
            TickPanel = new TableLayoutPanel();
            newGame = new Button();
            GamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            GamePanel.Controls.Add(label);
            GamePanel.Controls.Add(TickPanel);
            GamePanel.Controls.Add(newGame);
            GamePanel.Dock = DockStyle.Fill;
            GamePanel.Location = new Point(0, 0);
            GamePanel.Name = "GamePanel";
            GamePanel.RowCount = 3;
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            GamePanel.Size = new Size(908, 462);
            GamePanel.TabIndex = 0;
            // 
            // label
            // 
            label.Dock = DockStyle.Fill;
            label.Location = new Point(3, 0);
            label.Name = "label";
            label.Text = "TicTacToe";
            label.Font = new Font("serif", 40);
            label.Size = new Size(902, 92);
            label.TabIndex = 0;
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TickPanel
            // 
            TickPanel.ColumnCount = 3;
            TickPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            TickPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            TickPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            TickPanel.Dock = DockStyle.Fill;
            TickPanel.Location = new Point(3, 95);
            TickPanel.Name = "TickPanel";
            TickPanel.RowCount = 3;
            TickPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            TickPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            TickPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            TickPanel.Size = new Size(902, 271);
            TickPanel.TabIndex = 0;
            // 
            // newGame
            // 
            newGame.Dock = DockStyle.Fill;
            newGame.Location = new Point(3, 372);
            newGame.Name = "button1";
            newGame.Size = new Size(902, 87);
            newGame.TabIndex = 1;
            newGame.Text = "New Game";
            newGame.Click += Reset;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 462);
            Controls.Add(GamePanel);
            Name = "Form1";
            Text = "Form1";
            Load += OnLoad;
            GamePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TickPanel;
        private TableLayoutPanel GamePanel;
        private Button newGame;
        private Label label;
    }
}
