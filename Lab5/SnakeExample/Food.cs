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

    public class Food : GameObject
    {
                public Food() { }
        public Food(Point firstpoint , ConsoleColor color, char sign): base(firstpoint,sign,color)
        {

        }

        public void GenerateRandom()
        {
            Random rd = new Random();
            this.body[0] = new Point { X = rd.Next(1, 35), Y = rd.Next(1, 20) };
        }
       
    }
}
