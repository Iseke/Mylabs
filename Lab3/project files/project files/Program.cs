using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                s = "│  " + s;
            }
            else
            {
                s = s.Remove(15, s.Length - 15);
                s = "│  " + s + "...";
            }
            Console.Write(s);
            for (int j = 5; j <= 30 - s.Length; ++j)
            {
                Console.Write(' ');
            }

            Console.Write('│');
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }


        static void PrintState(int index, List<FileSystemInfo> arr)
        {

            Console.BackgroundColor = ConsoleColor.Black;
           // Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\n\n                    ");
            Console.SetCursorPosition(4, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Name");
            Console.WriteLine();
            
            for (int i = 0; i < arr.Count ; ++i)
            {
               
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('└');
            for (int m = 1; m < 26; m++)
            {
                Console.Write('─');
            }
            Console.Write('┘');
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  "+DateTime.Now);

            TaskBarInfo(index, arr);


        }
        static void TaskBarInfo(int index, List<FileSystemInfo> arr)
        {


            Console.SetCursorPosition(35, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Size");
            Console.SetCursorPosition(48, 2);
            Console.WriteLine("Last access");
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("Type");
           

            if (arr[index].GetType() == typeof(FileInfo))
            {
                GetFileSizeInfo(arr[index].FullName, index);
                Console.SetCursorPosition(48, index + 4);
                Console.WriteLine(arr[index].LastAccessTime);

                Console.SetCursorPosition(70, index + 4);
                Console.WriteLine(arr[index].Extension);
                Console.SetCursorPosition(0,0);
            }
            else
            {
                Console.SetCursorPosition(35, index + 4);
                Console.WriteLine(GetDirectorySize(arr[index].FullName) + " KB");
                Console.SetCursorPosition(48, index + 4);
                Console.WriteLine(arr[index].LastAccessTime);
                Console.SetCursorPosition(70, index + 4);
                Console.WriteLine(arr[index].Attributes);
                Console.SetCursorPosition(0, 0);

            }
        }

        static void GetFileSizeInfo(string s, int i)
        {
            Console.SetCursorPosition(35, i + 4);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            FileInfo file = new FileInfo(s);
            Console.Write("{0} KB", file.Length / 1024);
        }
        static long GetDirectorySize(string path)
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            long size = 0;
            foreach (string name in files)
            {
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }

            return size / 1024;
        }
        static void PrintFile(List<FileSystemInfo> arr, int i)
        {

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("If you want to open in window press : 1 ");
            Console.WriteLine("If you want to open in programm press : 2 ");
            ConsoleKeyInfo Press = Console.ReadKey();
            switch (Press.Key)
            {
                case ConsoleKey.D1:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    FileStream fs = null;
                    StreamReader sr = null;
                    try
                    {
                        fs = new FileStream(arr[i].FullName, FileMode.Open, FileAccess.Read);
                        sr = new StreamReader(fs);

                        Console.WriteLine(sr.ReadToEnd());
                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Cannot open file!");

                    }
                    finally
                    {
                        if (sr != null)
                        {
                            sr.Close();
                        }

                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    Process.Start(arr[i].FullName);
                    break;

            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        static void F(string put)
        {
            {
                DirectoryInfo di = new DirectoryInfo(@put);
                List<FileSystemInfo> arr = new List<FileSystemInfo>();
                arr.AddRange(di.GetDirectories());
                arr.AddRange(di.GetFiles());
               
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
                            if (index < 0) index = arr.Count - 1;
                            break;
                        case ConsoleKey.DownArrow:
                            index = (index + 1) % arr.Count;
                            break;
                        case ConsoleKey.Enter:
                            try
                            {
                                Console.Clear();
                                if (arr[index].GetType() == typeof(DirectoryInfo))
                                {
                                    DirectoryInfo d = arr[index] as DirectoryInfo;
                                    F(arr[index].FullName);
                                }
                                else if (arr[index].GetType() == typeof(FileInfo))
                                {
                                    PrintFile(arr, index);

                                }

                            }
                            catch (Exception e)
                            {
                                break;
                            }

                            break;
                        case ConsoleKey.Escape:

                          
                            quit = true;
                            break;
                        default:
                            break;
                    }
                }

                Console.Clear();
            }
        }


        static void Main(string[] args)
        {
            //Console.SetWindowSize(40,40);
            Console.CursorVisible = false;
            F(@"C:\Users\Islam\Desktop\c#");

        }
    }
}