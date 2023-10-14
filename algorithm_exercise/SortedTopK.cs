using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class SortedTopK<T>
    {
        public T[] FindTopK(T[] nums, int k,Comparison<T> cmp)
        {
            BuildKMinHeap(nums, k - 1,cmp);

            for (int i = k; i < nums.Length; ++i)
            {
                if (cmp(nums[k], nums[0])>0)
                {
                    (nums[i], nums[0]) = (nums[0], nums[i]);
                    MinHeapfy(nums, 0, k - 1,cmp);
                }
            }


            return nums[..k];
        }
        void BuildKMinHeap(T[] nums, int k,Comparison<T> cmp)
        {
            for (int i = k / 2; i >= 0; --i)
            {
                MinHeapfy(nums, i, k, cmp);
            }
        }

        void MinHeapfy(T[] nums, int i, int len,Comparison<T> cmp)
        {
            while ((i << 1) + 1 <= len)
            {
                int less = i;
                int lson = (i << 1) + 1;
                int rson = (i << 1) + 2;
                if (lson <= len && cmp(nums[lson], nums[i])<0)
                {
                    less = lson;
                }
                if (rson <= len && cmp(nums[rson], nums[less]) < 0)
                {
                    less = rson;
                }
                if (less != i)//再交换后新成为原i的孩子的也要判断下是不是最小堆
                {
                    (nums[less], nums[i]) = (nums[i], nums[less]);
                    i = less;
                }
                else break;

            }

        }
        static void Main(string[] args)
        {
            TopK t = new();
            {
                int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int k = 3;
                int[] topK = t.FindTopK(nums, k);
                Console.WriteLine(string.Join(",", topK));
            }
            {
                int[] nums = { 5, 3, 1, 9, 2, 4, 7, 8, 6 };
                int k = 4;

                int[] topK = t.FindTopK(nums, k);
                Console.WriteLine(string.Join(",", topK));
            }

        }
    }
}
