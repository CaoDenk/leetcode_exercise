using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2240. 买钢笔和铅笔的方案数
    /// </summary>
    internal class WaysToBuyPensPencils_
    {
        public long WaysToBuyPensPencils1(int total, int cost1, int cost2)
        {
            int[]  dp=new int[total+1];

            dp[0] = 1;
            long sum = 0;
          
            for(int j=cost1;j<=total;j+=cost1 )
            {
                int t = dp[j - cost1];
                dp[j] += t;
                sum+= t;
            }
            for (int j = cost2; j <= total; ++j)
            {
                int t  = dp[j - cost2];
                dp[j] += t;
                sum += t;
            }
            return sum+1;
        }

        public long WaysToBuyPensPencils(int total, int cost1, int cost2)
        {
            if (cost1 < cost2)
                (cost1, cost2) = (cost2, cost1);
            int cnt = 0;
            long res = 0;
            while(total-cost1*cnt>=0)
            {
                res += (total - cost1 * cnt) / cost2 + 1;
                ++cnt;
            }

            return res;

        }
        static void Main(string[] args)
        {
            WaysToBuyPensPencils_ w = new();
            Console.WriteLine(w.WaysToBuyPensPencils(20,10,5));
            Console.WriteLine(w.WaysToBuyPensPencils(100,1,1));
        }
       
    }
 
}
