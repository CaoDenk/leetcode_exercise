using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 64. 最小路径和
    /// </summary>
    internal class MinPathSum_
    {
        public int MinPathSum(int[][] grid)
        {
            int rowCount=grid.Length;
            int colCount = grid[0].Length;
            int[,] dp=new int[rowCount, colCount];
            dp[0, 0] = grid[0][0];
            for(int i=1;i<colCount;++i)
            {
                dp[0, i] = dp[0, i - 1] + grid[0][i];
            }
            for (int i = 1; i < rowCount; ++i)
            {
                dp[i, 0] = dp[i-1, 0] + grid[i][0];
            }
            for (int i=1;i<rowCount;++i)
            {
                for(int j=1;j<colCount;++j)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j] + grid[i][j], dp[i, j - 1] + grid[i][j]);
                }
            }
            return dp[rowCount-1,colCount-1];
        }
        static void Main(string[] args)
        {
            MinPathSum_ m = new();
            {
                int[][] grid = new int[3][]
                {
                    new int[]{1,3,1},
                    new int[]{1,5,1},
                    new int[]{4,2,1},
                };
               int res=  m.MinPathSum(grid);
                Console.WriteLine(res);
            }
        }
    }
}
