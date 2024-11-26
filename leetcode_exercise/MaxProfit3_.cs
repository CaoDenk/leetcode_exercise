using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 121. 买卖股票的最佳时机
    /// 一支股票
    /// </summary>
    internal class MaxProfit3_
    {
        public int MaxProfit(int[] prices)
        {
            if(prices==null || prices.Length==0)
                return 0;
            int[,] dp=new int[prices.Length,2];
            //int result=0;
            dp[0, 0] = -prices[0];
            dp[0, 1] = 0;
            for(int i=1;i<prices.Length;++i)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], -prices[i]);
                dp[i, 1] = Math.Max(dp[i-1,0] + prices[i], dp[i-1,1]);
            }

            return dp[prices.Length-1,1];
        }

        

    }
}
