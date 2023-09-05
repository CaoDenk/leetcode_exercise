using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 75. 颜色分类
    /// </summary>
    internal class SortColors_
    {
        public void SortColors(int[] nums)
        {
            int[] color = new int[3];
            foreach (int i in nums)
            {
                ++color[i];
            }
            Array.Clear(nums);
           //Array.Fill(nums, 0, 0, color[0]);
            Array.Fill(nums, 1, color[0], color[1]);
            Array.Fill(nums, 2, color[0] + color[1], color[2] );

        }
     
    }
}
