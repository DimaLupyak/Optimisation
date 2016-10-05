using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Program
    {
        static double f(double x1, double x2)
        {
            return x1*x1+x2*x2-x1*x2;
        }

        static void Main(string[] args)
        {
            double x1, x2;
            PatternSearch.GetMin(f, 0.0001, out x1, out x2);
            double y = f(x1, x2);
            Console.WriteLine("x1 = {0:0.000} \t x2 = {1:0.000} \t y(x) = {2:0.000}\n", x1, x2, y);
            Console.ReadKey();
        }      
    }
}
