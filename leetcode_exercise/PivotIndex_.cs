using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 724. 寻找数组的中心下标
    /// </summary>
    internal class PivotIndex_
    {
        public int PivotIndex(int[] nums)
        {
            int[,] arr = new int[nums.Length, 2];
            int sum = nums[1..].Sum();
            arr[0, 0] = 0;
            arr[0, 1] = sum;
            if (arr[0, 0] == arr[0, 1])
                return 0;
            for (int i = 1; i < nums.Length; i++)
            {
                arr[i, 1] = arr[i-1, 1]-nums[i];
                arr[i, 0] =arr[i-1,0]+  nums[i - 1];
                if (arr[i, 0] == arr[i, 1])
                    return i;             
            }
            return -1;
        }
        static void Main(string[] args)
        {
            PivotIndex_ f = new();

            //{
            //    int idx = f.PivotIndex(new int[] { 1, 2, 3});
            //    Console.WriteLine(idx);
            //}
            //{
            //    int idx = f.PivotIndex(new int[] { 2, 1, -1 });
            //    Console.WriteLine(idx);
            //}
            {
                int idx = f.PivotIndex([1, 7, 3, 6, 5, 6]);
                Console.WriteLine(idx);
            }
        }
    }
}
