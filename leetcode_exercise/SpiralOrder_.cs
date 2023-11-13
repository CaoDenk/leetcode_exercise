using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    enum Direction
    {
        RIGHT=0,
        DOWN=1,
        LEFT=2,
        UP=3
    }
    internal class SpiralOrder_
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> ans = new List<int>();
            if (matrix.Length==1)
            {
                for(int j=0; j < matrix[0].Length; j++)
                    ans.Add(matrix[0][j]);
                return ans;
            }
            if (matrix[0].Length==1)
            {
                for (int i = 0; i < matrix.Length; i++)
                    ans.Add(matrix[i][0]);
                return ans;
            }
               
            bool[,] vis=new bool[matrix.Length,matrix[0].Length];
            
            int direct = 0;
            for(int j = 0; j < matrix[0].Length;++j)
            {
                ans.Add(matrix[0][j]);
                vis[0,j] = true;
            }
            int col = matrix[0].Length - 1;
            for (int i = 1; i < matrix.Length; ++i)
            {
                ans.Add(matrix[i][col]);
                vis[i, col] = true;
            }
            int row= matrix.Length - 1;
            for (int j = col-1; j >=0; --j)
            {
                ans.Add(matrix[row][j]);
                vis[row, j] = true;
            }
            for (int i = row; i >=1; --i)
            {
                ans.Add(matrix[i][0]);
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
            return ans;

        }
        bool Go(List<int> ans, int[][] matrix,Direction direction, bool[,] vis,ref int i,ref int j) 
        { 
            switch (direction)
            {
                case Direction.RIGHT:
                    {
                        if (vis[i,++j])
                        {
                            return false;
                        }
                        do
                        {
                            ans.Add(matrix[i][j]);
                            vis[i, j] = true;
                            j++;
                        } while (!vis[i, j]);
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
                            ans.Add(matrix[i][j]);
                            vis[i, j] = true;
                            i++;
                        } while (!vis[i, j]);
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
                            ans.Add(matrix[i][j]);
                            vis[i, j] = true;
                            j--;
                        } while (!vis[i, j]);
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
                            ans.Add(matrix[i][j]);
                            vis[i, j] = true;
                            i--;
                        } while (!vis[i, j]);
                    }
                    break;

            }
            return true;
        
        }

        static void Main(string[] args)
        {
            SpiralOrder_ s = new();
            int[][] matrix =
            [
                [1,2,3,4],
                [5, 6, 7, 8],
                [9,10,11,12],
                [13,14,15,16],
            ];
            var res =s.SpiralOrder(matrix);
            Console.WriteLine(string.Join(",",res));
        }
    }
}
