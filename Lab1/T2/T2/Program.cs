using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace povtor
{
    class Student
    {
        public string name;
        public string sname;

        public double gpa;
        public string zap;
        public double gpa1;

        public Student(string name, string sname, double gpa, string zap, double gpa1)
        {
            this.name = name;
            this.sname = sname;
            this.gpa = gpa;
            this.zap = zap;
            this.gpa1 = gpa1;

        }

        public void CinInfo()
        {
            name = Console.ReadLine();
            sname = Console.ReadLine();
            gpa = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
        public void Coutinfo()
        {
            Console.WriteLine(name + " " + sname + " " + gpa + zap + gpa1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> vec = new List<Student>();
            Random r = new Random();
            int n = r.Next(1, 10);
            for (int i = 0; i < n; ++i)
            {
                double gpa = r.Next(0, 99);
                Student s = new Student("pupil" + i, "of Fit" + ":", r.Next(1, 4), ",", gpa);
                vec.Add(s);
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (vec[i].gpa > vec[j].gpa)
                    {
                        Student t = vec[i];
                        vec[i] = vec[j];
                        vec[j] = t;
                    }
                    else if (vec[i].gpa == vec[j].gpa && vec[i].gpa1 > vec[j].gpa1)
                    {
                        Student v = vec[i];
                        vec[i] = vec[j];
                        vec[j] = v;
                    }
                    //lkdjflgkdhfkghdgfg
                    ///gdsgdfghgsasdfkhgfdsadfghjghfdsadfdghj
                    ///sgfdhgfjkglhhjkgjfhdgsf
                    ///gdfhjfhdgs
                    //sfdgfhdjghdgsf
                    
                }
            }
            for (int i = 0; i < n; i++)
            {
                vec[i].Coutinfo();
            }
        }
    }
}
