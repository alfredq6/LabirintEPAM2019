using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Coin : BaseConsoleCell
    {
        public ConsoleColor BackgroudColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.Yellow;
        public char Symbol { get; set; } = 'c';
        public int? X { get; set; } = null;
        public int? Y { get; set; } = null;

        public void Write()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.BackgroundColor = this.BackgroudColor;
            Console.Write(Symbol);
        }
    }
}
