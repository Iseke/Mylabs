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
        /* public void SaveGame()
          {
              using (FileStream fs = new FileStream("snake.xml", FileMode.Truncate, FileAccess.ReadWrite))
              {
                  XmlSerializer xs = new XmlSerializer(typeof(Game));
                  xs.Serialize(fs, this);
              }
          }
          public static Game LoadGame()
          {
              using ( FileStream fs =  new FileStream("snake.xml", FileMode.Open, FileAccess.Read))
              {
                  XmlSerializer xs = new XmlSerializer(typeof(Game));
                  Game game = xs.Deserialize(fs) as Game;
                  return game;
              }
          }*/
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
                    Console.SetCursorPosition(2, 13);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your score: " + (score - 1));
                    menu.Process();


                    break;
            }
        }
        public void Draw()
        {
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
                              
                                isalive = false;

                                t.Abort();
                           
                           
                                break;
                            }
                        }
                    }

                       
                        wall.Draw();
                        worm.Draw();
                        food.Draw();
                        Thread.Sleep(Game.speed);
                    

            }
        } 
    }
}
