using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Labirint
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<BaseConsoleCell> Cells = new List<BaseConsoleCell>();

        public Labirint(int width, int height)
        {
            Width = width;
            Height = height;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells.Add(new Wall(j, i));
                }
            }
        }

        public BaseConsoleCell this[int x, int y]
        {
            get
            {
                return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
            }
            set
            {
                if (this[value.X, value.Y] != null)
                {
                    Cells.Remove(this[value.X, value.Y]);
                }
                Cells.Add(value);
            }
        }
    }
}
