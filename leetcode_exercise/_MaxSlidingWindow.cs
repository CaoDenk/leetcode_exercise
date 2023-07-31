using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 滑动窗口最大值
    /// </summary>
    internal class _MaxSlidingWindow
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {

            int[] result = new int[nums.Length-k+1];
            for(int i=0;i<result.Length;++i)
            {

                result[i] = nums[i..(i + k)].Max();
            }
            return result;
        }
    }
}
