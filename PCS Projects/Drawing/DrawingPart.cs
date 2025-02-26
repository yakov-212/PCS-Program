using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    internal class DrawingPart
    {
        //color
        //thickness
        public List<Point> points = new List<Point>();
        public void AddPoint(int x, int y)
        {
            points.Add(new Point(x, y));
        }
    }
}