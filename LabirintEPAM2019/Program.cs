using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    class Program
    {
        static void Main(string[] args)
        {
            LabGenerator generator = new LabGenerator(5, 3);
            Labirint lab = generator.GetLabirint(generator.labirint.Width, generator.labirint.Height);
            ConsoleKeyInfo key;
            var hero = Hero.GetHero;
            while (true)
            {
                Drawer.Draw(lab);
                
                key = Console.ReadKey();
                switch(key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        {
                            hero.Step(lab, Direction.Up);
                            break;
                        }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        {
                            hero.Step(lab, Direction.Right);
                            break;
                        }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        {
                            hero.Step(lab, Direction.Down);
                            break;
                        }
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        {
                            hero.Step(lab, Direction.Left);
                            break;
                        }
                    case ConsoleKey.R:
                        {
                            lab = lab.Reset(hero);
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
