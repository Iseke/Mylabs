using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_files
{
    class Program
    {
        static void StateInfo(int index, DirectoryInfo[] arr)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetType() == typeof(FileSystemInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (index == i)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write("|  ");

                Console.Write(arr[i].Name);

                for (int j = 1; j < 20 - arr[i].Name.Length; ++i)
                {
                    Console.Write(' ');
                }
                Console.WriteLine('|');
            }

            
        }
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Islam\Desktop\c#");
            DirectoryInfo[] dir = di.GetDirectories();
            int index = 0;
            bool quite = false;
            while (!quite)
            {
                StateInfo(index, dir);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0)
                        {
                            index = dir.Length - 1;
                            
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        index = (index + 1) % dir.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (dir[index].GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = dir[index] as DirectoryInfo;
                            dir = d.GetDirectories();
                            index = 0;
                        }
                        break;
                    case ConsoleKey.Escape:
                        quite = true;
                        break;


                    default:
                        break;
                }
            }
        }
    }
}
