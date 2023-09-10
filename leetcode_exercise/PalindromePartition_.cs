using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1278. 分割回文串 III
    /// 困难
    ///挖坑 
    /// </summary>
    internal class PalindromePartition_
    {
        public int PalindromePartition(string s, int k)
        {
            if (s.Length == k)
                return 0;
            int[,,] dp = new int[s.Length, s.Length,k];//i开头 , j结束，分了u段
            for(int i=0; i < s.Length;++i)
            {
                for(int j=i+1;j<s.Length;++j)
                {
                    int start = i;
                    int end = j;
                    while (start < end)
                    {
                        if (s[start] != s[end]) ++dp[i,j,0];
                        ++start;
                        --end;
                    }
                }
            }

            for (int i = 1; i < s.Length; ++i)
            {                               
                for (int j = i; j < s.Length; ++j)
                {

                    for (int u = 1; u < k; ++u)
                    {
                        dp[0, j, u] = Math.Min(dp[0, i-1, u - 1] + dp[i, j,0], dp[0, j, u]);                        
                    }
                }
            }
            return dp[0, s.Length-1,k-1] ;
        }


        static void Main(string[] args)
        {
            PalindromePartition_ p = new();
            Console.WriteLine(p.PalindromePartition("abc", 2));
            Console.WriteLine(p.PalindromePartition("aabbc", 3));
            Console.WriteLine(p.PalindromePartition("abab", 3));
        }

        void Print(int[,,] dp)
        {
            for (int j = dp.GetLength(1) - 1; j >= 0; --j)
            {
                for (int u = 0; u < dp.GetLength(2); ++u)
                {
                    Console.WriteLine($" i={0},j={j},u={u},{dp[0, j, u]}");
                }

            }

        }
    }
}
