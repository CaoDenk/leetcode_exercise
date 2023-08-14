using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class Rotate_
    {
        public void Rotate(int[][] matrix)
        {
            int len = matrix.Length;
            int n = len - 1;
            int rowCount;
            int colCount;
            if((len&1)==1)//奇数
            {
                colCount = (len+1) >> 1;
                rowCount = colCount - 1;
            }else
            {
                colCount = len >> 1;
                rowCount = colCount;
            }
            for (int i = 0; i < rowCount; ++i)
            {
                for (int j = 0; j < colCount; ++j)
                {
                    int[,] pos = GetPosition(i, j, n);
                    (matrix[i][j], matrix[pos[0, 0]][pos[0, 1]], matrix[pos[1, 0]][pos[1, 1]], matrix[pos[2, 0]][pos[2, 1]])
                  =
                    (matrix[pos[2, 0]][pos[2, 1]], matrix[i][j], matrix[pos[0, 0]][pos[0, 1]], matrix[pos[1, 0]][pos[1, 1]]);
                }
            }
        }
        int[,] GetPosition(int i, int j, int n) =>new int[3, 2] { { j, n - i},{n-i,n-j},{ n - j,i } };

        static void Main(string[] args)
        {
            //{
            //    var matrix = MakeMatrix(3);

            //    Print(matrix);
            //    Rotate_ r = new();
            //    r.Rotate(matrix);
            //    Print(matrix);
            //    //Print(r.GetPosition(0,0,2));
            //    Print(r.GetPosition(0, 1, 2));
            //}
            {
                var matrix = MakeMatrix(4);

                Print(matrix);
                Rotate_ r = new();
                r.Rotate(matrix);
                Print(matrix);
                Print(r.GetPosition(0,0,3));
                //Print(r.GetPosition(0, 1, 2));
            }


        }

        static int[][] MakeMatrix(int n)
        {
            int[][] ret=new int[n][];
            for(int i = 0; i < n; i++)
            {
                ret[i]= Enumerable.Range(1+n*i, n).ToArray();
            }
            return ret;
        }
       static void Print(int[][] matrix)
        {
            foreach(var i in matrix)
            {
                Console.WriteLine(string.Join(",",i));
            }
        }
        static void Print(int[,] matrix)
        {
            foreach (var i in matrix)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }
    }
}
