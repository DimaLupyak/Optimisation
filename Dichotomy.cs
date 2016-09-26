using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public static class Dichotomy
    {
        public static double GetMin(Func<double, double> f, double a, double b, double eps)
        {
            double L, x1, x2, xm, y1, y2;
            int k = 0;
            xm = (a + b) / 2;
            Console.WriteLine(new String('-', 100));
            Console.WriteLine("{0,56}{1,45}", "Dichotomy", "|");
            Console.WriteLine(new String('-', 100) + "|");
            Console.WriteLine(
                    "{0,3} |{1,10} |{2,10} |{3,10} |{4,10} |{5,10} |{6,10} |{7,10} |{8,10} |",
                    "k", "a", "b", "L", "x1", "x2", "xm", "y1", "y2");
            Console.WriteLine(
                   "{0}{1}{1}{1}{1}{1}{1}{1}{1}",
                   "----|", "-----------|");
            do
            {
                k++;
                L = b - a;
                x1 = xm - eps / 2;
                x2 = xm + eps / 2;
                y1 = f(x1);
                y2 = f(x2);

                Console.WriteLine(
                    "{0,3} |{1,10:0.000} |{2,10:0.000} |{3,10:0.00} |" +
                    "{4,10:0.00} |{5,10:0.00} |{6,10:0.00} |{7,10:0.00} |{8,10:0.00} |",
                    k, a, b, L, x1, x2, xm, y1, y2);

                if (y1 <= y2) b = x2;
                else a = x1;
                xm = (a + b) / 2;
            }
            while (L > eps*2);
            Console.WriteLine(new String('-', 100));
            return xm;
        }   

        public static double GetMax(Func<double, double> f, double a, double b, double eps)
        {
            return GetMin((x) => -f(x), a, b, eps);
        }
    }
}
