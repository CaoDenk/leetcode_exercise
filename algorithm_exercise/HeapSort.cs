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
    internal class HeapSort
    {

        void MakeHeap()
        {

        }
        void Sort(int[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                int j = i * 2 +2;
                if(j<arr.Length)
                {
                    if (arr[i] < arr[j])
                    {
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                }
            }


        }

        void MakeMaxHeap(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int l = (i << 2) + 1;
                int r = l + 1;
                //if (j < arr.Length)
                //{
                //    if (arr[i] < arr[j])
                //    {
                //        (arr[i], arr[j]) = (arr[j], arr[i]);
                //    }
                //}
            }
        }

    }
}
