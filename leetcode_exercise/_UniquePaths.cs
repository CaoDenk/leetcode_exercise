using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 62. 不同路径 
    /// 效率太低了，需要重写下，c#会超时
    /// </summary>
    internal class _UniquePaths
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1)
                return 1;
            if (m>n)
            {
                (m, n) = (n, m);
            }
            return Recursive(m,n);
        }
        int Recursive(int m, int n) //m<n
        {
         
            if (m == 2)
                return n;
            if (n == 2)
                return m;
            else
                return Recursive(m - 1, n) + Recursive(m, n - 1);
        }
        long Cn(int m, int n)
        {
            long ret1=1,ret2=1;
            m=Math.Min(n-m,m);
            for(int i=n,j=1;j<=m;--i,++j )
            {
                ret1*=i;
                ret2*=j;
            }
            return ret1 / ret2; ;
        }

    
        int Tn(int m)
        {
            if (m == 2)
                return 2;
            else
                return Tn(m - 1) * 2;
        }

        static void Main(string[] args)
        {
            //{
            _UniquePaths u = new();
            //    Console.WriteLine(u.Cn(2, 7));
            //}
            {
                int ret = u.UniquePaths(3, 3);
                Console.WriteLine(ret);
            }
            {
                int ret = u.UniquePaths(4, 4);
                Console.WriteLine(ret);
            }
            {
                int ret = u.UniquePaths(3, 7);
                Console.WriteLine(ret);
            }
            {
                int ret = u.UniquePaths(10, 38);
                Console.WriteLine(ret);
            }
        }
    }
}
