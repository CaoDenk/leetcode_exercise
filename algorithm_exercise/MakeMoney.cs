using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 挖坑
    /// </summary>
    internal class MakeMoney
    {
        
        /// <summary>
        /// order是订单开始时间
        /// duration是订单所需时间
        /// money是订单对应的收入
        /// </summary>
        /// <param name="order"></param>
        /// <param name="time"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        static int Make(int[] order, int[] duration, int[] money)
        {

            int[] dp= new int[order.Length];
            dp[0] = money[0];
            for(int i=1;i<order.Length;++i)
            {
                int max = money[i];//计算当前订单最大收益

                for(int j=i-1;j>=0;--j)
                {
                    if (order[j] + duration[j] <= order[i])
                    {
                        max=Math.Max(max, dp[j] + money[i]);
                        break;
                    }

                }
                dp[i] = Math.Max(dp[i - 1], max);
            }
            return dp[^1];
        }

        static void Main(string[] args)
        {

            // orders 时间 1,3,6,7,11
            // time 往返时间 4，3，4，3，9
            // money  2，5，5，3，4  
            // out 14
            {
                int[] orders=[1, 3, 6, 7, 11];
                int[] time=[4,3,4,3,9];
                int[] money=[2,5,5,3,4];
                int res=Make(orders, time, money);
                Console.WriteLine(res);
            }
            {
                int[] orders = [1, 2,4,6];
                int[] time = [3,2,3,1];
                int[] money = [10,20,15,30];
                int res = Make(orders, time, money);
                Console.WriteLine(res);
            }
            {
                int[] orders = [1, 2, 3,];
                int[] time = [2, 2, 3,];
                int[] money = [1, 3, 3,];
                int res = Make(orders, time, money);
                Console.WriteLine(res);
            }
        }
    }
}
