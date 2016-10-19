using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    class Program
    {
        static Function f = new Function
        {
            f = (x1, x2) => x1 * x1 + x2 * x2 - x1 * x2,
            fdx1 = (x1, x2) => 2 * x1 - x2,
            fdx2 = (x1, x2) => 2 * x2 - x1
        };

        static X x0 = new X(10, 20);

        static void Main(string[] args)
        {
            X min = GradientDescent.GetMin(f, x0, 0.5, 0.001);
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
}
