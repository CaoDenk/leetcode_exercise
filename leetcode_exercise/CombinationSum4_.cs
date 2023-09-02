using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 377. 组合总和 Ⅳ
    /// 挖坑怎么去重
    /// </summary>
    internal class CombinationSum4_
    {
        
        public int CombinationSum4(int[] nums, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            for(int i=1;i<=target;++i)
            {
                for(int j=0;j<nums.Length;++j)
                {
                    if (i - nums[j]>=0)
                    {
                        dp[i] += dp[i - nums[j]];
                    }
                }
            }
            return dp[^1];
        }
        static void Main(string[] args)
        {
            CombinationSum4_ c = new();
            Console.WriteLine(c.CombinationSum4(new int[] {1,2,3},4));
            Console.WriteLine(c.CombinationSum4(new int[] {9},3));
        }

    }
}
