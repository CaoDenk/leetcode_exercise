using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 135. 分发糖果
    /// 效率太低，优化 继续优化
    /// </summary>
    internal class Candy_
    {
        public int Candy(int[] ratings)
        {
            int count = 0;
            int[] dp= new int[ratings.Length];
            
            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    dp[i] = dp[i - 1] + 1;
                    count += dp[i];
                }
                else if (ratings[i] < ratings[i-1])
                {

                    int k = i ;
                    do
                    {
                        if (dp[k - 1] <= dp[k])
                        {
                            dp[k - 1] = dp[k] + 1;
                            count++;
                        }
                        else
                            break;
                        --k;
                    } while (k - 1 >= 0 && ratings[k - 1] > ratings[k]);
                }
            }
            return count+ratings.Length;
        }

        static void Main(string[] args)
        {
            Candy2 c = new();
            {
                int[] rate = { 1, 2, 2 };
                int res = c.Candy(rate);
                Console.WriteLine(res == 4);
            }
            {
                int[] rate = { 1, 2, 87, 87, 87, 2, 1 };
                int res = c.Candy(rate);
                Console.WriteLine(res == 13);
            }
            {
                int[] rate = { 1, 3, 2, 2, 1 };
                int res = c.Candy(rate);
                Console.WriteLine(res == 7);
            }
            {
                int[] rate = { 0, 1, 2, 3, 2, 1 };
                int res = c.Candy(rate);
                Console.WriteLine(res );
            }
        }
    }
}
