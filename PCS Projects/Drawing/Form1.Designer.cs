using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Drawing
{
    partial class DrawingForm
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
            thePanel = new DrawingPanel();
            SuspendLayout();
            // 
            // thePanel
            // 
            thePanel.Dock = DockStyle.Fill;
            thePanel.Location = new Point(0, 0);
            thePanel.Margin = new Padding(3, 4, 3, 4);
            thePanel.Name = "thePanel";
            thePanel.Size = new Size(914, 600);
            thePanel.TabIndex = 0;
            // 
            // DrawingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(thePanel);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "DrawingForm";
            Text = "Drawing";
            ResumeLayout(false);
        }

        #endregion

        private DrawingPanel thePanel;
    }
}