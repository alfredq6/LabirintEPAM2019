using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabirintEPAM2019
{
    public class Game
    {
        private Labirint lab;
        private LabGenerator generator;
        private Hero hero;

        public void StartGame()
        {
            generator = new LabGenerator(20, 15);
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

        private void CheckOnAnyCoins()
        {
            if (!lab.Cells.OfType<Coin>().Any())
            {
                Console.WriteLine("Congratulation!");
                Console.WriteLine("Press any key to replay");
                var key1 = Console.ReadKey();

                StartNewGame();
                Drawer.Draw(lab);
            }
        }

        private void StartNewGame()
        {
            lab = generator.GetLabirint();
            hero.X = 0;
            hero.Y = 0;
        }
    }
}
