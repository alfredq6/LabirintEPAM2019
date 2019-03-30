using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Drawer
    {
        public static void Draw(Labirint labirint)
        {
            Console.Clear();
            var hero = Hero.GetHero;
            Walls walls = new Walls();
            Point point;
            Dictionary<Cell, Coin> RoadCoins = new Dictionary<Cell, Coin>();

            for (int y = 0; y < labirint.Height; y++)
            {
                walls.Write();

                for (int x = 0; x < labirint.Width; x++)
                {
                    var currCell = labirint[x, y];
                    walls.Write();

                    if (currCell.wall.HasFlag(Wall.Up))
                        walls.Write();
                    else
                    {
                        point = new Point(Console.CursorLeft, Console.CursorTop);
                        labirint.Road.Add(point);
                        point.Write();
                    }

                    walls.Write();
                }

                walls.Write();
                Console.WriteLine();
                walls.Write();

                for (int x = 0; x < labirint.Width; x++)
                {
                    var currCell = labirint[x, y];
                    if (currCell.wall.HasFlag(Wall.Left))
                        walls.Write();
                    else
                    {
                        point = new Point(Console.CursorLeft, Console.CursorTop);
                        labirint.Road.Add(point);
                        point.Write();
                    }

                    point = new Point(Console.CursorLeft, Console.CursorTop);
                    labirint.Road.Add(point);
                    if (labirint.Coins.Contains(currCell))
                    {
                        var coin = new Coin() { X = point.X, Y = point.Y };
                        RoadCoins.Add(currCell, coin);
                        coin.Write();
                    }
                    else
                        point.Write();

                    if (currCell.wall.HasFlag(Wall.Right))
                        walls.Write();
                    else
                    {
                        point = new Point(Console.CursorLeft, Console.CursorTop);
                        labirint.Road.Add(point);
                        point.Write();
                    }

                }

                walls.Write();
                Console.WriteLine();
                walls.Write();

                for (int x = 0; x < labirint.Width; x++)
                {
                    var currCell = labirint[x, y];
                    walls.Write();

                    if (currCell.wall.HasFlag(Wall.Down))
                        walls.Write();
                    else
                    {
                        point = new Point(Console.CursorLeft, Console.CursorTop);
                        labirint.Road.Add(point);
                        point.Write();
                    }

                    walls.Write();
                }

                walls.Write();
                Console.WriteLine();

                var lastPoint_X = Console.CursorLeft;
                var lastPoint_Y = Console.CursorTop;
                
                foreach (var coord in labirint.Road)
                {
                    if (hero.Y == coord.Y && hero.X == coord.X)
                    {
                        foreach (var _coin in RoadCoins)
                        {
                            if (coord.Y == _coin.Value.Y && coord.X == _coin.Value.X)
                            {
                                Console.CursorLeft = coord.X;
                                Console.CursorTop = coord.Y;
                                
                                RoadCoins.Remove(_coin.Key);
                                labirint.Coins.Remove(_coin.Key);
                                coord.Write();

                                Console.CursorLeft = lastPoint_X;
                                Console.CursorTop = lastPoint_Y;
                                break;
                            }

                        }
                        Console.CursorLeft = coord.X;
                        Console.CursorTop = coord.Y;

                        hero.Write();

                        Console.CursorLeft = lastPoint_X;
                        Console.CursorTop = lastPoint_Y;
                        break;
                    }
                }

            }
            if (labirint.Coins.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Congratulation!\nPress R to play again...");
                labirint = labirint.Reset(hero);
            }
        }
    }
}
