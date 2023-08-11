using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 堆排序 挖坑
    /// </summary>
    internal class HeapSort_
    {


        public int[] SortArray(int[] nums)
        {
            HeapSort(nums);
            return nums;
        }

        public void HeapSort(int[] nums)
        {
            int len = nums.Length - 1;
            BuildMaxHeap(nums, len);
            for (int i = len; i >= 1; --i)
            {
                (nums[i], nums[0]) = (nums[0], nums[i]);
                len -= 1;
                MaxHeapify(nums, 0, len);
            }
        }

        public void BuildMaxHeap(int[] nums, int len)
        {
            for (int i = len / 2; i >= 0; --i)
            {
                MaxHeapify(nums, i, len);
            }
        }

        public void MaxHeapify(int[] nums, int i, int len)
        {
            for (; (i << 1) + 1 <= len;)
            {
                int lson = (i << 1) + 1;
                int rson = (i << 1) + 2;
                int large;
                if (lson <= len && nums[lson] > nums[i])
                {
                    large = lson;
                }
                else
                {
                    large = i;
                }
                if (rson <= len && nums[rson] > nums[large])
                {
                    large = rson;
                }
                if (large != i)
                {
                    (nums[i], nums[large]) = (nums[large], nums[i]);
                    i = large;
                }
                else
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            {
                //h.SortArray(arr);
                //Console.WriteLine(string.Join(",",arr));
            
            
            }
        }
    }
}
