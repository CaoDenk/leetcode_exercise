using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// top k
    /// </summary>
    internal class FindKthLargest_
    {
        public int FindKthLargest(int[] nums, int k)
        {
            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }
        int QuickSelect(int[] nums, int left, int right, int k)
        {
            if (left >= right)
                return nums[left];
            int l = left - 1;
            int r = right + 1;
            while (l < r)
            {
                do
                {
                    ++l;
                }while (nums[l] < nums[left]);


                do
                {
                    --r;
                } while (nums[r] > nums[left]);

                if (l < r)
                {
                    (nums[l], nums[r]) = (nums[r], nums[l]);
                    Console.WriteLine($"交换 {nums[r]} {nums[l]};"+string.Join(",",nums));
                }
                else break;
            }
            if (k <= r)
            {
                return QuickSelect(nums, left, r, k);
            }
            else
            {
                return QuickSelect(nums, r + 1, right, k);
            }

        }
        static void Main(string[] args)
        {
            FindKthLargest_ f = new();
            {
                int[] arr = { 3, 2, 1, 5, 6, 4 };
                f.FindKthLargest(arr, 2);

            }
            {
                int[] arr = { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
                f.FindKthLargest(arr, 4);

            }


        }
    }
}
