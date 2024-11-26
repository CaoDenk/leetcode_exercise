using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 11. 盛最多水的容器
    /// </summary>
    internal class MaxArea__
    {
        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length-1;
            int max = Math.Min(height[left] , height[right])*(right-left);

            while(left< right)
            {
                int lastLeftHeight = height[left];
                int lastRightHeight = height[right];
                if(height[left] < height[right])
                {
                    ++left;
                    if (left < right && height[left]>lastLeftHeight)
                    {
                        max=Math.Max(max, Math.Min(height[left], height[right]) * (right - left));
                    }

                }else
                {
                    --right;
                    if (left < right && height[right] > lastRightHeight)
                    {
                        max = Math.Max(max, Math.Min(height[left], height[right]) * (right - left));
                    }
                }
            }
            return max;
        }

        static void Main(string[] args)
        {

        }

    }

    

}
