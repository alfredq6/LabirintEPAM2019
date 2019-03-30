using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }
        public Cell(int x, int y, Wall _wall)
        {
            X = x;
            Y = y;
            wall = _wall;
        }
        public Wall wall { get; set; }
    }
}
