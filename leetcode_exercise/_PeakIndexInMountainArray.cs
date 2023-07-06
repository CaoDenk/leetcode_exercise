using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _PeakIndexInMountainArray
    {

        public int PeakIndexInMountainArray(int[] arr)
        {


            int left = 0;
            int right = arr.Length - 1;
            while(left < right)
            {

                int mid = (left+right)/ 2;
                if (arr[mid] < arr[mid+1])
                {
                    left = mid + 1;
                }else
                {
                    right = mid;
                }



            }


            return left;
        }


        static void Main()
        {

            _PeakIndexInMountainArray p = new();

            //test 1 
            int[] arr1 = { 1, 3, 5,3 };
            Console.WriteLine(p.PeakIndexInMountainArray(arr1)); ;

            int[] arr2 = { 0, 10, 5, 2 };
            Console.WriteLine(p.PeakIndexInMountainArray(arr2)); ;
        }
       

    }
}
