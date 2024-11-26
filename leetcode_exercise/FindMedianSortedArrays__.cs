using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class FindMedianSortedArrays__
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var nums3=new int[nums1.Length+nums2.Length];
            Array.Copy(nums1 , nums3, nums1.Length);
            Array.Copy (nums2 , 0,nums3, nums1.Length, nums2.Length);
            Array.Sort(nums3);
            if (nums3.Length % 2 == 0)
                return (double)nums3[nums3.Length / 2 - 1] / 2 + (double)nums3[nums3.Length / 2] / 2;
            else
                return nums3[nums3.Length / 2];
        }
    }
}
