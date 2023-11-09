using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 34. 在排序数组中查找元素的第一个和最后一个位置
    /// </summary>
    internal class SearchRange_
    {
        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null||nums.Length==0) return new int[] { -1,-1};
            var idx=BinSearch(nums,0,nums.Length-1,target);
            if(idx<0) return new int[] { -1, -1 };

            int start = idx;
            int end = idx;
            while (start >= 0 && nums[start]==target) --start;
            while(end<nums.Length && nums[end]==target) ++end;

            return new int[] { start+1, end-1 };
        }
        //左右都包含
        int BinSearch(int[] nums,int start,int end,int target) 
        {
            if(start>end)return -1;
            int mid=(end+start)/2;
            if (nums[mid]==target)return mid;
            if (nums[mid] < target)return BinSearch(nums,mid+1,end,target);
            else return BinSearch(nums, start, mid-1, target);

        }

        static void Main(string[] args)
        {
            SearchRange_ s = new();
            {
                var arr = s.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
                Console.WriteLine(string.Join(",", arr));
            }
            {
                var arr = s.SearchRange(new int[] { 1 }, 1);
                Console.WriteLine(string.Join(",", arr));
            }
      
        }
    }
}
