using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Walls : BaseConsoleCell
    { 
        public ConsoleColor BackgroudColor { get; set; } = ConsoleColor.DarkGreen;
        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.DarkGreen;
        public char Symbol { get; set; } = '#';
        public void Write()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.BackgroundColor = this.BackgroudColor;
            Console.Write(Symbol);
        }
    }


    
}
