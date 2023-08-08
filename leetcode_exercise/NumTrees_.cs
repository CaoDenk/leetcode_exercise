using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 96. 不同的二叉搜索树
    /// </summary>
    internal class NumTrees_
    {
        public int NumTrees(int n)
        {
            int[] arr= new int[n+1];
            arr[0] = 1;
            for(int i = 1; i <= n; i++)
            {
                for(int j=0; j <i; j++)
                {
                    arr[i] += arr[j] * arr[i - j - 1];
                }
            }
            return arr[^1];

        }

        static void Main(string[] args)
        {
            NumTrees_ n = new();
            for (int i=1;i<10;++i)
            {
                Console.WriteLine(n.NumTrees(i));
            }
        }
    }
}
