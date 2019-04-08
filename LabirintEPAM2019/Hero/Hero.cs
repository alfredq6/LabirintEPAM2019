using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Hero : BaseConsoleCell
    {
        public override ConsoleColor ForegroundColor { get; protected set; } = ConsoleColor.Red;
        public override char Symbol { get; set; } = 'x';
        public override bool TryToStep { get; protected set; } = true;

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

        private Hero()
        {
            X = 0;
            Y = 0;
        }


        private void TryToStepInCurrentCell(Labirint lab, BaseConsoleCell currCell)
        {
            if (currCell != null && currCell.TryToStep)
            {
                if (currCell is Coin)
                {
                    lab.Cells = lab.Cells.Select(cell => cell.X == currCell.X && cell.Y == currCell.Y ? new Ground(currCell.X, currCell.Y) : cell).ToList();
                }
                _hero.X = currCell.X;
                _hero.Y = currCell.Y;
            }
        }

        public void Step(Labirint lab, Direction direction)
        {
            
            switch (direction)
            {
                case Direction.Up:
                    {
                        var currCell = lab[_hero.X, _hero.Y - 1];
                        TryToStepInCurrentCell(lab, currCell);
                        break;
                    }
                case Direction.Down:
                    {
                        var currCell = lab[_hero.X, _hero.Y + 1];
                        TryToStepInCurrentCell(lab, currCell);
                        break;
                    }
                case Direction.Left:
                    {
                        var currCell = lab[_hero.X - 1, _hero.Y];
                        TryToStepInCurrentCell(lab, currCell);
                        break;
                    }
                case Direction.Right:
                    {
                        var currCell = lab[_hero.X + 1, _hero.Y];
                        TryToStepInCurrentCell(lab, currCell);
                        break;
                    }
            }
        }
    }
}
