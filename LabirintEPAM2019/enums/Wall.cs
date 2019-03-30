using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    [Flags]
    public enum Wall
    {
        Up = 1,
        Down = 4,
        Left = 8,
        Right = 2
    }
}
