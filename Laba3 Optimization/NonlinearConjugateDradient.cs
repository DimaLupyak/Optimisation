using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    class NonlinearConjugateDradient
    {
        public static X GetMin(Function f, X x0, double Lambda, double eps)
        {
            X x = x0;
            X x_prev = x;
            int k = 0;
            X d = new X(0, 0);
            double Betta = 0;
            Console.WriteLine(new String('-', 84));
            Console.WriteLine("{0,55}{1,30}", "Nonlinear Conjugate Dradient Method", "|");
            Console.WriteLine(new String('-', 84) + "|");
            Console.WriteLine(
                            "{0,3} |{1,20} |{2,10} |{3,10} |{4,20} |{5,10} |",
                            "k", "x", "y", "Lambda", "G", "Norma");
            Console.WriteLine(
                   "{0}{2}{1}{1}{2}{1}",
                   "----|", "-----------|", "---------------------|");
            while (f.Norma(x) > eps)
            {
                Console.WriteLine(
                            "{0,3} |{1,20} |{2,10:0.0000} |{3,10:0.00} |{4,20} |{5,10:0.000} |",
                            k, x, f.F(x), Lambda, new X(f.Fdx1(x), f.Fdx2(x)), f.Norma(x));
                if(k == 0)
                {
                    //5
                    d = new X(-f.Fdx1(x0), -f.Fdx2(x0)); 
                }
                else
                {
                    //6
                    ///if (k % 2 == 0) Betta = 0;
                   // else
                    {
                        Betta = Math.Pow(f.Norma(x), 2) / Math.Pow(f.Norma(x_prev), 2);
                    }
                }
                //7
                d = new X(-f.Fdx1(x0) + Betta * d.X1, -f.Fdx2(x0) + Betta * d.X2);
                //8
                //TODO: Lambda calculation. Now is WRONG!!!
                Lambda = Dichotomy.GetMin((lambda) => (x.X1 + lambda * d.X1) + (x.X2 + lambda * d.X2), -100, 100, 0.1);
                //9
                x_prev = x;
                x = new X(x.X1 + Lambda * d.X1, x.X2 + Lambda * d.X2);
                //10
                k++;
            }
            Console.WriteLine(new String('-', 84));
            return x;
        }
    }
}
