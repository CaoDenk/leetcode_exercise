using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 60. 排列序列
    /// 寻找效率更高的方法
    /// </summary>
    internal class GetPermutation2
    {
        int[] fact;
        public string GetPermutation(int n, int k)
        {
            fact = new int[n + 1];
            fact[0] = 1;
            fact[1] = 1;
            for (int i = 2; i <= n; ++i)
            {
                fact[i] = i * fact[i - 1];
            }
            StringBuilder sb=new StringBuilder(n);
            Permutation(Enumerable.Range(1, n).ToList(), k-1,sb);
            return sb.ToString();
        }

        void Permutation(List<int> arr,int k,StringBuilder sb)
        {
            if (arr.Count == 1)
            {
                sb.Append(arr[0]);
                return;
            }
            int res = Math.DivRem(k, fact[arr.Count - 1], out int rem);
            sb.Append(arr[res]);
            arr.RemoveAt(res);
            Permutation(arr,rem,sb);
        }
        static void Main(string[] args)
        {
            GetPermutation2 g = new();
            Console.WriteLine(g.GetPermutation(3, 3));
            Console.WriteLine(g.GetPermutation(4, 9));
            Console.WriteLine(g.GetPermutation(3, 1));
        }
    }
}
