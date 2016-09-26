using System;
using System.Linq;

namespace Optimization
{
    class Program
    {
        static double f(double x)
        {
            return Math.Pow(x - 5, 2) + Math.Pow(Math.E, x / 2);
        }

        static void Main(string[] args)
        {
            double x = Dichotomy.GetMin(f, -10, 10, 0.1);
            double y = f(x);
            Console.WriteLine("x = {0:0.000} \t y(x) = {1:0.000}\n", x, y);

            x = Bisection.GetMin(f, -10, 10, 0.1);
            y = f(x);
            Console.WriteLine("x = {0:0.000} \t y(x) = {1:0.000}\n", x, y);

            x = GoldenSection.GetMin(f, -10, 10, 0.1);
            y = f(x);
            Console.WriteLine("x = {0:0.000} \t y(x) = {1:0.000}\n", x, y);

            x = Fibonacci.GetMin(f, -10, 10, 0.1);
            y = f(x);
            Console.WriteLine("x = {0:0.000} \t y(x) = {1:0.000}\n", x, y);

            Console.Read();
        }
    }
}
