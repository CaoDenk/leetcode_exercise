using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class GenerateMatrix_
    {
        public int[][] GenerateMatrix(int n)
        {
            if (n == 1)
                return new int[1][] { new int[] { 1 } };
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                matrix[i] = new int[n];
            }
            SpiralOrder(matrix);
            return matrix;
        }
        int num = 1;
        enum Direction
        {
            RIGHT = 0,
            DOWN = 1,
            LEFT = 2,
            UP = 3
        }

        public void SpiralOrder(int[][] matrix)
        {
            List<int> ans = new List<int>();
            bool[,] vis = new bool[matrix.Length, matrix[0].Length];
            int direct = 0;
            for (int j = 0; j < matrix[0].Length; ++j)
            {
                matrix[0][j] = num++;
                vis[0, j] = true;
            }
          

            int col = matrix[0].Length - 1;
            for (int i = 1; i < matrix.Length; ++i)
            {
                matrix[i][col] = num++;
                vis[i, col] = true;
            }
         
            int row = matrix.Length - 1;
            for (int j = col - 1; j >= 0; --j)
            {
                matrix[row][j] = num++;
                vis[row, j] = true;
            }

            for (int i = row-1; i >= 1; --i)
            {
                matrix[i][0] = num++;
                vis[i, 0] = true;
            }
 
            int ii = 1;
            int jj = 0;
            while (true)
            {
                Direction direction = (Direction)(direct % 4);
                bool b = Go(ans, matrix, direction, vis, ref ii, ref jj);
                ++direct;
                if (!b)
                    break;
            }
        }
        bool Go(List<int> ans, int[][] matrix, Direction direction, bool[,] vis, ref int i, ref int j)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    {
                        if (vis[i, ++j])
                        {
                            return false;
                        }
                        do
                        {
                            matrix[i][j] = num++;
                            vis[i, j] = true;
                            j++;
                        } while (!vis[i, j]);
                        --j;
                    }
                    break;
                case Direction.DOWN:
                    {
                        if (vis[++i, j])
                        {
                            return false;
                        }

                        do
                        {
                            matrix[i][j] = num++;
                            vis[i, j] = true;
                            i++;
                        } while (!vis[i, j]);
                        --i;
                    }
                    break;
                case Direction.LEFT:
                    {
                        if (vis[i, --j])
                        {
                            return false;
                        }
                        do
                        {
                            matrix[i][j] = num++;
                            vis[i, j] = true;
                            j--;
                        } while (!vis[i, j]);
                        ++j;
                    }
                    break;
                case Direction.UP:
                    {
                        if (vis[--i, j])
                        {
                            return false;
                        }

                        do
                        {
                            matrix[i][j] = num++;
                            vis[i, j] = true;
                            i--;
                        } while (!vis[i, j]);
                        ++i;
                    }
                    break;

            }
            return true;
        }

        static void Main(string[] args)
        {
            GenerateMatrix_ g = new();
            var res= g.GenerateMatrix(3);
            foreach (var i in res)
            {
                Console.WriteLine(string.Join(",",i));
            }
        }
    }
}
