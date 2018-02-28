using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace complex

{

    [Serializable]

    public class Cplex

    {

        public int a, b;



        public Cplex() { }

        public Cplex(int _a, int _b)

        {

            a = _a;

            b = _b;

        }



        public static Cplex operator +(Cplex x, Cplex y)

        {

            Cplex res = new Cplex();



            res.a = y.b * x.a + x.b * y.a;

            res.b = x.b * y.b;

            if (res.a > res.b)

            {

                for (int i = res.b; i > 0; --i)

                {

                    if (res.a % i == 0 && res.b % i == 0)

                    {

                        res.a = res.a / i;

                        res.b = res.b / i;

                    }

                }

            }

            else if (res.a < res.b)

            {

                for (int i = res.a; i > 0; --i)

                {

                    if (res.a % i == 0 && res.b % i == 0)

                    {

                        res.a = res.a / i;

                        res.b = res.b / i;

                    }

                }

            }



            return res;

        }



        public static Cplex operator -(Cplex x, Cplex y)

        {



            Cplex resvych = new Cplex();



            resvych.a = y.b * x.a - x.b * y.a;

            resvych.b = x.b * y.b;



            if (resvych.a > 0)

            {



                if (resvych.a > resvych.b)

                {

                    for (int i = 2; i <= resvych.b; ++i)

                    {

                        if (resvych.a % i == 0 && resvych.b % i == 0)

                        {

                            while (resvych.a % i == 0 && (resvych.b) % i == 0)

                            {

                                resvych.a = resvych.a / i;

                                resvych.b = resvych.b / i;

                            }

                        }

                    }

                }

                else if (resvych.a < resvych.b)

                {

                    for (int i = 2; i <= resvych.a; ++i)

                    {

                        if (resvych.a % i == 0 && resvych.b % i == 0)

                        {

                            while (resvych.a % i == 0 && resvych.b % i == 0)

                            {

                                resvych.a = resvych.a / i;

                                resvych.b = resvych.b / i;

                            }

                        }

                    }

                }

            }



            else if (resvych.a < 0)

            {

                if (Math.Abs(resvych.a) > Math.Abs(resvych.b))

                {

                    for (int i = 2; i <= Math.Abs(resvych.b); ++i)

                    {

                        if (resvych.a % i == 0 && resvych.b % i == 0)

                        {

                            while (resvych.a % i == 0 && (resvych.b) % i == 0)

                            {

                                resvych.a = resvych.a / i;

                                resvych.b = resvych.b / i;

                            }

                        }

                    }

                }

                else if (Math.Abs(resvych.a) < Math.Abs(resvych.b))

                {

                    for (int i = 2; i <= Math.Abs(resvych.a); ++i)

                    {

                        if (resvych.a % i == 0 && resvych.b % i == 0)

                        {

                            while (resvych.a % i == 0 && resvych.b % i == 0)

                            {

                                resvych.a = resvych.a / i;

                                resvych.b = resvych.b / i;

                            }

                        }

                    }

                }

            }

            return resvych;



        }



        public static Cplex operator /(Cplex x, Cplex y)

        {

            Cplex resdel = new Cplex();



            resdel.a = x.a * y.b;

            resdel.b = x.b * y.a;



            if (resdel.a > resdel.b)

            {

                for (int i = 2; i <= resdel.b; ++i)

                {

                    if (resdel.a % i == 0 && resdel.b % i == 0)

                    {

                        while (resdel.a % i == 0 && resdel.b % i == 0)

                        {

                            resdel.a = resdel.a / i;

                            resdel.b = resdel.b / i;

                        }

                    }

                }

            }

            else if (resdel.a < resdel.b)

            {

                for (int i = 2; i <= resdel.a; ++i)

                {

                    if (resdel.a % i == 0 && resdel.b % i == 0)

                    {

                        while (resdel.a % i == 0 && resdel.b % i == 0)

                        {

                            resdel.a = resdel.a / i;

                            resdel.b = resdel.b / i;

                        }

                    }

                }

            }



            return resdel;

        }





        public static Cplex operator *(Cplex x, Cplex y)

        {

            Cplex resm = new Cplex();

            resm.a = x.a * y.a;

            resm.b = x.b * y.b;



            if (resm.a > resm.b)

            {

                for (int i = 2; i <= resm.b; ++i)

                {

                    if (resm.a % i == 0 && resm.b % i == 0)

                    {

                        while (resm.a % i == 0 && resm.b % i == 0)

                        {

                            resm.a = resm.a / i;

                            resm.b = resm.b / i;

                        }

                    }

                }

            }

            else if (resm.a < resm.b)

            {

                for (int i = 2; i <= resm.a; ++i)

                {

                    if (resm.a % i == 0 && resm.b % i == 0)

                    {

                        while (resm.a % i == 0 && resm.b % i == 0)

                        {

                            resm.a = resm.a / i;

                            resm.b = resm.b / i;

                        }

                    }

                }

            }

            return resm;

        }



        public override string ToString()

        {

            return a + " " + b;

        }

    }



}