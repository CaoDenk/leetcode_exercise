using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 62. 不同路径 
    /// </summary>
    internal class UniquePaths_
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1)
                return 1;

            int[,] dp = new int[m, n];
            for(int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for(int j=0; j < n; j++)
            {
                dp[0, j] = 1;
            }
            for(int i=1;i < m; i++)
            {
                for(int j=1; j < n;j++)
                {
                    dp[i, j] = dp[i - 1,j] + dp[i,j-1 ];
                }
            }
            return dp[m - 1, n - 1];
        }
      

        static void Main(string[] args)
        {
            //{
            UniquePaths_ u = new();
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
