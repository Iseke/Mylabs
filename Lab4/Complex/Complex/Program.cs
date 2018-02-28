using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;



namespace complex

{

    [Serializable]

    class Program

    {

        static void Main(string[] args)

        {

            F1();

        }

      



        private static void F1()

        {

            Console.WriteLine("Write the numeratore and denominator a: ");

            string line1 = Console.ReadLine();

            string[] linefor1 = line1.Split(' ');



            int a = int.Parse(linefor1[0]);

            int b = int.Parse(linefor1[1]);

            Console.WriteLine("Write a sign: ");

            string sign = Console.ReadLine();

            char znak = sign[0];

            Console.WriteLine("Write the numeratore and denominator b: ");

            string line2 = Console.ReadLine();

            string[] linefor2 = line2.Split(' ');



            int c = int.Parse(linefor2[0]);

            int d = int.Parse(linefor2[1]);



            Cplex c1 = new Cplex(a, b);

            Cplex c2 = new Cplex(c, d);

            Cplex result = c1 + c2;

            Cplex result1 = c1 - c2;

            Cplex resultdiv = c1 / c2;

            Cplex resultm = c1 * c2;

            if (znak == '+')
            {

                string summa = "Sum = " + result;

                Console.WriteLine(summa);

                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);

                XmlSerializer xs = new XmlSerializer(typeof(string));



                xs.Serialize(fs, summa);





                fs.Close();

            }

            if (znak == '-')
            {

                string raznost = "Diference = " + result1;

                Console.WriteLine(raznost);

                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);

                XmlSerializer xs = new XmlSerializer(typeof(string));



                xs.Serialize(fs, raznost);





                fs.Close();

            }

            if (znak == '*')
            {

                string multi = "Multiplication = " + resultm;

                Console.WriteLine(multi);

                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);

                XmlSerializer xs = new XmlSerializer(typeof(string));



                xs.Serialize(fs, multi);





                fs.Close();

            }

            if (znak == '/')
            {

                string delenie = "Division = " + resultdiv;

                Console.WriteLine(delenie);

                FileStream fs = new FileStream("complex.xml", FileMode.Truncate, FileAccess.ReadWrite);

                XmlSerializer xs = new XmlSerializer(typeof(string));



                xs.Serialize(fs, delenie);





                fs.Close();

            }















            Console.ReadKey();





        }

    }

}