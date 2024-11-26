using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MaxSubArray_
    {
        public int MaxSubArray(int[] nums)
        {
            int pre = nums[0], ans = nums[0];
            for(int i=1; i < nums.Length;++i)
            {
                if(pre>0)
                {
                    pre += nums[i];
                }
                ans = Math.Max(ans, pre);
            }
            return ans;
        }
    }
}
