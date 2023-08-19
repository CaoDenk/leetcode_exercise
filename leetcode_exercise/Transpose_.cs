using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 867. 转置矩阵
    /// </summary>
    internal class Transpose_
    {
        public int[][] Transpose(int[][] matrix)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;
            int[][] result = new int[columnCount][];
            for (int i = 0; i < rowCount; i++)
            {
                result[i] = new int[rowCount];
            }
     
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    result[j][i] = matrix[i][j];
                }
            }
            return result;
        }
        void print(int[][] matrix)
        {
            foreach (var i in matrix)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }

        static void Main(string[] args)
        {
            int[][] arr = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
            Transpose_ t = new();
            var ret= t.Transpose(arr);
            foreach(var i in ret)
            {
                Console.WriteLine(string.Join(",",i));
            }
        }
    }
}
