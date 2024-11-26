using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class NumTrees__
    {
        public  int NumTrees(int n)
        {
            return (int)(Cn(2 * n, n) / (n + 1));
        }

        static BigInteger Cn(int n,int m)
        {
            //long sum=
            BigInteger mul1 = 1;
            m = Math.Min(m, n - m);
            for(int i=n;i>n-m;--i)
            {
                mul1*=i;
            }
            BigInteger mul2 = 1;
            for(int i=2;i<=m;++i)
            {
                mul2*=i;
            }
            return (mul1/mul2);
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(Cn(6,4));
            //Console.WriteLine(Cn(18,9));

            //Console.WriteLine(NumTrees(19)>int.MaxValue);
        }


    }
}
