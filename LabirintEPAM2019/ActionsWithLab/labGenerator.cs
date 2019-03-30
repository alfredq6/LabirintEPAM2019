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
        public Labirint labirint;
        private List<Cell> VisitedCells = new List<Cell>();
        private List<Cell> UnvisitedCells = new List<Cell>();
        Random rand = new Random();
        public LabGenerator(int _width, int _height)
        {
            labirint = new Labirint(_width, _height);
        }
        
        public Labirint GetLabirint(int _width, int _height)
        {
            labirint = new Labirint(_width, _height);
            UnvisitedCells = labirint.Cells.ToList();
            GetReadyLabirint(labirint.Cells[0]);
            return labirint;
        }

        private void GetReadyLabirint(Cell cell)
        {
            do
            {
                UnvisitedCells.Remove(cell);
                if (UnvisitedCells.Any(c => c == labirint[cell.X - 1, cell.Y]
                                       || c == labirint[cell.X + 1, cell.Y]
                                       || c == labirint[cell.X, cell.Y - 1]
                                       || c == labirint[cell.X, cell.Y + 1]
                                       ))
                {
                    VisitedCells.Add(cell);
                    var nextCell = GetRandomCell(GetNearUnvisiteedCells(cell));
                    if (!VisitedCells.Contains(nextCell))
                        BrakeWall(cell, nextCell);
                    cell = nextCell;
                }
                else if (VisitedCells.Count != 0)
                {
                    if (!VisitedCells.Contains(cell))
                        labirint.Coins.Add(cell);
                    cell = VisitedCells.Last();
                    VisitedCells.RemoveAt(VisitedCells.Count - 1);
                }
            } while (UnvisitedCells.Count != 0);
        }

        private void BrakeWall(Cell currCell, Cell nearCell)
        {
            if (currCell.X > nearCell.X)
            {
                currCell.wall &= ~Wall.Left;
                nearCell.wall &= ~Wall.Right;
            }
            else if (currCell.X < nearCell.X)
            {
                currCell.wall &= ~Wall.Right;
                nearCell.wall &= ~Wall.Left;
            }
            else
            {
                if (currCell.Y > nearCell.Y)
                {
                    currCell.wall &= ~Wall.Up;
                    nearCell.wall &= ~Wall.Down;
                }
                else if (currCell.Y < nearCell.Y)
                {
                    currCell.wall &= ~Wall.Down;
                    nearCell.wall &= ~Wall.Up;
                }
            }
        }

        private Cell GetRandomCell(List<Cell> cells)
        {
            return cells[rand.Next(cells.Count)];
        }

        private List<Cell> GetNearUnvisiteedCells(Cell cell)
        {
            var nearCells = new List<Cell>();

            nearCells.Add(UnvisitedCells.SingleOrDefault(unvisited => unvisited.X + 1 == cell.X && unvisited.Y == cell.Y));
            nearCells.Add(UnvisitedCells.SingleOrDefault(unvisited => unvisited.X - 1 == cell.X && unvisited.Y == cell.Y));
            nearCells.Add(UnvisitedCells.SingleOrDefault(unvisited => unvisited.X == cell.X && unvisited.Y + 1 == cell.Y));
            nearCells.Add(UnvisitedCells.SingleOrDefault(unvisited => unvisited.X == cell.X && unvisited.Y - 1 == cell.Y));

            return nearCells.Where(x => x != null).ToList();
        }
    }
}
