using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 归并排序
    /// </summary>
    internal class MergeSort_
    {


        void MergeSort(int[] arr)
        {


        }
        public int[] SortArray(int[] nums)
        {
            var arrBlock = new int[nums.Length];
            MergeSort(nums,arrBlock,0,nums.Length-1);
            return nums;
        }

        void MergeSort(int[] arr, int[] arrBlock, int start, int end)
        {

            if (start >= end)
            {
                return;
            }
            int mid = (start + end) >> 1;
            int l1 = start;
            int l2 = mid + 1;
            MergeSort(arr, arrBlock, l1, mid);
            MergeSort(arr, arrBlock, l2, end);

            int k = 0;
            int len = end - start + 1;
            
            while (true)
            {
                if (l1 > mid)
                {
                    Array.Copy(arr, l2, arrBlock, start + k, len - k );
                    break;
                }
                if (l2 > end)
                {
                    Array.Copy(arr, l1, arrBlock, start + k, len - k);
                    break;
                }

                if (arr[l1] <= arr[l2])
                {
                    arrBlock[start+k] = arr[l1];
                    l1++;
                }
                else
                {
                    arrBlock[start + k] = arr[l2];
                    l2++;
                }
                ++k;
            }

            Array.Copy(arrBlock,start,arr,start,len);
        }
        static void Main(string[] args)
        {
            //{
            //    MergeSort_ m = new();
            //    var arr=m.SortArray(new int[] { 5, 2, 3, 1 });
            //    Console.WriteLine(string.Join(",",arr));
            //}
            {
                MergeSort_ m = new();
                var arr = m.SortArray(new int[] { 5, 1, 1, 2, 0, 0 });
                Console.WriteLine(string.Join(",", arr));
            }
        }

    }
}
