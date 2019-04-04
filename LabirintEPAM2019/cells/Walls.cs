using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Wall : BaseConsoleCell
    {
        public override ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.White;
        public override char Symbol { get; set; } = '#';

        public Wall(int _x, int _y) : base(_x, _y) { }

        public override bool TryToStep()
        {
            return false;
        }
    }
}
