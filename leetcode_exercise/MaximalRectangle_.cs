using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 85. 最大矩形
    /// 困难
    /// 挖坑
    /// </summary>
    internal class MaximalRectangle_
    {
        public int MaximalRectangle(char[][] matrix)
        {
            int rowCount = matrix.Length;
            int colCount= matrix[0].Length;
            int[] height= new int[colCount];
            int max = 0;
            for(int i=0; i<rowCount;++i)
            {
                for (int j = 0 ;j < colCount;++j)
                {
                    if (matrix[i][j]=='1')
                    {
                        ++height[j];
                    }else
                    {
                        height[j] = 0;
                    }

                }
                Console.WriteLine(string.Join(",",height));
                max =Math.Max(LargestRectangleArea(height), max);
            }


            return max;
        }

        public int LargestRectangleArea(int[] heights)
        {
            Stack<(int, int)> stack = new();//(pos,value)
            int[] h = new int[heights.Length + 2];
            Array.Copy(heights, 0, h, 1, heights.Length);
            stack.Push((0, 0));
            int max = 0;
            for (int i = 1; i < h.Length; ++i)
            {
                //Console.WriteLine(string.Join(",", stack.ToList()));
                if (h[i] >= stack.Peek().Item2)
                {
                    stack.Push((i, h[i]));
                }
                else
                {
                    do
                    {
                        int mid = stack.Pop().Item2;

                        int left = stack.Peek().Item1;
                        int area = mid * (i - left - 1);

                        max = Math.Max(max, area);

                    } while (stack.Count >= 2 && stack.Peek().Item2 >= h[i]);
                    stack.Push((i, h[i]));
                }
            }

            return max;
        }
        static void Main(string[] args)
        {
            MaximalRectangle_ m = new();
            {
                char[][] matrix =
                [
                    ['1', '0', '1', '0', '0'],
                    ['1', '0', '1', '1', '1'],
                    ['1', '1', '1', '1', '1'],
                    ['1', '0', '0', '1', '0'],
                ];
                var res = m.MaximalRectangle(matrix);
                Console.WriteLine(res);
            }
        
        }
    }
}
