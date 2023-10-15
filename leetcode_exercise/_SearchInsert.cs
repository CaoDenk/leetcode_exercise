using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _SearchInsert
    {

        public int SearchInsert(int[] nums, int target)
        {
            if (target < nums[0])
                return 0;
             if (nums[nums.Length - 1] <target)
                return nums.Length;
            return BinSearch(nums,target,0,nums.Length-1);
        }
        int BinSearch(int[] nums,int target,int left,int right)
        {
            //int left = 0, right = nums.Length - 1;
         
            int mid =(left+right)/2;
            if (nums[mid] == target)
                return mid;
            else if(nums[mid] < target)
            {
                left = mid+1;
              
            }
            else
            {
                right = mid;
            }

            if (left < right)
                return BinSearch(nums, target, left, right);
            else
                return left;



        }


        static void Main()
        {
            _SearchInsert searchInsert = new _SearchInsert();


            {
                int[] nums = new int[] { 1, 3, 5, 6 };
                int target = 5;
                int ret = searchInsert.SearchInsert(nums, target);

                Console.WriteLine(ret);
            }
            {
                int[] nums = new int[] { 1, 3, 5, 6 };
                int target = 2;
                int ret = searchInsert.SearchInsert(nums, target);

                Console.WriteLine(ret);
            }

            {
                int[] nums = new int[] { 1, 3, 5, 6 };
                int target = 7;
                int ret = searchInsert.SearchInsert(nums, target);

                Console.WriteLine(ret);
            }

            //{
            //    int[] nums = new int[] { 1};
            //    int target = 1;
            //    int ret = searchInsert.SearchInsert(nums, target);

            //    Console.WriteLine(ret);
            //}
        }
    }
}
