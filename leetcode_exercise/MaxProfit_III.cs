using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 123. 买卖股票的最佳时机 III
    /// </summary>
    internal class MaxProfit_III
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int buy1 = -prices[0]; //买1
            int buy2 = -prices[0];//买1 再买1
            int sell1 = 0;//买一 卖1
            int sell2 = 0;//卖2

            //buy1 = Math.Max(buy1, -prices[i]);
            //sell1 = Math.Max(sell1, buy1 + prices[i]);
            //buy2 = Math.Max(buy2, sell1 - prices[i]);
            //sell2 = Math.Max(sell2, buy2 + prices[i]);
            for (int i=1;i<prices.Length;++i)
            {
                buy1=Math.Max(buy1, - prices[i]);
                sell1 = Math.Max(sell1 , buy1 + prices[i]);
                buy2 =Math.Max(buy2, sell1 - prices[i]);
          
                sell2=Math.Max(sell2,buy2 + prices[i]);
            }


            return sell2;

        }
        static void Main(string[] args)
        {
            //3,3,5,0,0,3,1,4
            MaxProfit_III max = new();
            Console.WriteLine(max.MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }));
        }
    }
}
