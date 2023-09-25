using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2560. 打家劫舍 IV
    /// 等理解消化
    /// </summary>
    internal class MinCapability_
    {
        public int MinCapability(int[] nums, int k)
        {
            int lower = nums.Min();
            int upper = nums.Max();
            while (lower <= upper)
            {

                int middle=(lower+upper)/2;
                bool visted = false;
                int count = 0;
                foreach(int n in nums)
                {
                    if(!visted&&n<=middle)
                    {
                        ++count;
                        visted = true;
                    }
                }
                if(count>=k)
                {
                    upper = middle - 1;

                }else
                {
                    lower = middle + 1;
                }

            }

            return lower;
        }


    }
}
