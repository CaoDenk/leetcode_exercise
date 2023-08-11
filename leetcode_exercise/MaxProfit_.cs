﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 123. 买卖股票的最佳时机 III
    /// </summary>
    internal class MaxProfit_
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            /*
            只进行过一次买操作；buy1 
            进行了一次买操作和一次卖操作，即完成了一笔交易；sell1

            在完成了一笔交易的前提下，进行了第二次买操作；buy2

            完成了全部两笔交易。sell2
             */
            int buy1 =-prices[0];
            int buy2=-prices[0];
            int sell1=0;
            int sell2=0;
            for(int i=1;i<prices.Length;++i)
            {
                buy1 = Math.Max(buy1, -prices[i]);
                sell1 = Math.Max(sell1, buy1 + prices[i]);
                buy2 = Math.Max(buy2, sell1 - prices[i]);
                sell2 = Math.Max(sell2, buy2 + prices[i]);


            }

            return sell2;
        }
    }
}