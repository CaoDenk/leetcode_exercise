using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1631. 最小体力消耗路径
    /// 挖坑
    /// </summary>
    internal class MinimumEffortPath_
    {
        
        public int MinimumEffortPath(int[][] heights)
        {
            int[] dirs = {0,-1,0,1,0 };
             int r = heights.Length;
            int c= heights[0].Length;
            int[,] dp=new int[r,c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    dp[i, j] = int.MaxValue;
            }
            dp[0, 0] = 0;
            for (int k=0;k<Math.Max(r,c);k++)
            {
                for (int y= 0; y < r; y++)
                {
                    for (int x= 0; x< c; ++x)
                    {
                        for(int d=0;d<4;++d)
                        {
                           int tx = x + dirs[d];
                           int ty= y + dirs[d+1];
                            if (tx < 0 || tx >= c || ty < 0 || ty >= r)
                                continue;
                            dp[y,x] = Math.Min(dp[y, x], Math.Max(dp[ty, tx], Math.Abs(heights[ty][tx] - heights[y][x])));
                        }
                    }
                }
            }
           


            return dp[r-1,c-1];
        }
        static void Main(string[] args)
        {
            MinimumEffortPath_ m = new();
            {
                int[][] heights = [[1, 2, 2], [3, 8, 2], [5, 3, 5]];
                Console.WriteLine(m.MinimumEffortPath(heights));
            }
        }
    }
}
