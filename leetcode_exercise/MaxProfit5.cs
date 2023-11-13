using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 309. 买卖股票的最佳时机含冷冻期
    /// </summary>
    internal class MaxProfit5
    {
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2)
                return 0;
            int[,] dp = new int[prices.Length, 2];
            dp[0, 0] = -prices[0];
            dp[1,0] = Math.Max(dp[0, 0], - prices[1]);
            dp[1, 1] = Math.Max(dp[0, 0] + prices[1], dp[0,1]);
            for (int i = 2; i < prices.Length; ++i)
            {
                dp[i, 0] = Math.Max(dp[i - 2, 1] - prices[i], dp[i - 1, 0]);

                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i] );
            }
            return dp[prices.Length - 1, 1];
        }
        static void Main(string[] args)
        {
            MaxProfit5 m = new();
            Console.WriteLine(m.MaxProfit([1, 2, 3, 0, 2]));
        }
    }
}
