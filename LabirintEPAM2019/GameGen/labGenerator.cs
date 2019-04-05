using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class LabGenerator
    {
        public Labirint labirint { get; private set; }
        private List<BaseConsoleCell> WallsToRemove = new List<BaseConsoleCell>();

        Random rand = new Random();

        public LabGenerator(int _width, int _height)
        {
            labirint = new Labirint(_width, _height);
        }
        
        public Labirint GetLabirint()
        {

            if (labirint != null)
            {
                labirint = new Labirint(labirint.Width, labirint.Height);

                GetReadyLabirint(labirint.Cells.First());
            }

            CreateCoins();

            return labirint;
        }

        private void CreateCoins()
        {
            var coins = labirint.Cells.OfType<Ground>().Where(ground => rand.Next(10) == 3
                                                            && (ground.Y == 0 ? ground.X != 0 : true)).ToList();

            if (!coins.Any())
                coins.Add(labirint.Cells.OfType<Ground>().Last());
            
            labirint.Cells = labirint.Cells.Select(cell => coins.Any(coin => cell.X == coin.X && cell.Y == coin.Y) ? new Coin(cell.X, cell.Y) : cell).ToList();
            labirint.Coins = labirint.Cells.OfType<Coin>().ToList();
            
        }

        private void GetReadyLabirint(BaseConsoleCell cell)
        {
            do
            {
                labirint[cell.X, cell.Y] = new Ground(cell.X, cell.Y);
                WallsToRemove.Remove(cell);

                var nearWalls = GetNearCells<Wall>(cell);

                var nearWallsNotToRemove = nearWalls.Where(wall => !CanRemove(wall));

                WallsToRemove.RemoveAll(wallToRemove => nearWallsNotToRemove.Any(wallNotToRemove => wallToRemove.X == wallNotToRemove.X && wallToRemove.Y == wallNotToRemove.Y));

                WallsToRemove.AddRange(nearWalls.Where(wall => CanRemove(wall)));
                if (WallsToRemove.Any())
                    cell = GetRandomCell(WallsToRemove);

            } while (WallsToRemove.Any());
        }

        private bool CanRemove(Wall wall)
        {
            if (wall == null)
                return false;

            if (GetNearCells<BaseConsoleCell>(wall).Where(x => !(x is Wall)).Count() > 1)
                return false;

            return true;
        }

        private BaseConsoleCell GetRandomCell(List<BaseConsoleCell> cells)
        {
            return cells[rand.Next(cells.Count)];
        }

        private List<T> GetNearCells<T>(BaseConsoleCell cellToRemove) where T : BaseConsoleCell
        {
            var nearCells = new List<BaseConsoleCell>();

            nearCells.Add(labirint[cellToRemove.X + 1, cellToRemove.Y]);
            nearCells.Add(labirint[cellToRemove.X - 1, cellToRemove.Y]);
            nearCells.Add(labirint[cellToRemove.X, cellToRemove.Y + 1]);
            nearCells.Add(labirint[cellToRemove.X, cellToRemove.Y - 1]);

            return nearCells.Where(cell => cell != null).OfType<T>().ToList();
        }
    }
}
