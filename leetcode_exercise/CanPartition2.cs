using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 416. 分割等和子集
    /// </summary>
    internal class CanPartition2
    {
        public bool CanPartition(int[] nums)
        {
            int sum=nums.Sum();
            int half =sum/2;
            if (half * 2 != sum)
                return false;
            int[] dp=new int[half+1];//背包容量被half，i

            for (int i = 1; i < nums.Length; ++i)
            {
                for (int j = half; j >=0; --j)
                {
                    if (j - nums[i] >= 0)
                    {
                        dp[j] = Math.Max(dp[j], dp[j - nums[i]] + nums[i]);
                    }
                }
                if (dp[half] == half)
                    return true;
                //Console.WriteLine(string.Join(",",dp));
            }

            return false;
        }
        static void Main(string[] args)
        {
            CanPartition2 c = new();
            //Console.WriteLine(c.CanPartition(new int[] { 1, 5, 11, 5 }));
            //Console.WriteLine(c.CanPartition(new int[] { 1, 2,3,5 }));
            Console.WriteLine(c.CanPartition(new int[] { 1, 2,5 }));
            Console.WriteLine(c.CanPartition(new int[] { 2, 2,1,1 }));
        }
    }
}
