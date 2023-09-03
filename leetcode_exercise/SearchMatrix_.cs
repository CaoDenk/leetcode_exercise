using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 74. 搜索二维矩阵
    /// </summary>
    internal class SearchMatrix_
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {

            if (target < matrix[0][0] || target > matrix[^1][^1])
                return false;

            return FindRecursive(matrix,0,matrix.Length-1,target);
        }
        /// <summary>
        /// 包含endline
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="startLine"></param>
        /// <param name="startPos"></param>
        /// <param name="endLine"></param>
        /// <param name="endPos"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        bool FindRecursive(int[][] matrix,int startLine,int endLine,int target)
        {
            if (startLine==endLine)
            {
                return Recurive(0, matrix[startLine].Length, matrix[startLine], target)!=-1;
            }
            int midLine = (startLine + endLine) / 2;
            if (target == matrix[midLine][^1])
                return true;
            if (target > matrix[midLine][^1])
            {
                return FindRecursive(matrix,midLine+1,endLine,target);
            }else
            {
                return FindRecursive(matrix,startLine, midLine, target);
            }

        }
        int Recurive(int start, int end, int[] nums, int target)
        {
            if (end - start == 0)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (nums[mid] == target)
                return mid;
            else if (nums[mid] > target)
                return Recurive(start, mid, nums, target);
            else
                return Recurive(mid + 1, end, nums, target);

        }
    }
}
