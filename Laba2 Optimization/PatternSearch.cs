using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public static class PatternSearch
    {
        public static void GetMin(Func<double, double, double> f, double eps, out double x1, out double x2)
        {
            double h = 50, alpha = 2;
            x1 = 1;
            x2 = 1;
            Console.WriteLine(new String('-', 52));
            Console.WriteLine("{0,35}{1,18}", "Pattern Search", "|");
            Console.WriteLine(new String('-', 52) + "|");
            Console.WriteLine(
                            "{0,3} |{1,10} |{2,10} |{3,10} |{4,10} |",
                            "k", "x1", "x2", "h", "y");
            Console.WriteLine(
                   "{0}{1}{1}{1}{1}",
                   "----|", "-----------|");
            for (int k = 0; h > eps; k++)
            {
                int directionX1, directionX2; 
                int i = 0;
                do
                {
                    //x1 direction
                    if (f(x1, x2) > f(x1 + h, x2))
                    {
                        directionX1 = 1;
                    }
                    else if (f(x1, x2) > f(x1 - h, x2))
                    {
                        directionX1 = -1;
                    }
                    else directionX1 = 0;
                    //x2 direction
                    if (f(x1, x2) > f(x1, x2 + h))
                    {
                        directionX2 = 1;
                    }
                    else if (f(x1, x2) > f(x1, x2 - h))
                    {
                        directionX2 = -1;
                    }
                    else directionX2 = 0;
                    //x1 move
                    if (directionX1 != 0)
                    {
                        x1 += directionX1 * h;
                        i++;
                    }
                    //x2 move
                    if (directionX2 != 0)
                    {
                        x2 += directionX2 * h;
                        i++;
                    }
                    if (directionX1 * directionX2 != 0)
                    {
                        Console.WriteLine(
                               "{0,3} |{1,10:0.0000} |{2,10:0.0000} |{3,10:0.0000} |{4,10:0.0000} |",
                               k, x1, x2, h, f(x1, x2));
                    }
                }
                while (directionX1 != 0 && directionX2 != 0 &&  i < 200);    
                h /= alpha;
            }
            Console.WriteLine(new String('-', 52));
        }

        public static void GetMax(Func<double, double, double> f, double eps, out double x1, out double x2)
        {
            GetMin((a, b) => -f(a, b), eps, out x1, out x2);
        }
    }
}
