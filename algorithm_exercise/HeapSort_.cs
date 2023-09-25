using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 堆排序
    /// </summary>
    internal class HeapSort_
    {
        public int[] SortArray(int[] nums)
        {

            int len = nums.Length - 1;
            BuildMaxHeap(nums, len);
            while (len >= 1)
            {
                (nums[len], nums[0]) = (nums[0], nums[len]);
                MaxHeapfy(nums, 0, --len);
            }
            return nums;
        }
        void BuildMaxHeap(int[] nums, int len)
        {
            for (int i = len / 2; i >= 0; --i)
            {
                MaxHeapfy(nums, i, len);
            }
        }

        /// <summary>
        /// 包含len,让i这个结点还有其孩子服从大顶堆特点
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="len"></param>
        void MaxHeapfy(int[] nums, int i, int len)
        {
            while ((i << 1) + 1 <= len)
            {
                int larger = i;
                int lson = (i << 1) + 1;
                int rson = (i << 1) + 2;
                if (lson <= len && nums[lson] > nums[i])
                {
                    larger = lson;
                }
                if (rson <= len && nums[rson] > nums[larger])
                {
                    larger = rson;
                }
                if (larger != i)//再交换后新成为原i的孩子的也要判断下是不是最大堆
                {
                    (nums[larger], nums[i]) = (nums[i], nums[larger]);
                    i = larger;
                }
                else break;

            }
        }
        

        static void Main(string[] args)
        {
            HeapSort_ h = new();
            {
                var arr = new int[] { -4, 0, 7, 4, 9, -5, -1, 0, -7, -1 };
                Console.WriteLine(string.Join(",",arr));
                h.SortArray(arr);
                Console.WriteLine(string.Join(",",arr));
            }
        }
    }
}
