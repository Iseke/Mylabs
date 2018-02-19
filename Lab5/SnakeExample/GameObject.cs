using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{

    public abstract class GameObject
    {
        public List<Point> body { get; set; }
        public char sign { get; set; }
        public ConsoleColor color { get; set; }
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
        public GameObject()
        {

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
        public void SaveGame()
        {
            Type t = this.GetType();
            string file = t.Name + ".xml";
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XmlSerializer xs = new XmlSerializer(t);
                xs.Serialize(fs, this);
            }
        }
        public GameObject Load()
        {
            GameObject res = null;
            Type t = this.GetType();
            string file = t.Name + ".xml";
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(t);
                res = xs.Deserialize(fs) as GameObject;
                

            }
            return res;
        }
    }
}
