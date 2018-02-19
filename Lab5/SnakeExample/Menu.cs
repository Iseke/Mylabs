using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{
    class Menu
    {
       
        Game game = new Game();
        string[] items = { "New game","Load game" ,"Save game", "Settings","Exit" };
        int SelectItems = 0;
        Worm worm;
        Food food;
        void NewGame()
        {
            Console.Clear();
            game.Start();
            while (game.isalive)
            {
                ConsoleKeyInfo pressbutton = Console.ReadKey();
                game.Process(pressbutton);
            }
          

           // StatusBar.ShowInfo("NewGame");
        }

        void LoadGame()
        {


        }

        void SaveGame()
        {   
            
                 
        }

        void Settings()
        {
            ConsoleKeyInfo Sett = Console.ReadKey();

            Menu menu = new Menu();
            Console.Clear();

            Console.Write("Write speed of snake: ");
            string n= Console.ReadLine();
            int sp = int.Parse(n);
            Game.speed = sp;
            Console.ReadKey();
            Console.Clear();
            
            menu.Process();
           
            //StatusBar.ShowInfo("Settings!");
        }

        void Exit()
        {
            Console.Clear();
            Environment.Exit(0);
           // StatusBar.ShowInfo("Exit!");
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
          
            Console.SetCursorPosition(2, (game.boardH - 25) / 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('╔');
            for(int i = 0; i < 13; i++)
            {
                Console.Write('═');
            }
            Console.WriteLine('╗');
            for(int i = 0; i < items.Length; i++)
            {
                if (i == SelectItems)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write("  ║ "+String.Format("{0}) {1}", i, items[i]));
                for(int j =1; j < 15- (items[i].Length+5); j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine('║');
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  "+'╚');
            for (int i = 0; i < 13; i++)
            {
                Console.Write('═');
            }
            Console.WriteLine('╝');



        }

        public  void Process()
        {
            bool quit = false;
            while (!quit)
            {
                Draw();
                ConsoleKeyInfo pressbutton = Console.ReadKey();
                switch (pressbutton.Key)
                {
                    case ConsoleKey.UpArrow:
                        SelectItems--;
                        if (SelectItems < 0)
                        {
                            SelectItems = items.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        SelectItems++;
                        if (SelectItems > items.Length - 1)
                        {
                            SelectItems = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        quit = true;
                        switch (SelectItems)
                        {
                            case 0:
                                NewGame();

                                break;

                            case 1:

                                worm = worm.Load() as Worm;
                                food = food.Load() as Food;
                                break;
                            case 2:

                                worm.SaveGame();
                                food.SaveGame();

                                break;
                            case 3:
                                Settings();
                                break;
                            case 4:
                                Exit();
                                break;

                            default:
                                break;
                        }
                        break;
                    
                    default:
                        break;
                }
            }
        }

    }
}
