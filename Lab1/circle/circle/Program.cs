using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circle
{
    class krug
    {
        public string radius;

        public void CInInfo()
        {
            Console.WriteLine("Please write a radius of circle: ");
            radius = Console.ReadLine();
        }

        public void findArea()
        {
            int n = int.Parse(radius);

            Console.WriteLine("Area: "+ Math.PI * n * n);
        }
        public void findDiametr()
        {
            int n = int.Parse(radius);
            Console.WriteLine("Diametr: " + 2 * n);
        }
        public void findCircumference()
        {
            int n = int.Parse(radius);
            Console.WriteLine("Circumference: " + Math.PI * 2 * n);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            krug s = new krug();
            s.CInInfo();
            s.findArea();
            s.findDiametr();
            s.findCircumference();
                
         
            
            
        }
    }
}
