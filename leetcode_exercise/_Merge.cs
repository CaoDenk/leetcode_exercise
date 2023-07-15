using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 合并两个有序数组
    /// 88. 合并两个有序数组
    /// </summary>
    internal class _Merge
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            Array.Copy(nums2 ,0, nums1,m , n);
            Array.Sort(nums1);

        }
    }
}
