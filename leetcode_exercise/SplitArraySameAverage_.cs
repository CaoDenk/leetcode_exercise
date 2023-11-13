using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 805. 数组的均值分割
    /// 挖坑 超时
    /// </summary>
    internal class SplitArraySameAverage_
    {
        public bool SplitArraySameAverage(int[] nums)
        {
            int total = nums.Sum();
            bool flag = false;
            Dfs(nums, 0, 0, 0, total, ref flag);

            return flag;
        }
        void Dfs(int[] nums, int count, int i, int sum, int total, ref bool flag)
        {

            if (count != 0 && (total - sum) * count == sum * (nums.Length - count))
            {
                flag = true;
                return;
            }
      
            if (i + 1 >= nums.Length)
            {
                return;
            }

            Dfs(nums, count + 1, i + 1, sum + nums[i], total, ref flag);
            if (flag)
            {
                return;
            }
            Dfs(nums, count, i + 1, sum, total, ref flag);
        }
        static void Main(string[] args)
        {
            SplitArraySameAverage_ s = new();
            Console.WriteLine(s.SplitArraySameAverage([1, 2, 3, 4, 5, 6, 7, 8]));
            Console.WriteLine(s.SplitArraySameAverage([3, 1]));
            Console.WriteLine(s.SplitArraySameAverage([9990, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30]));
        }


    }
}
