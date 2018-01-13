using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] val = s.Split(' ');
            int n = val.Length;
            for (int i = 0; i < n; i++)
            {
                if (pros(int.Parse(val[i])))
                {
                    Console.WriteLine(val[i]);
                }
            }



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
