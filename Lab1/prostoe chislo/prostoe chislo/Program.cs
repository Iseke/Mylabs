﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void f1()
        {
            /*FileStream fs = new FileStream(@"C:\Users\Islam\Desktop\Try\Lab1\prosto.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadToEnd();*/

            string s = File.ReadAllText(@"C:\Users\Islam\Desktop\Try\Lab1\prosto.txt");

            string[] numbers = s.Split(' ');
          
            for(int i = 0; i < numbers.Length; i++)
            {
                if (pros(int.Parse(numbers[i])))
                {
                    Console.WriteLine(numbers[i]);
                }
            }

           //// sr.Close();
           // fs.Close();
        }
      

        static void Main(string[] args)
        {
            f1();
        }
        static bool pros(int x)
        {
            if (x <= 0) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;

        }
    }
}
