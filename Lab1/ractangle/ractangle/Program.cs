using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ractangle
{
    class pryamougolnik
    {
      public  string  width;
       public string  height;
        public void cinInfo()
        {
            Console.WriteLine("Please write a width :");

            width = Console.ReadLine();

            Console.WriteLine("Please write a height :");


            height = Console.ReadLine();
         
        }
        public void findArea()
        {
            int a = int.Parse(width);
            int b = int.Parse(height);
            Console.WriteLine("Area:" + a * b);

        }
        public void findaPerimetr()
        {
            int a = int.Parse(width);
            int b = int.Parse(height);
            Console.WriteLine("Perimetr:" + 2*(a + b));

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            pryamougolnik s = new pryamougolnik();
            s.cinInfo();
            s.findaPerimetr();
            s.findArea();
        }
    }
}
