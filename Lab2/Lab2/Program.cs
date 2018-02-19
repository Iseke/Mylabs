using System;
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
            List<int> list = new List<int>();
            int minx = 10000;
            int maxx = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                list.Add(int.Parse(numbers[i]));
            }
            for(int i = 0; i < list.Count; i++)
            {
                if (pros(i))
                {
                    if (i > maxx)
                    {
                        maxx = i;
                    }
                    if (i < minx)
                    {
                        minx = i;
                    }
                }
            }
            string m = "maximum number is:"+ maxx;
            string n = "\nminimum number is:"+minx;
            string v = m + n;
            Console.WriteLine( m);
            Console.WriteLine( n);
            File.WriteAllText(@"C:\Users\Islam\Desktop\Try\Lab1\prosto1.txt", v);

            //// sr.Close();
            // fs.Close();
        }


        static void Main(string[] args)
        {
            f1();
        }
        static bool pros(int x)
        {
            if ( x<=1) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;

        }
    }
}
