﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_Optimization
{
    public static class GradientDescent
    {
        public static X GetMin(Function f, X x0, double Lambda, double eps)
        {
            X x = x0;
            X temp;
            int k = 0;
            Console.WriteLine(new String('-', 84));
            Console.WriteLine("{0,55}{1,30}", "Gradient Descent", "|");
            Console.WriteLine(new String('-', 84) + "|");
            Console.WriteLine(
                            "{0,3} |{1,20} |{2,10} |{3,10} |{4,20} |{5,10} |",
                            "k", "x", "y", "Lambda", "G", "Norma");
            Console.WriteLine(
                   "{0}{2}{1}{1}{2}{1}",
                   "----|", "-----------|", "---------------------|");
            while (f.Norma(x) > eps)
            {
                Console.WriteLine(
                            "{0,3} |{1,20} |{2,10:0.0000} |{3,10:0.00} |{4,20} |{5,10:0.000} |",
                            k, x, f.F(x), Lambda, new X(f.Fdx1(x), f.Fdx2(x)), f.Norma(x));
                double norma = f.Norma(x);
                temp = new X(x.X1 - Lambda * f.Fdx1(x), x.X2 - Lambda * f.Fdx2(x));
                if (f.F(temp) < f.F(x))
                {
                    k++;
                    x = temp;
                    continue;
                }
                else
                    Lambda /= 2;
            }
            Console.WriteLine(new String('-', 84));
            return x;
        }
    }
}
