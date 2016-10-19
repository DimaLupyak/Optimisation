using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    public class Function
    {
        public Func<double, double, double> f { private get; set; }
        public Func<double, double, double> fdx1 { private get; set; }
        public Func<double, double, double> fdx2 { private get; set; }

        public double F(double x1, double x2) { return f(x1, x2); }
        public double F(X x) { return f(x.X1, x.X2); }

        public double Fdx1(double x1, double x2) { return fdx1(x1, x2); }
        public double Fdx1(X x) { return fdx1(x.X1, x.X2); }

        public double Fdx2(double x1, double x2) { return fdx2(x1, x2); }
        public double Fdx2(X x) { return fdx2(x.X1, x.X2); }

        public double Norma(double x1, double x2) { return Math.Sqrt(fdx1(x1, x2) + fdx2(x1, x2)); }
        public double Norma(X x) { return Norma(x.X1, x.X2); }
    }

}
