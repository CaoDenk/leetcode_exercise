using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 213. 打家劫舍 II
    /// </summary>
    internal class Rob2
    {
        ///16.29开始 30分钟结束
        public int Rob(int[] nums)
        {
            if(nums.Length==1)return nums[0];
            if(nums.Length==2) return Math.Max(nums[0], nums[1]);

            int[] dp=new int[nums.Length+1];//截至到第i家最大的钱

           
            dp[1] = nums[0]; //第一家偷，计算下最大收益 

            for(int i=1;i<nums.Length;++i)
            {
 
                    dp[i+1] = Math.Max(dp[i - 1] + nums[i], dp[i]);

            }
            int max = dp[^2];
            Array.Clear(dp);
            //第一家不偷，计算下最大收益 

            for (int i = 1; i < nums.Length; ++i)
            {

                dp[i + 1] = Math.Max(dp[i - 1] + nums[i], dp[i]);

            }


            return Math.Max(max,dp[^1]);
        }


        static void Main(string[] args)
        {
            Rob2 r = new();
            Console.WriteLine(r.Rob([2, 3, 2]));
            Console.WriteLine(r.Rob([1, 2, 3, 1]));
            Console.WriteLine(r.Rob([1, 2, 3]));
        }
    }
}
