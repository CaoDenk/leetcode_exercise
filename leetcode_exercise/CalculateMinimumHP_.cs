using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 174. 地下城游戏
    /// 挖坑
    /// </summary>
    internal class CalculateMinimumHP_
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int rowCount=dungeon.Length;
            int colCount = dungeon[0].Length;
            int[,] dp = new int[rowCount+1, colCount+1];
            
            for(int i=0;i<dp.GetLength(0);i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                    dp[i, j] = int.MaxValue;
            }
            dp[rowCount - 1, colCount] = dp[rowCount, colCount - 1] = 1;
            for (int i = rowCount-1; i >=0;--i)
            {
                for (int j = colCount-1; j >=0; --j)
                {
                    dp[i, j] = Math.Min(dp[i + 1, j] , dp[i, j + 1])-dungeon[i][j];
                    dp[i, j] = Math.Max(1, dp[i, j]);
                }
                
            }

            return dp[0,0];

        }
        static void Main(string[] args)
        {
            CalculateMinimumHP_ c = new();
            {
                int[][] dungeon = [[-2, -3, 3], [-5, -10, 1], [10, 30, -5]];
                Console.WriteLine(c.CalculateMinimumHP(dungeon));

            }
        }
    }
}
