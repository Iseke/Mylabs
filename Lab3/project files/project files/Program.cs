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

        
        static void PrintState(int index, List<FileSystemInfo> arr)
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n\n\n                    ");
            Console.SetCursorPosition(26, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Name");
            Console.WriteLine();
            for (int i = 0; i < arr.Count; ++i)
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
            Console.SetCursorPosition(60, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Size");
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("Last access");
            Console.SetCursorPosition(95, 2);
            Console.WriteLine("Type");

            if (arr[index].GetType() == typeof(FileInfo))
            {
                GetFileSizeInfo(arr[index].FullName, index);
                Console.SetCursorPosition(70, index + 4);
               Console.WriteLine( arr[index].LastAccessTime );
       
                Console.SetCursorPosition(95, index + 4);
                Console.WriteLine(arr[index].Extension);
            
            }
            else 
            {
                GetDirSizeInfo(arr[index].FullName, index);
                Console.SetCursorPosition(70, index + 4);
                Console.WriteLine(arr[index].LastAccessTime );
                Console.SetCursorPosition(95, index + 4);
                Console.WriteLine(arr[index].Attributes);
            }

        }
       
       static void GetFileSizeInfo(string s, int i)
        {
            Console.SetCursorPosition(60, i+4);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            FileInfo file = new FileInfo(s);
            Console.Write("{0} KB", file.Length/1024 );
        }
        static void GetDirSizeInfo(string s, int i)
        {
            Console.SetCursorPosition(60, i + 4);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            DirectoryInfo di = new DirectoryInfo(s);
            Console.WriteLine(di.GetFileSystemInfos().Count() + " items");

        }

        static void F(string put)
        {
            {
                DirectoryInfo di = new DirectoryInfo(@put);
                List<FileSystemInfo> arr = new List<FileSystemInfo>();
                arr.AddRange(di.GetFiles());
                arr.AddRange(di.GetDirectories());
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
                                if (arr[index].GetType() == typeof(DirectoryInfo))
                                {
                                    DirectoryInfo d = arr[index] as DirectoryInfo;
                                    F(arr[index].FullName);
                                }
                                else if (arr[index].GetType() == typeof(FileInfo))
                                {
                                   
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
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
                                                fs = new FileStream(arr[index].FullName, FileMode.Open, FileAccess.Read);
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
                                            Process.Start(arr[index].FullName);
                                            break;

                                    } 

                          

                                }

                            }
                            catch(Exception e)
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
            
            F(@"C:\Users\Islam\Desktop\c#");
           
        }
    }
}