using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 349. 两个数组的交集
    /// </summary>
    internal class _Intersection
    {
        public int[] Intersection(int[] nums1, int[] nums2) => nums1.Intersect(nums2).ToArray();
    }
}
