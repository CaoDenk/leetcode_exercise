using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 120. 三角形最小路径和
    /// </summary>
    internal class MinimumTotal_
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int len=triangle.Count;
            int[,] dp=new int[len+1,len+1];
  
            for(int i=len-1;i>=0;--i)
            {
                for(int j=0;j<=i;++j)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j], dp[i + 1, j + 1]) + triangle[i][j];
                }
            }

            return dp[0,0];
        }
    }
}
