using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Coin : BaseConsoleCell
    {
        public override ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.Yellow;
        public override char Symbol { get; set; } = 'c';

        public Coin(int _x, int _y) : base(_x, _y) { }

        public override bool TryToStep()
        {
            return true;
        }
    }
}
