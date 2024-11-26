using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 121. 买卖股票的最佳时机
    /// </summary>
    internal class MaxProfit_
    {
      
        public int MaxProfit(int[] prices)
        {
            int min = int.MaxValue;
            int mxProfit=0;
            for(int i=0; i<prices.Length;++i)
            {
                if (prices[i]<min)
                    min = prices[i];

                int j = prices[i] - min;
                if(mxProfit<j)
                    mxProfit = j;

            }
           return mxProfit;
            
        }

       

        static void Main(string[] args)
        {
            MaxProfit_ m = new();
            //Console.WriteLine(m.MaxProfit(new int[] {7, 1, 5, 3, 6, 4}));
            //Console.WriteLine(m.MaxProfit(new int[] {3, 3}));
            //Console.WriteLine(m.MaxProfit(new int[] {7, 2, 4, 1}));
            Console.WriteLine(m.MaxProfit(new int[] { 2, 4, 1 }));
            int[] arr = Array.Empty<int>();
            Console.WriteLine(m.MaxProfit(arr));
        }
    }
}
