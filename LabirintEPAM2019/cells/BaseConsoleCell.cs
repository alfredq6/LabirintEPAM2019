using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    interface BaseConsoleCell
    {
        ConsoleColor BackgroudColor { get; set; }
        ConsoleColor ForegroundColor { get; set; }
        char Symbol { get; set; }
        void Write();
    }
}
