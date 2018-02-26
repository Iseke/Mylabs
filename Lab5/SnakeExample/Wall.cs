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

   public class Wall :GameObject
    {
        public Wall(Point firstpoint, ConsoleColor color, char sign) : base(firstpoint, sign, color)

        {



        }
        public Wall()
        {

        }
       
        public void LoadLevel(GameLevel level) {

            string name = "";
            switch (level)
            {
                
                   
                case GameLevel.zero:
                    name = "Level0.txt";
                    break;
                case GameLevel.first:
                    name = "Level1.txt";
                    break;
                   
                case GameLevel.second:
                    name = "Level2.txt";
                    break;
                case GameLevel.third:
                    name = "Level3.txt";
                    break;
                default:
                    break;
            }
            FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            this.body.Clear();
            int y = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for(int x=0;x<line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        this.body.Add(new Point { X = x, Y = y });
                    }
                }
                y++;

            }
            sr.Close();
            fs.Close();
         }
    }
}
