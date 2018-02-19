using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        int a, b;

        public Complex()
        {
            a = 1;
            b = 1;
        }

        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static int GCD(int p, int q)
        {
            if (q == 0)
            {
                return p;
            }

            int r = p % q;

            return GCD(q, r);
        }

        static Complex Normalize(Complex c)
        {
            int n = GCD(Math.Abs(c.a), Math.Abs(c.b));
            c.a = c.a / n;
            c.b = c.b / n;
            return c;
        }

        public static Complex operator +(Complex x, Complex y)
        {
            Complex res = new Complex();
            res.a = x.a * y.b + x.b * y.a;
            res.b = x.b * y.b;

            res = Normalize(res);
            return res;
        }

        public override string ToString()
        {
            string s = null;
            if (b == 1)
            {
                s = $"{a}";
            }
            else if (b == 0)
            {
                s = "0";
            }
            else
            {
                s = $"{a}/{b}";
            }
            return s;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            int a, b;
            string[] arr = null;

            Console.WriteLine("Enter first complex as x/y:");
            string s1 = Console.ReadLine();
            arr = s1.Split('/', ' ');
            Complex x = new Complex(int.Parse(arr[0]), int.Parse(arr[1]));

            Console.WriteLine("Enter second complex as x/y:");
            string s2 = Console.ReadLine();
            arr = s2.Split('/', ' ');
            Complex y = new Complex(int.Parse(arr[0]), int.Parse(arr[1]));

            Complex c = new Complex();
            c = x + y;

            Console.WriteLine(c);
        }
    }
}