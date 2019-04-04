using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    static class Game
    {
        private static Labirint lab;
        private static LabGenerator generator;
        private static Hero hero;

        public static void StartGame()
        {
            generator = new LabGenerator(5, 5);
            lab = generator.GetLabirint();
            ConsoleKeyInfo key;
            hero = Hero.GetHero;
            while (true)
            {
                Drawer.Draw(lab);

                CheckOnAnyCoins();

                key = Console.ReadKey();
                switch (key.Key)
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
                            StartNewGame();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                    default: break;
                }
            }
        }

        private static void CheckOnAnyCoins()
        {
            if (!lab.Coins.Any())
            {
                Console.WriteLine("Congratulation!");
                Console.WriteLine("Press any key to replay");
                var key1 = Console.ReadKey();

                StartNewGame();
                Drawer.Draw(lab);
            }
        }

        private static void StartNewGame()
        {
            lab = generator.GetLabirint();
            hero.X = 0;
            hero.Y = 0;
        }
    }
}
