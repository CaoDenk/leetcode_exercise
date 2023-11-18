using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 73. 矩阵置零
    /// 优化空间
    /// </summary>
    internal class SetZeroes_
    {
        public void SetZeroes2(int[][] matrix)
        {
            bool[,]  shouldBeZeros=new bool[matrix.Length, matrix[0].Length];

            for(int i=0; i<matrix.Length; i++)
            {
                for(int j=0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j]==0)
                    {
                        for(int m=0;m<matrix.Length; m++)
                        {
                            shouldBeZeros[m, j] = true;
                        }
                        for(int n=0; n < matrix[0].Length; n++)
                        {
                            shouldBeZeros[i, n] = true;
                        }
                    }
                }
            }
            for(int i= 0; i<matrix.Length;i++)
            {
                for(int j=0;j< matrix[i].Length; j++)
                {
                    if (shouldBeZeros[i, j])
                    {
                        matrix[i][j] = 0;
                    }
                }
            }


        }
        public void SetZeroes1(int[][] matrix)
        {

            HashSet<int> row = new ();
            HashSet<int> col = new();
            for (int i=0;i<matrix.Length;++i)
            {
                for(int j = 0; j < matrix[0].Length;++j)
                {
                    if (matrix[i][j]==0)
                    {
                        row.Add(i);
                        col.Add(j);
                    }
                }
            }
           foreach(int i in row)
           {
                for(int j=0;j< matrix[0].Length;++j)
                {
                    matrix[i][j] = 0;
                }

            }
            foreach (int i in col)
            {
                for (int j = 0; j < matrix.Length; ++j)
                {
                    matrix[j][i] = 0;
                }

            }

        }

        public void SetZeroes(int[][] matrix)
        {
            bool flag ;
            const int ColFlag = int.MinValue+20;
            const int ColRowFlag = int.MinValue+51;
            for (int i=0;i<matrix.Length-1;++i)
            {
                flag= false;
                for(int j = 0; j < matrix[0].Length;++j)
                {
                    if (matrix[i][j]==0) //下移动
                    {
                        flag = true;
                        if (matrix[ ^ 1][j] is not 0 and not ColRowFlag )
                        {
                            matrix[^1][j] = ColFlag;
                        }else
                        {
                            matrix[^1][j]= ColRowFlag;
                        }
                    }
                }
                if(flag)
                {
                    Array.Fill(matrix[i], 0);
                }
            }
            flag = false;
            foreach (var i in matrix)
            {
                Console.WriteLine(string.Join(",", i));
            }
        
            for (int j = 0; j < matrix[0].Length; ++j)
            {
                if (matrix[^1][j]==ColFlag)
                {
                    for(int i=0; i < matrix.Length;++i)
                    {
                        matrix[i][j] = 0;
                    }
                }
                else if(matrix[^1][j] is 0 or ColRowFlag)
                {
                    for (int i = 0; i < matrix.Length; ++i)
                    {
                        matrix[i][j] = 0;
                    }
                    flag = true;
                }
            }
            if(flag)
            {
                Array.Fill(matrix[^1],0);
            }

        }

        static void Main(string[] args)
        {
            SetZeroes_ s = new();
            //{
            //    int[][] arr = new int[][] { new int[] { 1 }, new int[] { 0 } };
            //    s.SetZeroes(arr);
            //    foreach (var i in arr)
            //    {
            //        Console.WriteLine(string.Join(",", i));
            //    }
            //}
            //{//0,0,0,5],[4,3,1,4],[0,1,1,4],[1,2,1,3],[0,0,1,1
            //    int[][] arr = new int[][] { new int[] { 0, 0, 0, 5 }, new int[] { 4, 3, 1, 4 }, new int[] { 0, 1, 1, 4 }, new int[] { 1, 2, 1, 3 }, new int[] { 0, 0, 1, 1 } };
            //    s.SetZeroes(arr);
            //    foreach (var i in arr)
            //    {
            //        Console.WriteLine(string.Join(",", i));
            //    }
            //}
            {//0,0,8,9,5],[5,2,5,7,0],[4,8,0,8,7],[7,1,3,2,4],[1,2,4,8,4],[5,4,8,8,0],[8,0,1,8,0],[8,5,4,4,2],[4,0,1,7,8
                int[][] arr = [
                    [0, 0, 8, 9, 5],
                    [5, 2, 5, 7, 0],
                    [4, 8, 0, 8, 7],
                    [7, 1, 3, 2, 4],
                    [1, 2, 4, 8, 4],
                    [5, 4, 8, 8, 0],
                    [8, 0, 1, 8, 0],
                    [8, 5, 4, 4, 2],
                    [4, 0, 1, 7, 8]];
                s.SetZeroes(arr);
                foreach (var i in arr)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
        }
    }
}
