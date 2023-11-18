using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 81. 搜索旋转排序数组 II
    /// </summary>
    internal class Search2
    {
        public bool Search(int[] nums, int target)
        {
            if (nums.Length <24)
            {
               foreach (int i in nums)
               {
                    if(i==target) return true;
               }
               return false;
            }

            int end = nums.Length - 1;
            int start = 0;
            return SearchRecur(nums, start, end, target);
        }


        bool SearchRecur(int[] nums, int start, int end, int target)
        {
            if (start >= end)
                return false;
            //Console.WriteLine($"start={start},end={end}");
            int mid = (start + end) / 2;
            if (target == nums[mid])
            {
                return true;
            }
            else
            {
                if (nums[start] < nums[mid])//左边是有序的
                {
                    if (target < nums[mid])
                    {
                        if (nums[start] == target)
                        {
                            return true;
                        }
                        if (nums[start] > target)
                            return SearchRecur(nums, mid + 1, end, target);
                        else
                            return BinSearch(nums, start, mid - 1, target);
                    }
                    else
                        return SearchRecur(nums, mid + 1, end, target);

                }
                else if (nums[start] > nums[mid])
                {
                    if (target > nums[mid])//右边是有序的
                    {
                        if (nums[end] == target)
                        {
                            return true;
                        }
                        if (nums[end] < target)
                            return SearchRecur(nums, start, mid - 1, target);
                        else
                            return BinSearch(nums, mid, end, target);
                    }
                    else
                        return SearchRecur(nums, start, mid - 1, target);
                }else //一个一个遍历
                {
                    foreach (int i in nums[start..end])
                    {
                        if (i == target)
                            return true;
                    }
                    return false;
                }


            }

        }
        bool BinSearch(int[] nums, int start, int end, int target)
        {
            if (start > end)
            {
                return false;
            }
            Console.WriteLine($"start={start},end={end}");
            int mid = (start + end) / 2;
            if (target == nums[mid])
            {
                return true;
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
            Search2 s = new();
            Console.WriteLine(s.Search([1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1],2));
        }
    }
}
