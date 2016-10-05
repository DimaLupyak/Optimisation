using System;
using System.Collections;
using System.Collections.Generic;

namespace Optimization
{
    public static class DownhillSimplex
    {
        static double Alpha = 1;
        static double Betta = 0.5;
        static double Gamma = 2;
        public static void GetMin(Func<double, double, double> f, double eps, out double x1result, out double x2result)
        {
            Console.WriteLine(new String('-', 72));
            Console.WriteLine("{0,45}{1,28}", "Downhill Simplex", "|");
            Console.WriteLine(new String('-', 72) + "|");
            Console.WriteLine(
                            "{0,3} |{1,15} |{2,15} |{3,15} |{4,15} |",
                            "k", "xl", "xg", "xh", "yc");
            Console.WriteLine(
                   "{0}{1}{1}{1}{1}",
                   "----|", "----------------|");
            #region Ініціалізація
            int k = 0;
            X xh, xg, xl, xc, xr;
            X x1 = new X(-10, 10, f);
            X x2 = new X(10, 10, f);
            X x3 = new X(10, -10, f);
            xl = x1;
            xg = x2;
            xh = x3;
            #endregion

            #region 1 Сортування
        region1:
            k++;
            List<X> x = new List<X> { xl, xg, xh };
            x.Sort();
            xl = x[0];
            xg = x[1];
            xh = x[2];
            #endregion

            #region 2 Центр ваг
            xc = (xg + xl) / 2;
            #endregion

            #region 3 Відображення
            xr = (1 + Alpha) * xc - Alpha * xh;
            #endregion

            #region 4 Розтягування
            //4a
            if (xr.F < xl.F)
            {
                X xe = (1 - Gamma) * xc + Gamma * xr;
                if (xe.F < xl.F) xh = xe;
                else xh = xr;
                goto region8;
            }
            //4b
            else if (xl.F < xr.F && xr.F < xg.F)
            {
                xh = xr;
                goto region8;
            }
            //4c
            else if (xh.F > xr.F && xr.F > xg.F)
            {
                X tmp = xr;
                xr = xh;
                xh = tmp;
            }
            #endregion

            #region 5 Стиснення
            X xs = Betta * xh + (1 - Betta) * xc;
            #endregion

            #region 6
            if (xs.F < xh.F)
            {
                X tmp = xs;
                xs = xh;
                xh = tmp;
                goto region8;
            }
            #endregion

            #region 7 Стиснення симплексу
            else
            {
                xg = xl + (xg - xl) / 2;
                xh = xl + (xh - xl) / 2;
            }
            #endregion

            #region 8
        region8:
            double Sigma = Math.Sqrt((Math.Pow(xl.F - xc.F, 2) + Math.Pow(xg.F - xc.F, 2) + Math.Pow(xh.F - xc.F, 2)) / 4);
            Console.WriteLine(
                            "{0,3} |{1,15:0.0000} |{2,15:0.0000} |{3,15:0.0000} |{4,15:0.0000} |",
                            k, xl, xg, xh, xc.F);
            if (Sigma > eps)
            {
                goto region1;
            }
            #endregion
            x1result = xc.X1;
            x2result = xc.X2;
            Console.WriteLine(new String('-', 72));
        }

        public static void GetMax(Func<double, double, double> f, double eps, out double x1, out double x2)
        {
            GetMin((a, b) => -f(a, b), eps, out x1, out x2);
        }

        class X : IComparable<X>
        {
            private Func<double, double, double> f;
            public X(double x1, double x2, Func<double, double, double> func)
            {
                X1 = x1;
                X2 = x2;
                f = func;
            }
            public double X1 { get; set; }
            public double X2 { get; set; }
            public double F { get { return f(X1, X2); } }
            public static X operator +(X a, X b)
            {
                return new X(a.X1 + b.X1, a.X2 + b.X2, a.f);
            }
            public static X operator -(X a, X b)
            {
                return new X(a.X1 - b.X1, a.X2 - b.X2, a.f);
            }
            public static X operator /(X a, double b)
            {
                return new X(a.X1 / b, a.X2 / b, a.f);
            }
            public static X operator *(double b, X a)
            {
                return new X(a.X1 * b, a.X2 * b, a.f);
            }
            public int CompareTo(X other)
            {
                return F.CompareTo(other.F);
            }
            override public string ToString()
            {
                return String.Format("({0:0.00};{1:0.00})", X1, X2);
            }
        }
    }
}
