using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 128. 最长连续序列
    /// 要求是O(n)
    /// </summary>
    internal class LongestConsecutive_
    {
        //排序时间复杂度O(nlogn)
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            Array.Sort(nums);
            int start = nums[0];
            int len = 1;
            int maxLen = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == start + 1)
                {
                    len++;
                    start++;
                }
                else if (nums[i] == start)
                {
                    continue;
                }
                else
                {
                    start = nums[i];
                    maxLen = Math.Max(maxLen, len);
                    len = 1;
                }
            }
            return Math.Max(maxLen, len);
        }
    }
}
