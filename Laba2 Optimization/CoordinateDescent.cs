using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public static class CoordinateDescent
    {
        public static void GetMin(Func<double, double, double> f, double eps, out double x1, out double x2)
        {
            double h = 50, alpha = 2;
            x1 = 1;
            x2 = 1;
            Console.WriteLine(new String('-', 52));
            Console.WriteLine("{0,35}{1,18}", "Coordinate Descent", "|");
            Console.WriteLine(new String('-', 52) + "|");
            Console.WriteLine(
                            "{0,3} |{1,10} |{2,10} |{3,10} |{4,10} |",
                            "k", "x1", "x2", "h", "y");
            Console.WriteLine(
                   "{0}{1}{1}{1}{1}",
                   "----|", "-----------|");
            for (int k = 0; h > eps; k++ )
            {
                int direction; int i =0;
                do
                {
                    if (f(x1, x2) > f(x1 + h, x2))
                    {
                        direction = 1;
                    }
                    else if (f(x1, x2) > f(x1 - h, x2))
                    {
                        direction = -1;
                    }
                    else direction = 0;
                    if (direction != 0)
                    {
                        x1 += direction * h;
                        i++;
                    }
                }
                while (direction != 0 && i < 100);
                i = 0;
                do
                {
                    if (f(x1, x2) > f(x1, x2 + h))
                    {
                        direction = 1;
                    }
                    else if (f(x1, x2) > f(x1, x2 - h))
                    {
                        direction = -1;
                    }
                    else direction = 0;
                    if (direction != 0)
                    {
                        x2 += direction * h;
                        i++;
                    }
                }
                while (direction != 0 && i < 100);
                Console.WriteLine(
                            "{0,3} |{1,10:0.0000} |{2,10:0.0000} |{3,10:0.0000} |{4,10:0.0000} |",
                            k, x1, x2, h, f(x1,x2));
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
