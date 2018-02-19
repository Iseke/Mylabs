using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.CursorVisible = false;

            Game game = new Game();

            Console.SetWindowSize(game.boardW, game.boardH);

            Console.SetBufferSize(game.boardW, game.boardH);

            Menu menu = new Menu();
            menu.Process();
            
            
          
           
           
        }
        
     
       
       


    }
}
