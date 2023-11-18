using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2760. 最长奇偶子数组
    /// 挖坑
    /// </summary>
    internal class LongestAlternatingSubarray_
    {

            public int LongestAlternatingSubarray(int[] nums, int threshold)
            {
                int res = 0, dp = 0;
                for (int l = nums.Length - 1; l >= 0; l--)
                {
                    if (nums[l] > threshold)
                    {
                        dp = 0;
                    }
                    else if (l == nums.Length - 1 || nums[l] % 2 != nums[l + 1] % 2)
                    {
                        dp++;
                    }
                    else
                    {
                        dp = 1;
                    }
                    if (nums[l] % 2 == 0)
                    {
                        res = Math.Max(res, dp);
                    }
                }
                return res;
            }


        static void Main(string[] args)
        {
            LongestAlternatingSubarray_ l = new();
            {
                int[] nums = [3, 2, 5, 4];
                int threshold = 5;
                Console.WriteLine(l.LongestAlternatingSubarray(nums,threshold));
            }
            {
                int[] nums = [2];
                int threshold = 2;
                Console.WriteLine(l.LongestAlternatingSubarray(nums, threshold));
            }
        }
    }
}
