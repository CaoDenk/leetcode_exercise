using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 135. 分发糖果
    /// </summary>
    internal class Candy_
    {
        public int Candy(int[] ratings)
        {
            int[] dp= new int[ratings.Length];
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else if (ratings[i] == ratings[i - 1])
                {
                    dp[i] = dp[i - 1];
                } else
                {
                    if (dp[i-1]==0)
                    {
                        ++dp[i - 1];
                    }

                }


            }

            Console.WriteLine(string.Join(",",dp));

            return dp.Sum()+ratings.Length;
        }

        static void Main(string[] args)
        {
            Candy_ c = new();
            int[] rate = { 1, 2, 87, 87, 87, 2, 1 };
            int res=c.Candy(rate);
            Console.WriteLine(res);
        }
    }
}
