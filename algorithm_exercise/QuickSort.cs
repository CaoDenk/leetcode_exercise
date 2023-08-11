using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class QuickSort
    {

        void Sort(int[] nums)
        {



        }
        public int[] SortArray(int[] nums)
        {
            QuickSortCursive(nums,0,nums.Length-1);
            return nums;
        }
        /// <summary>
        /// 包含右边
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void QuickSortCursive(int[] nums,int start,int end) 
        { 
            if(start>=end)
            {
                return;
            }
            int mid=(start+end)>>1;

            while(true)
            {
                while (start<mid&&nums[start] < nums[mid])
                {
                    start++;
                }
                while (end >= mid && nums[end] > nums[mid])
                {
                    end--;
                }
              
                (nums[start], nums[end]) = (nums[end], nums[start]);
                
                if(start>=end)  
                {
                    //if (end >mid)
                    //{
                    //    (nums[end], nums[mid]) = (nums[mid], nums[end]);
                    //}
                    //else if (start < mid)
                    //{
                    //    (nums[start], nums[mid]) = (nums[mid], nums[start]);
                    //}
                        break;
                }
                   
            }
            //Console.WriteLine($"[{mid}]={nums[mid]}\t"+string.Join(",", nums));
            QuickSortCursive(nums, start, mid-1);
            QuickSortCursive(nums, mid+1, end);
        }

        static void Main(string[] args)
        {
            //{
            //    QuickSort m = new();
            //    var arr = m.SortArray(new int[] { 5, 2, 3, 1 });
            //    Console.WriteLine(string.Join(",", arr));
            //}
            {
                QuickSort m = new();
                var arr = m.SortArray(new int[] { 5, 1, 1, 2, 0, 0 });
                Console.WriteLine(string.Join(",", arr));
            }
            {
                QuickSort m = new();
                var arr = m.SortArray(new int[] { -2, 3, -5 });
                Console.WriteLine(string.Join(",", arr));
            }
        }


    }
}
