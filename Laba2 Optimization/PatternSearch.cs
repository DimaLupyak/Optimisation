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
            bool flagNewBasePoint = false;
            int h = 1;
            x1 = 1;
            x2 = 1;
            X xb = new X(x1, x2);
            X xiter = new X(x1, x2);
            X xtmp = new X(h, 0);

            double yb = f(xb.x1, xb.x2);
            double ymin = yb;

            while ( Math.Sqrt(h * h + h * h) > eps)
            {
                Console.WriteLine("Finding new basic point.");

                #region x1 change
                xtmp.x1 = -h;
                if (ymin > f((xtmp + xiter).x1, (xtmp + xiter).x2))
                {
                    xiter += xtmp;
                    flagNewBasePoint = true;
                }
                else
                {
                    xtmp.x1 = h;
                    if (ymin > f((xtmp + xiter).x1, (xtmp + xiter).x2))
                    {
                        xiter += xtmp;
                        flagNewBasePoint = true;
                    }
                    else 
                    {
                        xtmp.x1 = 0;
                        flagNewBasePoint = false;
                    }
                }
                ymin = f(xiter.x1, xiter.x2);
                #endregion

                #region x2 change
                xtmp.x2 = -h;
                if (ymin > f((xtmp + xiter).x1, (xtmp + xiter).x2))
                {
                    xiter += xtmp;
                    flagNewBasePoint = true;
                }
                else
                {
                    xtmp.x2 = h;
                    if (ymin > f((xtmp + xiter).x1, (xtmp + xiter).x2))
                    {
                        xiter += xtmp;
                        flagNewBasePoint = true;
                    }
                    else
                    {
                        xtmp.x2 = 0;
                        if (flagNewBasePoint == false) 
                        {
                            h /= 2;
                            Console.WriteLine("\tChange delta X = " + h + "\n");
                            continue;
                        }
                    }
                }
                ymin = f(xiter.x1, xiter.x2);
                #endregion

                Console.WriteLine("New basic point: " + xb.ToString() + "\nf(X) = " + f(xb.x1, xb.x2));

                Console.WriteLine("Jumping on the temple to new basic point.");

                while(f(xiter.x1, xiter.x2) < f(xb.x1, xb.x2))
                {
                    xb = xiter;

                    xiter += xtmp;
                    Console.WriteLine("New basic point: " + xb.ToString() + "\nf(X) = " + f(xb.x1, xb.x2));
                }
                flagNewBasePoint = false;
                xtmp.x1 = 0;
                xtmp.x2 = 0;
            }

            Console.WriteLine("The foundet point: " + xb.ToString() + "\nf(X) = " + f(xb.x1, xb.x2));
        
        }

        public static void GetMax(Func<double, double, double> f, double eps, out double x1, out double x2)
        {
            GetMin((a, b) => -f(a, b), eps, out x1, out x2);
        }
    }
}
