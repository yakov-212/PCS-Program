using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Boats
    {
        string name = "unassigned";
        int length;
        int[][] pos;

        public int[][] Pos { get; set; }

        public string NameBoat{get; set;}

        public int Len { get; set; }
    }
}
