using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class QuickSort_
    {
        private int[] SortArray(int[] nums)
        {
            QuickSort(nums,0, nums.Length-1);
            return nums;
        }

        public void QuickSort(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return;
            }
            int pivot = nums[left];  // 定义第一个数为基准数

            int i = left;
            int j = right;

            while (true)
            {
                while (i < j&&pivot <= nums[j]  )
                {  // 从右往左找比基准数小的
                    j--;
                }
                while (i < j&&pivot >= nums[i])
                {  // 从左往右找比基准数大的
                    i++;
                }
                if (i < j)
                {
                    (nums[j], nums[i]) = (nums[i], nums[j]);
                }
                else
                    break;
            }
            nums[left] = nums[i];  // i位置的数一定小于等于基准数，两者可以进行交换
            nums[i] = pivot;  // i位置为基准数的最终位置
            QuickSort(nums, left, i - 1);
            QuickSort(nums, i + 1, right);
        }

        static void Main(string[] args)
        {
            {
                QuickSort_ m = new();
                int[] nums = [5, 2, 3, 1];
                Console.WriteLine(string.Join(",", nums));
                var arr = m.SortArray(nums);
                Console.WriteLine(string.Join(",", arr));
            }
            //{
            //    QuickSort m = new();
            //    var arr = m.SortArray(new int[] { 5, 1, 1, 2, 0, 0 });
            //    Console.WriteLine(string.Join(",", arr));
            //}
            //{
            //    QuickSort m = new();
            //    var arr = m.SortArray(new int[] { -2, 3, -5 });
            //    Console.WriteLine(string.Join(",", arr));
            //}
            {
                QuickSort_ m = new();
                int[] nums = [-4, 0, 7, 4, 9, -5, -1, 0, -7, -1];
                Console.WriteLine(string.Join(",", nums));
                var arr = m.SortArray(nums);
                Console.WriteLine(string.Join(",", arr));
            }
        }

       
    }
}
