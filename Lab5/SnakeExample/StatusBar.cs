using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{
    class StatusBar
    {
        
        public static void ShowInfo(string info)
        {
            Game game = new Game();
            Console.SetCursorPosition(0, game.boardH - 2);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < game.boardW; ++i)
            {
                for (int j = game.boardW - 3; j <= game.boardW - 1; ++j)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, game.boardH - 2);
            Console.Write(info);
        }

        
    }
}
