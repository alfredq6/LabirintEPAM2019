using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Ground : BaseConsoleCell
    {
        public override ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.Green;
        public override char Symbol { get; set; } = '.';


        public Ground(int _x, int _y) : base(_x, _y) { }

        public override bool TryToStep()
        {
            return true;
        }
    }
}
