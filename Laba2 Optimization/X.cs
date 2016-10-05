using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public class X
    {
        public double x1;
        public double x2;

        public X(double x1, double x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public static X operator +(X a, X b)
        {
            return new X(a.x1 + b.x1, a.x2 + b.x2);
        }

        public override string ToString()
        {
            return Convert.ToString("x1 = " + x1 + ", x2 = " + x2);
        }
    }
}
