using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 136. 只出现一次的数字
    /// </summary>
    internal class _SingleNumber
    {

        public int SingleNumber1(int[] nums)
        {
            Array.Sort(nums);
            for(int i = 0; i < nums.Length-1; i+=2)
            {
                if (nums[i + 1] != nums[i])
                    return nums[i];
            }
            return nums[^1];
        }
        public int SingleNumber(int[] nums)
        {
           int ret =0;
           foreach(var i in nums)
           {
                ret ^= i;
           }
            return ret;
        }
    }
}
