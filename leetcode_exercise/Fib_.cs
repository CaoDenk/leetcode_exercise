﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class Fib_
    {
        public int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;

            List<BigInteger> ints = new() { 1, 1, 2 };
            for (int i = 3; i < n; i++)
            {
                var sum = ints[^1] + ints[^2];
                ints.Add(sum);
            }

            return (int)(ints[^1]% 1000000007);
        }
    }
}
