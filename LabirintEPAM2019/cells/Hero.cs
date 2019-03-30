using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Hero : BaseConsoleCell
    {
        public int X { get; set; } = 2;
        public int Y { get; set; } = 1;
        public ConsoleColor BackgroudColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor ForegroundColor { get; set; } = ConsoleColor.Red;
        public char Symbol { get; set; } = 'x';
        private static Hero _hero;
        public static Hero GetHero
        {
            get
            {
                if (_hero == null)
                {
                    _hero = new Hero();
                }
                return _hero;
            }
        }
        private Hero() { }

        public void Write()
        {
            Console.ForegroundColor = this.ForegroundColor;
            Console.BackgroundColor = this.BackgroudColor;
            Console.Write(Symbol);
        }

        public void Step(Labirint lab, Direction direction)
        {
            if (direction == Direction.Up)
            {
                foreach (Point point in lab.Road)
                    if (point.X == _hero.X && point.Y == _hero.Y - 1)
                    {
                        _hero.Y--;
                        break;
                    }
            }
            else if (direction == Direction.Right)
            {
                foreach (Point point in lab.Road)
                    if (point.Y == _hero.Y && point.X == _hero.X + 1)
                    {
                        _hero.X++;
                        break;
                    }
            }
            else if (direction == Direction.Down)
            {
                foreach (Point point in lab.Road)
                    if (point.X == _hero.X && point.Y == _hero.Y + 1)
                    {
                        _hero.Y++;
                        break;
                    }
            }
            else if (direction == Direction.Left)
            {
                foreach (Point point in lab.Road)
                    if (point.Y == _hero.Y && point.X == _hero.X - 1)
                    {
                        _hero.X--;
                        break;
                    }
            }

        }
    }
}
