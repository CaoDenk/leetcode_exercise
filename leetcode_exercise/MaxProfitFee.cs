using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MaxProfitFee
    {
        /// <summary>
        /// 714. 买卖股票的最佳时机含手续费
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices, int fee)
        {
            int[,] dp = new int[prices.Length, 2];
                dp[0, 0] = -prices[0];
            for(int i=1;i<prices.Length;++i)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 1] - prices[i], dp[i-1, 0]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i] - fee);
            }
            return dp[prices.Length-1,1];
        }
        static void Main(string[] args)
        {
            MaxProfitFee m = new();
            Console.WriteLine(m.MaxProfit(new int[] { 1, 3, 2, 8, 4, 9 },2));
        }
    }
}
