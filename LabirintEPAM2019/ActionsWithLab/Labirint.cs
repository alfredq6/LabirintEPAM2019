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
        public List<Cell> Cells = new List<Cell>();
        public List<Point> Road = new List<Point>();
        public List<Cell> Coins = new List<Cell>();

        public Labirint(int width, int height)
        {
            Width = width;
            Height = height;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cells.Add(new Cell(j, i, Allwall()));
                }
            }
        }

        public Cell this[int x, int y]
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

        public Labirint Reset(Hero hero)
        {
            this.Road.Clear();
            hero.X = 2;
            hero.Y = 1;
            var labgen = new LabGenerator(this.Width, this.Height);
            return labgen.GetLabirint(this.Width, this.Height);
        }

        private Wall Allwall()
        {
            return Wall.Up | Wall.Down | Wall.Left | Wall.Right;
        }
    }
}
