using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 33. 搜索旋转排序数组
    /// </summary>
    internal class Search_
    {
        public int Search(int[] nums, int target)
        {
            if(nums.Length<10)
            {
               for(int i=0; i < nums.Length; i++)
                {
                    if (nums[i]==target)
                    {
                        return i;
                    }
                }
               return -1;
            }
         
            int end=nums.Length-1;
            int start = 0;
           return SearchRecur(nums, start, end,target);
        }

        int SearchRecur(int[] nums,int start, int end,int target) {
            if(start == end)
                return target == nums[start] ? start : -1;

            int mid = (start + end) / 2;
            if (target == nums[mid])
            {
                return mid;
            }
            else
            {
                if (nums[start] < nums[mid])//左边是有序的
                {
                    if (target < nums[mid])
                    {
                        if (nums[start]==target)
                        {
                            return start;
                        }
                        if (nums[start]>target)
                            return SearchRecur(nums, mid+1, end, target);
                        else
                            return BinSearch(nums, start, mid - 1, target);
                    }else
                        return SearchRecur(nums, mid + 1, end, target);

                }else //右边是有序的
                {
                    if (target > nums[mid])
                    {
                        if (nums[end]==target)
                        {
                            return end;
                        }
                        if (nums[end] < target)
                            return SearchRecur(nums,start,mid-1,target);
                        else
                            return BinSearch(nums, mid, end, target);
                    }else
                        return SearchRecur(nums, start, mid-1, target);
                }

            }

        }

        int BinSearch(int[] nums,int start,int end,int target) {
            if(start ==end) {
                return target == nums[start]?start: -1;
            }
            int mid=(start+end)/2;
            if (target == nums[mid])
            {
                return mid;
            }
            if (target < nums[mid])
            {
                return BinSearch(nums, start, mid - 1, target);
            }
            else
                return BinSearch(nums, mid + 1, end, target);

        }

        static void Main(string[] args)
        {
            Search_ s = new();
            //Console.WriteLine(s.Search(new int[] { 4, 5, 6, 7, 0, 1, 2 },0));
            //Console.WriteLine(s.Search(new int[] { 1,3 },0));
            Console.WriteLine(s.Search([15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14],25));
        }
    }
}
