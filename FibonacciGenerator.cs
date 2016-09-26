using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class FibonacciGenerator
    {
        public static IEnumerable<int> GenerateFibonacci()
        {
            int prev = 0;
            int current = 1;
            while (current < Int32.MaxValue - prev)
            {
                yield return current;
                int tmp = current;
                current = prev + current;
                prev = tmp;
            }
        }

        public static IEnumerable<int> GenerateFibonacci(int n)
        {
            int prev = 0;
            int current = 1;
            for (int i = 0; i < n; i++)
            {
                yield return current;
                int tmp = current;
                current = prev + current;
                prev = tmp;
            }
        }        
    }
}

//var fibonacciList = FibonacciGenerator.GenerateFibonacci(10).ToList();
//for (int i = 0; i < fibonacciList.Count; i++)
//{
//    Console.WriteLine("{0}: {1}", i, fibonacciList[i]);
//}
//Console.ReadLine();