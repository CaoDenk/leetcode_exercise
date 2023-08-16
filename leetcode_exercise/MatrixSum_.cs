using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2679. 矩阵中的和
    /// </summary>
    internal class MatrixSum_
    {
        public int MatrixSum(int[][] nums)
        {
            foreach (int[] arr in nums)
            {
                Array.Sort(arr);

            }
            int colCount = nums[0].Length;
            int rowCount = nums.Length;
            int ans = 0;
            for(int col=0;col<colCount;++col)
            {
                int row = 0;
                int max = nums[row][col];
                for(row=1;row<rowCount;++row)
                {
                    max=Math.Max(max, nums[row][col]);
                }
                ans += max;

            }
            return ans;
        }
    }
}
