using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Program
    {
        static void Str(string s)
        {
            if (s.Length < 20)
            {
                s="|     " + s;
            }
            else
            {
                s = s.Remove(15, s.Length - 15);
                s = "|     " + s+"...";
            }
            Console.Write(s);
            for (int j = 5; j <= 40 - s.Length; ++j)
            {
                Console.Write(' ');
            }

            Console.Write('|');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
        
        static void PrintState(int index, FileSystemInfo[] arr)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\n\n                    ");
            for (int m = 0; m < 37; m++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write("                    ");
                
                
                
                if (arr[i].GetType() == typeof(DirectoryInfo))
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

                Str(arr[i].Name);

                

            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("                    ");
            for (int m = 0; m < 37; m++)
            {
                Console.Write('*');
            }
        }

        static void F(string put)
        {
            {
                DirectoryInfo di = new DirectoryInfo(@put);
                FileSystemInfo[] arr = di.GetFileSystemInfos();
                int index = 0;
                bool quit = false;

                while (!quit)
                {
                    PrintState(index, arr);

                    ConsoleKeyInfo pressedKey = Console.ReadKey();


                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            index--;
                            if (index < 0) index = arr.Length - 1;
                            break;
                        case ConsoleKey.DownArrow:
                            index = (index + 1) % arr.Length;
                            break;
                        case ConsoleKey.Enter:
                            if (arr[index].GetType() == typeof(DirectoryInfo))
                            {
                                DirectoryInfo d = arr[index] as DirectoryInfo;
                                F(arr[index].FullName);
                            }
                            break;
                        case ConsoleKey.Escape:
                            quit = true;
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            F(@"C:\Users\Islam\Desktop\c#");

        }
    }
}