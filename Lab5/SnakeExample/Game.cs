using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeExample
{
    enum GameLevel
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
        public void Stop()
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

                    Menu menu = new Menu();

                    menu.Process();


                    break;
            }
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
            bool quite = false;
            while (!quite)
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
                    case ConsoleKey.UpArrow:
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
                    case ConsoleKey.DownArrow:
                        items--;
                        if (items < 0)
                        {
                            items = list.Length - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (items)
                        {
                            case 0:

                                Yes(num);
                                quite = true;
                                break;
                            case 1:
                                No();
                                quite = true;
                                break;
                        }
                        break;
                }
            }
        }

        public void Yes(int num)
        {
            Console.Clear();
            Console.Write("Write your name : ");
            string s = Console.ReadLine();
            StreamReader chit = new StreamReader("Records.txt");
            string pow = chit.ReadToEnd();
            chit.Close();
             FileStream fs = new FileStream("Records.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter sr = new StreamWriter(fs);
            pow = pow + " " + s + " " + num;
            sr.WriteLine(pow);



            sr.Close();
            fs.Close();
            Console.Clear();
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

                        Console.ForegroundColor = ConsoleColor.White;
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
                            
                           
                           
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Game Over!!!");
                            Console.WriteLine("Your score: " + (score - 1));
                            Console.WriteLine("Do want to save your result?");
                            WantsProcess(score-1);
                            score = 1;
                            isalive = false;

                            Stop();
                           // break;
                           
                               
                      }
                   }
                }


                worm.Draw();

                Thread.Sleep(Game.speed);
                    

            }
        } 
    }
}
