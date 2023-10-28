using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1155. 掷骰子等于目标和的方法数
    /// </summary>
    internal class NumRollsToTarget_
    {
        public int NumRollsToTarget(int n, int k, int target)
        {
            int[,] dp= new int[n, target+1];
            
            for(int j=1;j<=k&&j<=target;++j)
            {
                dp[0, j] = 1;
            }

            for (int i = 1; i < dp.GetLength(0); ++i)
            {
                for (int j = 1; j < dp.GetLength(1); ++j)
                {
                    for (int u = 1; u <= k; u++)
                    {
                        if (j - u > 0)
                        {
                            dp[i, j] += dp[i - 1, j - u] ;
                            dp[i, j] %= (10_0000_0000 + 7);
                        }
                    }
                       
                }
            }

            return dp[n-1,target];
        }
      
        static void Main(string[] args)
        {
            NumRollsToTarget_ n = new();
            {
                int res = n.NumRollsToTarget(2, 6, 7);
                Console.WriteLine(res);
            }
            {
                int res = n.NumRollsToTarget(1, 6, 3);
                Console.WriteLine(res);
            }
            {
                int res = n.NumRollsToTarget(30, 30, 500);
                Console.WriteLine(res);
            }
        }
    }
}
