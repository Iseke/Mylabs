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
        string[] items = { "New game","Load game" ,"Save game","Records", "Settings","Exit" };
        int SelectItems = 0;
       
        
        void NewGame()
        {
            Console.Clear();
            game.Start();
            if (game.isalive == true)
            {
                while (game.isalive)
                {
                    ConsoleKeyInfo pressbutton = Console.ReadKey();
                    game.Process(pressbutton);
                    if (pressbutton.Key == ConsoleKey.Escape)
                    {
                        Process();
                    }
                }
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

            Console.Clear();

            Console.Write("Write speed of snake: ");
            string n= Console.ReadLine();
            int sp = int.Parse(n);
            Game.speed = sp;
            Console.Clear();
            
            Process();
           
            //StatusBar.ShowInfo("Settings!");
        } 
        void Records()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string s= File.ReadAllText("Records.txt");
            Console.WriteLine(s);
            Console.ReadKey();
            Process();
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
                                Console.Clear();
                                game.GameLoad();
                                 game.Deserial();
                                 game.Start();
                                
                                    while (game.isalive)
                                    {
                                        ConsoleKeyInfo button = Console.ReadKey();
                                        game.Process(button);
                                        if (button.Key == ConsoleKey.Escape)
                                        {
                                            Process();
                                        }
                                    }



                                    break;
                                
                            case 2:
                                game.GmeSave();
                                game.Serial();
                                Process();
                                break;
                            case 3:
                                Records();
                                break;
                            case 4:
                                Settings();
                                break;
                            case 5:
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
