using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeExample
{

    public abstract class GameObject
    {
        public List<Point> body { get; }
        public char sign { get; }
        public ConsoleColor color { get; }
        public GameObject(Point firstpoint ,char sign,ConsoleColor color)
        {
            this.body = new List<Point>();
            if(firstpoint != null)
            {
                this.body.Add(firstpoint);
            }
            this.sign = sign;
            this.color = color;
        } 
       /*public void Clear()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }*/
        public void Draw()
        {
            //Console.Clear();
            Console.ForegroundColor = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }
        public bool IsBelongPoint(Point p)
        {
            bool res = false;
            for (int i = 0; i < this.body.Count; i++)
            {
                if(this.body[i].X== p.X && this.body[i].Y == p.Y)
                {
                    res = true;
                    break;
                }
                
            }
            return res;
        }
    }
}
