using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 188. 买卖股票的最佳时机 IV
    /// </summary>
    internal class MaxProfitIV
    {
        public int MaxProfit(int k, int[] prices)
        {
            int[] buy=new int[k];
            int[] sell=new int[k];
            for(int i=0; i<k; i++)
            {
                buy[i] = -prices[0];
            }

            for(int i=1;i<prices.Length;++i)
            {
                buy[0] = Math.Max(buy[0], -prices[i]);
                sell[0] = Math.Max(sell[0], buy[0]+prices[i]);
                for(int j=1;j<k;j++)
                {
                    buy[j] = Math.Max(buy[j], sell[j - 1] - prices[i]);
                    sell[j] = Math.Max(sell[j], buy[j] + prices[i]);
                }
            }

            return sell[^1];

        }
        static void Main(string[] args)
        {
            MaxProfitIV m = new();
            Console.WriteLine(m.MaxProfit(2,[3, 2, 6, 5, 0, 3]));
        }
    }
}
