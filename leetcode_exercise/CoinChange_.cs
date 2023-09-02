using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 322. 零钱兑换
    /// </summary>
    internal class CoinChange_
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                int min = int.MaxValue; ;
                foreach (var j in coins)
                {
                    if (i - j >= 0)
                    {
                        if (dp[i - j] < min)
                        {
                            min = dp[i - j];
                        }
                    }
                }
                if (min == int.MaxValue)
                {

                    dp[i] = int.MaxValue;
                }
                else
                    dp[i] = min + 1;
            }
            return dp[^1] == int.MaxValue ? -1 : dp[^1];
        }
        static void Main(string[] args)
        {
            CoinChange_ c = new();
            //{
            //    Console.WriteLine(c.CoinChange(new int[] {1,2,5},11));
            //}
            {
                Console.WriteLine(c.CoinChange(new int[] { 2 }, 3));
            }
            {
                Console.WriteLine(c.CoinChange(new int[] { 2 }, 4));
            }
        }
    }
}
