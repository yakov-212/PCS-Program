using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Drawing
{
    internal class DrawingPanel : Panel
    {
        List<DrawingPart> drawParts = new List<DrawingPart>();
        DrawingPart currentDrawingPart;
        bool clicked;
        int colnum;
        Color Color = Color.Black;
        Color[] Colors = {Color.Blue, Color.Green,Color.Red,Color.Yellow,Color.Purple,Color.Black};
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //int x1 = e.X;
            //int y1 = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                if (colnum == Colors.Length)
                    colnum = 0;
                Color = Colors[colnum++];
            }
            else
            {
                currentDrawingPart = new DrawingPart();
                drawParts.Add(currentDrawingPart);
                currentDrawingPart.AddPoint(e.X, e.Y);
                clicked = true;
            }
            
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Random rand = new Random();
            if (clicked)
            {
                for (int i = 0; i < drawParts.Count - 1; i++)
                {
                    Draw(drawParts[i],e);
                }
                Draw(currentDrawingPart, e);
            }
            
            
        }
        private void Draw(DrawingPart line,PaintEventArgs e) {
            //Random rand = new Random();
            for (int j = 0; j < currentDrawingPart.points.Count - 2; j++)
            {
                //int r = rand.Next(256);
                //int g = rand.Next(256);
                //int b = rand.Next(256);
                //Color c = Color.FromArgb(r, g, b);

                DrawingPart current = currentDrawingPart;
                int x1 = current.points[j].X;
                int y1 = current.points[j].Y;
                int x2 = current.points[j + 1].X;
                int y2 = current.points[j + 1].Y;
                Graphics gr = e.Graphics;
                gr.DrawLine(new Pen(Color, 2), x1, y1, x2, y2);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            clicked = false;
            
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (clicked)
            {
                currentDrawingPart.AddPoint(e.X, e.Y);
                Invalidate();
            }
        }
    }
}