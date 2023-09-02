using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 518. 零钱兑换 II
    /// </summary>
    internal class Change_
    {
        public int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;
            for(int i = 0; i < coins.Length;++i)
            {
                for(int j=coins[i];j<= amount; j++)
                {
                    dp[j] += dp[j - coins[i]];
                }
                Console.WriteLine(string.Join(",",dp));
            }
            return dp[^1];
        }
        static void Main(string[] args)
        {
            Change_ c = new();
            Console.WriteLine(c.Change(5,new int[] {1,2,5}));
        }
    }

}
