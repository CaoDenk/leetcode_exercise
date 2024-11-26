using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1991. 找到数组的中间位置
    /// </summary>
    internal class FindMiddleIndex_
    {
        /// <summary> 
        /// arr[i,0] 左边之和 包含自己，arr[i,1] 右边之和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMiddleIndex(int[] nums)
        {
            int[,] arr = new int[nums.Length, 2];
            int sum = nums[1..].Sum();
            arr[0, 0] = nums[0];
            arr[0, 1] = sum;
            if (arr[0, 0] == arr[0, 1])
                return 0;
            for(int i=1; i<nums.Length; i++)
            {
                arr[i,1] -= nums[i];
                if (arr[i, 0]==arr[i,1])
                    return i;
                arr[i, 0] += nums[i];
            }
            return -1;
        }

        static void Main(string[] args)
        {
            FindMiddleIndex_ f = new();
            {
                int idx=f.FindMiddleIndex([2, 3, -1, 8, 4]);
                Console.WriteLine(idx);
            }
        }
    }
}
