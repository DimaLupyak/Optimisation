using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    public struct X
    {
        public X(double x1, double x2)
            : this()
        {
            X1 = x1;
            X2 = x2;
        }
        public double X1 { get; set; }
        public double X2 { get; set; }
        public static X operator +(X a, X b)
        {
            return new X(a.X1 + b.X1, a.X2 + b.X2);
        }
        public static X operator -(X a, X b)
        {
            return new X(a.X1 - b.X1, a.X2 - b.X2);
        }
        public static X operator /(X a, double b)
        {
            return new X(a.X1 / b, a.X2 / b);
        }
        public static X operator *(double b, X a)
        {
            return new X(a.X1 * b, a.X2 * b);
        }
        public override string ToString()
        {
            return String.Format("({0:0.000}:{1:0.000})", X1, X2);
        }
    }
}
