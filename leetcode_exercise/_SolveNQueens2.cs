using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _SolveNQueens2
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            
            IList<IList<string>> ls = new List<IList<string>>();
            int[] arr = new int[n];
            for(int i=0;i<n;++i)
            {
                arr[i] = i;
            }
            Permutation(arr, 0, n, ls);
            return ls;
        }

        bool IsSafe(int[] arr, int i, int j)
        {
            int len = arr.Length;
            {
                int m = i, n = j;
                --m;
                --n;
                if(m<n)
                {
                    while (m >= 0)
                    {
                        if (IsInArr(arr, m, n))
                            return false;
                        --m;
                        --n;
                    }
                }else
                {
                    while (n >= 0)
                    {
                        if (IsInArr(arr, m, n))
                            return false;
                        --m;
                        --n;
                    }
                }
           
            }
            {
                int m = i, n = j;
                --m;
                ++n;
                if(m<len-n)
                {
                    while (m >= 0)
                    {

                        if (IsInArr(arr, m, n))
                            return false;
                        --m;
                        ++n;
                    }
                }else
                {
                    while (n<len)
                    {

                        if (IsInArr(arr, m, n))
                            return false;
                        --m;
                        ++n;
                    }
                }
              
            }
            return true; 

        }
        void Permutation(int[] arr, int m, int n, IList<IList<string>> ls)
        {
            if (m <= n - 1)
            {
                Permutation(arr, m + 1, n,  ls);
                for (var i = m + 1; i < n; i++)
                {
                    Swap(ref arr[m], ref arr[i]);
                    Permutation(arr, m + 1, n, ls);
                    Swap(ref arr[m], ref arr[i]);
                }
            }
            else
            {

                if (ArrIsSafe(arr))
                {
                    ls.Add(ArrToList(arr));
                }


            }

        }
        void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;

        }

        List<string> ArrToList(int[] arr)
        {
            List<string> list = new List<string>();
            for(int i=0; i < arr.Length; i++)
            {
                byte[] chars = new byte[arr.Length];
              
                for (int j=0;j<arr.Length;++j)
                {
                    chars[j] = (byte)'_';
                }
                chars[arr[i]] = (byte)'Q';
                string s = Encoding.Default.GetString(chars);
                list.Add(s);
            }   
            return list;

        }

        bool ArrIsSafe(int[] arr)
        {
            if (arr.Length == 1)
                return true;
            for(int i=1;i<arr.Length;i++)
            {
                if (!IsSafe(arr, i, arr[i]))
                {
                    return false;
                }

            }
            return true;

        }
        bool IsInArr(int[] arr,int i,int j)
        {
            return arr[i] == j;
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

