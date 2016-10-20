using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    class FastGradientDescent
    {
        public static X GetMin(Function f, X x, double Lambda, double eps)
        {
            int k = 0;
            Console.WriteLine(new String('-', 84));
            Console.WriteLine("{0,55}{1,30}", "Fast Gradient Descent", "|");
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
                Lambda = Dichotomy.GetMin((lambda) => f.F(new X(x.X1 - lambda * f.Fdx1(x), x.X2 - lambda * f.Fdx2(x))), -100, 100, 0.1);
                x = new X(x.X1 - Lambda * f.Fdx1(x), x.X2 - Lambda * f.Fdx2(x));
                k++;                
            }
            Console.WriteLine(new String('-', 84));
            return x;
        }
    }
}
