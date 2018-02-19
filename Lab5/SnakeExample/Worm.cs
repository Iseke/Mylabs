using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{
    [Serializable]
   public  class Worm:GameObject
    {
        public int DX { get; set; }
        public int DY { get; set; }
        public Worm()
        {

        }
        public Worm(Point firstpoint, char sign, ConsoleColor color) : base(firstpoint, sign, color)
        {
            DX = 0;
            DY = 0;
        }


        public void Move()
        {
            Point newheadpos = new Point { X = this.body[0].X + DX, Y = this.body[0].Y + DY };
            Console.SetCursorPosition(this.body[body.Count - 1].X, this.body[body.Count - 1].Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" ");
            for(int i=body.Count -1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            body[0] = newheadpos;
           
        }


        
    }
}
