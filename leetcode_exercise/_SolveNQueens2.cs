using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _SolveNQueens2
    {
        public int TotalNQueens(int n)
        {
            bool[,] map = new bool[n, n];
            int ans = 0;
            BackTracing(ref ans, 0, map, new bool[n]);
            return ans;
        }




        void BackTracing(ref int ans, int row, bool[,] map, bool[] colFilled)
        {
            if (row >= colFilled.Length)
            {
                ++ans;
                return;
            }
            for (int i = 0; i < colFilled.Length; i++)
            {
                if (colFilled[i])
                {
                    continue;
                }
                else
                {
                    if (IsSafe(map, row, i))
                    {
                        map[row, i] = true;
                        colFilled[i] = true;
                        BackTracing(ref ans, row + 1, map, colFilled);
                        map[row, i] = false;
                        colFilled[i] = false;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }

        bool IsSafe(bool[,] map, int i, int j)
        {

            {
                int m = i, n = j; //判断45度
                while (m >= 0 && n < map.GetLength(0))
                {

                    if (map[m, n])
                        return false;
                    --m;
                    ++n;
                }

            }
            {
                int m = i, n = j; //判断135度
                while (m >= 0 && n >= 0)
                {

                    if (map[m, n])
                        return false;
                    --m;
                    --n;
                }
            }

            return true; ;

        }

      
    }
}


//static void Main()
//{
//    _SolveNQueens2 solveNQueens2 = new _SolveNQueens2();
//    var ls = solveNQueens2.SolveNQueens(4);
//    //solveNQueens2.Permutation(new int[] { 1, 2, 3, 4, 5,6,7,8,9,10 }, 0, 10);
//    //int[] arr = new int[] { 1, 3, 2, 0 };
//    //int[] arr2 = new int[] { 1, 3, 0, 2 };
//    int k = 0;
//    foreach(var i in ls)
//    {
//        foreach(var j in i)
//        {
//            Console.WriteLine(j);
//        }
//        ++k;
//        if (k > 20)
//            break;
//        Console.WriteLine();
//    }

//    ////Console.WriteLine(arr);
//    //bool b = solveNQueens2.ArrIsSafe(arr);
//    //Console.WriteLine(b);
//    //Console.WriteLine(solveNQueens2.ArrIsSafe(arr2));
//}
//bool isBeTaken(int[] arr,int i,int j)
//{
//    if (arr.Length >= i)
//        return false;
//    return arr[i] == j;
//}

