using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    public static class Dichotomy
    {
        public static double GetMin(Func<double, double> f, double a, double b, double eps)
        {
            double L, x1, x2, xm, y1, y2;
            int k = 0;
            xm = (a + b) / 2;
            do
            {
                k++;
                L = b - a;
                x1 = xm - eps / 2;
                x2 = xm + eps / 2;
                y1 = f(x1);
                y2 = f(x2);
                if (y1 <= y2) b = x2;
                else a = x1;
                xm = (a + b) / 2;
            }
            while (L > eps*2);
            return xm;
        }   

        public static double GetMax(Func<double, double> f, double a, double b, double eps)
        {
            return GetMin((x) => -f(x), a, b, eps);
        }
    }
}
