using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Fib
    {
        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;


            List<int> ints = new List<int>() { 1, 1, 2 };
            for (int i = 3; i < n; i++)
            {
                int sum = ints[^1] + ints[^2];
                ints.Add(sum);
            }

            return ints[^1];
        }
    }
}
