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

            for (int i = 0; i < labirint.Width + 2; i++)
            {
                WriteSide();
            }

            Console.WriteLine();


            for (int y = 0; y < labirint.Height; y++)
            {
                WriteSide();

                for (int x = 0; x < labirint.Width; x++)
                {
                    var currentCell = labirint[x, y];

                    if (hero.X == currentCell.X && hero.Y == currentCell.Y)
                    {
                        hero.Write();
                    }
                    else
                    {
                        currentCell.Write();
                    }
                }

                WriteSide();
                Console.WriteLine();
            }

            for (int i = 0; i < labirint.Width + 2; i++)
            {
                WriteSide();
            }
            Console.WriteLine();
            Console.WriteLine("Left to collect coin:" + labirint.Coins.Count);
        }



        private static void WriteSide()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("#");
        }
    }
}
