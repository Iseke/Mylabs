using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{
    public enum GameLevel
    {   
        
        zero,
        first,
        second,
        third
    }
    [Serializable]
    public class Game
    {
        [XmlElement]
        Wall wall;
        [XmlElement]
        Worm worm;
        [XmlElement]
        Food food;
        

        GameLevel gameLevel;
        public static int score = 1;
        public int score1;
        public int boardW = 35;
        public int boardH = 35;
        public static int speed { get; set; }
        

        ThreadStart ts;
        Thread t;
        public  void Start()
        {
            ts = new ThreadStart(Draw);
            t = new Thread(ts);
            t.Start();
        }

        void Stop()
        {
            t.Abort();
        }
      
        public bool isalive;
        public Game()
        {
            speed = 200;
            isalive = true;
            worm = new Worm(new Point { X = 13, Y = 13 }, '■', ConsoleColor.Blue);
            food = new Food(new Point { X = 11, Y = 11 }, ConsoleColor.Green, 'o');
            wall = new Wall(null, ConsoleColor.Red, 'Ô');

            gameLevel = GameLevel.zero;
            wall.LoadLevel(gameLevel);
            
        }



        public void Process(ConsoleKeyInfo button)
        {

            switch (button.Key)

            {

                case ConsoleKey.UpArrow:
                    worm.DX = 0;
                    worm.DY = -1;

                    break;
                case ConsoleKey.DownArrow:
                    worm.DX = 0;
                    worm.DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.DX = -1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.DX = 1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.Escape:
                    
                    t.Abort();

                    Console.Clear();
                    break;


            }
        }
        public void GmeSave()
        {
            StreamWriter sr = new StreamWriter(@"game.xml", false);
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            xs.Serialize(sr, this);
            sr.Close();
        }
        public Game GameLoad()
        {

            Game s = null;
            using (FileStream fs = new FileStream(@"game.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Game));
                 s = xs.Deserialize(fs) as Game;
            }

            return s;
        }
        public void Serial()
        {
            worm.SaveGame();
            food.SaveGame();
            wall.SaveGame();
            Console.Clear();
            Console.WriteLine("Game saved!!!");
            Console.ReadKey();
            Console.Clear();
        }
        public void Deserial()
        {
            wall = wall.Load() as Wall;
            food = food.Load() as Food;
            worm = worm.Load() as Worm;

        }
        string[] list = { " Yes  ", "  No " };
        int items = 0;
        public void WantToSave()
        {

            Console.SetCursorPosition(0, 5);
            for(int i = 0; i < list.Length; i++)
            {
                if (i == items)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                
                Console.Write(list[i]);
            }
            
           

        }
        public void WantsProcess(int num)
        {
            bool back = false;
            while (!back)
            {
                WantToSave();
                ConsoleKeyInfo it = Console.ReadKey();
                switch (it.Key)
                {
                    case ConsoleKey.RightArrow:
                        items++;
                        if (items > list.Length - 1)
                        {
                            items = 0;
                        }
                        break;
                   
                    case ConsoleKey.LeftArrow:
                        items--;
                        if (items < 0)
                        {
                            items = list.Length - 1;
                        }
                        break;
                        
                    case ConsoleKey.Enter:
                        back = true;
                        switch (items)
                        {
                            case 0:

                                Yes(num );
                                break;
                            case 1:
                                No();
                               // quite = true;


                                break;
                        }
                        break;
                }
            }
        }

        public void Yes(int num)
        {
            List<string> list = new List<string>();
            Console.Clear();
            Console.Write("Write your name : ");
            string s = Console.ReadLine();
            StreamReader chit = new StreamReader("Records.txt");
            string pow = chit.ReadToEnd();
            list.Add(pow);
            chit.Close();
             FileStream fs = new FileStream("Records.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sr = new StreamWriter(fs);
            string now = s + " " + num;
            list.Add(now);
            for(int i = 0; i < list.Count; i++)
            {
                sr.WriteLine(list[i]);
            }
                sr.Close();
                fs.Close();
            Console.Clear();
            //Environment.Exit(0);
            Menu menu = new Menu();

            menu.Process();



        }
        public void No()
        {
            Console.Clear();
            Menu menu = new Menu();

            menu.Process();
            
        }
        public void Draw()
        {

            wall.Draw();
            food.Draw();
            while (true) {
                worm.Move();
                if (worm.body[0].Equals(food.body[0]))
                {
                    Voice();
                    worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });

                    score++;
                    if (score % 5 == 0)
                    {
                            Console.Clear();
                            gameLevel++;
                            wall.LoadLevel(gameLevel);
                            Console.SetCursorPosition(0, 0);
                            wall.Draw();
                            worm.body.Clear();
                            worm.body.Add(new Point { X = 13, Y = 13 });
                            worm.Draw();
                    }

                    food.GenerateRandom();

                    while (wall.IsBelongPoint(food.body[0]) || worm.IsBelongPoint(food.body[0]))
                    {
                            food.GenerateRandom();
                    }
                        food.Draw();

                        Console.SetCursorPosition(4, 22);


                        Console.Write("Your score : " + (score - 1));
                        Console.SetCursorPosition(4, 21);
                        Console.WriteLine("Stage - " + gameLevel);
                }
                else
                {
                   foreach (Point p in wall.body)
                   {
                      if (p.Equals(worm.body[0]))
                      {
                            VoiceGameOver();


                           
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game Over!!!");
                            Console.WriteLine("Your score: " + (score - 1));
                            Console.WriteLine("Do want to save your result?");
                            WantsProcess(score-1);
                            score1 = score;
                            score = 1;
                            isalive = false;

                            Stop();
                           
                            
                           
                               
                      }
                   }
                }


                worm.Draw();

                Thread.Sleep(Game.speed);
                    

            }
        }
        public void Voice()
        {
            SoundPlayer sound = new SoundPlayer(@"C:\Users\Islam\Desktop\switch-20.wav");
            sound.Play();

        }
        public void VoiceGameOver()
        {
            SoundPlayer sound = new SoundPlayer(@"C:\Users\Islam\Desktop\Sound_06940_1_ (1).wav");
            sound.Play();

        }

    }
}
