using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public abstract class BaseConsoleCell
    {
        public abstract ConsoleColor ForegroundColor { get; protected set; }
        public abstract char Symbol { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void Write()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.Write(this.Symbol);
        }

        public BaseConsoleCell(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public abstract bool TryToStep();

        public BaseConsoleCell() { }
    }
}
