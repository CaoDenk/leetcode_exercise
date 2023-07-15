﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 二分查找
    /// </summary>
    internal class _Search
    {
        public int Search(int[] nums, int target)
        {
            return Cur(0,nums.Length,nums,target);
        }
        /// <summary>
        /// 左边包含，右边不包含
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        int Cur(int start,int end,int[] nums,int target)
        {
            if(end-start==0)
            {
                    return -1;
            }

            int mid=(start+end)/2;
            if (nums[mid] == target)
                return mid;
            else if (nums[mid] > target)
                return Cur(start, mid, nums, target);
            else
                return Cur(mid+1, end, nums, target);

        }

        static void Main(string[] args)
        {
            _Search s = new();
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = 13;
            Console.WriteLine(s.Search(nums,target));
        }
    }
}
