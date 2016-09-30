using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public static class Fibonacci
    {
        public static double GetMin(Func<double, double> f, double a, double b, double eps)
        {
            double L, x1, x2, y1, y2;
            int k = 0, N=0;

            List<double> F = FibonacciGenerator.GenerateFibonacci().Select((x)=>(double)x).ToList();
            while (F[N]<b)
            {
                N++;
            }
            Console.WriteLine(new String('-', 88));
            Console.WriteLine("{0,55}{1,34}", "Fibonacci", "|");
            Console.WriteLine("{0,47}{1}, F[N] = {2}{3,30}", "N = ", N, F[N], "|");
            Console.WriteLine(new String('-', 88) + "|");
            Console.WriteLine(
                    "{0,3} |{1,10} |{2,10} |{3,10} |{4,10} |{5,10} |{6,10} |{7,10} |",
                    "k", "a", "b", "L", "x1", "x2", "y1", "y2");
            Console.WriteLine(
                   "{0}{1}{1}{1}{1}{1}{1}{1}",
                   "----|", "-----------|");
            x1 = a + F[N - 2] / F[N] * (b - a);
            x2 = a + F[N - 1] / F[N] * (b - a);
            do
            {
                k++;
                L = b - a;                
                y1 = f(x1);
                y2 = f(x2);

                Console.WriteLine(
                    "{0,3} |{1,10:0.000} |{2,10:0.000} |{3,10:0.00} |" +
                    "{4,10:0.00} |{5,10:0.00} |{6,10:0.00} |{7,10:0.00} |",
                    k, a, b, L, x1, x2, y1, y2);

                if (y1 <= y2)
                {
                    b = x2;
                    x2 = x1;
                    x1 = a + F[N - k - 2] / F[N - k] * (b-a);
                }
                else
                {
                    a = x1;
                    x1 = x2;
                    x2 = a + F[N - k - 1] / F[N - k] * (b - a);
                }
            }
            while (k != N-2);
            x1 = (a + b) / 2;
            x2 = x1 + eps;
            y1 = f(x1);
            y2 = f(x2);
            if (y1 <= y2) b = x2;            
            else a = x1;

            Console.WriteLine(new String('-', 88));
            return (a+b)/2;
        }

        public static double GetMax(Func<double, double> f, double a, double b, double eps)
        {
            return GetMin((x) => -f(x), a, b, eps);
        }
    }
}
