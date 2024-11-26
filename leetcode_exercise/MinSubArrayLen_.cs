using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 超时
    /// </summary>
    internal class MinSubArrayLen_
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            foreach (int i in nums)
            {
                if (i>=target )
                    return 1;
            }
            if(nums.Length>=2)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] + nums[i + 1] >= target)
                        return 2;
                }
            }
            if(nums.Length>=3)
            {
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (nums[i] + nums[i + 1] + nums[i + 2] >= target)
                        return 3;
                }
            }
            if(nums.Length>=4)
            {
                int sum = nums[0..3].Sum();

                for (int len = 4; len <= nums.Length; ++len)
                {

                    sum += nums[len - 1];
                    if (sum >= target)
                        return len;
                    int offset = len - 1;
                    int tsum = sum;
                    for (int i = 1; i < nums.Length - offset; ++i)
                    {
                        tsum = tsum - nums[i - 1] + nums[i + offset];
                        if (tsum >= target)
                        {
                            return len;
                        }

                    }
                }

            }
            return 0;
        }

        static void Main(string[] args)
        {
            MinSubArrayLen_ m = new();
            //Console.WriteLine(m.MinSubArrayLen(11,new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(m.MinSubArrayLen(15,new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(m.MinSubArrayLen(7,new int[] {  5 }));
        }
    }
}
