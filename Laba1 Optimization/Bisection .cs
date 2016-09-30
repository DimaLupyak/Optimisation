using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public static class Bisection 
    {
        public static double GetMin(Func<double, double> f, double a, double b, double eps)
        {
            double L, x1, x2, xm, y1, y2, ym;
            int k = 0;
            Console.WriteLine(new String('-', 112));
            Console.WriteLine("{0,56}{1,57}", "Bisection", "|");
            Console.WriteLine(new String('-', 112) + "|");
            Console.WriteLine(
                    "{0,3} |{1,10:0.000} |{2,10:0.000} |{3,10:0.00} |" +
                    "{4,10:0.00} |{5,10:0.00} |{6,10:0.00} |{7,10:0.00} |{8,10:0.00} |{9,10:0.00} |",
                    "k", "a", "b", "L", "x1", "x2", "xm", "y1", "ym", "y2");
            Console.WriteLine(
                   "{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}",
                   "----|", "-----------|");
            L = b - a;
            do
            {
                k++;
                xm = (a + b) / 2;
                x1 = a + L/4;
                x2 = b - L/4;
                ym = f(xm);
                y1 = f(x1);
                y2 = f(x2);
                Console.WriteLine(
                    "{0,3} |{1,10:0.000} |{2,10:0.000} |{3,10:0.00} |" +
                    "{4,10:0.00} |{5,10:0.00} |{6,10:0.00} |{7,10:0.00} |{8,10:0.00} |{9,10:0.00} |",
                    k, a, b, L, x1, x2, xm, y1, ym, y2);
                if (y1 < ym) b = xm;
                else if (y2 < ym) a = xm;
                else { a = x1; b = x2; }
                L = b - a;
            }
            while (L > eps);
            Console.WriteLine(new String('-', 112));
            return (a+b)/2;
        }   

        public static double GetMax(Func<double, double> f, double a, double b, double eps)
        {
            return GetMin((x) => -f(x), a, b, eps);
        }
    }
}
