using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class FindMedianSortedArrays_
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] nums= new int[nums1.Length+nums2.Length];
            int k = 0;
            int i = 0; int j=0;
            while(k<nums.Length/2)
            {
                if (nums[i] < nums[j])
                    ++k;

            }

            return 0;
        }

    }
}
