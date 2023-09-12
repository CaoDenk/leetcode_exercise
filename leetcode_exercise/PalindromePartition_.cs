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
       
        public int PalindromePartition2(string s, int k)
        {
            if (s.Length == k)
                return 0;
            int[,] dp = new int[s.Length+1,k+1];//i开头 , j结束，分了几段
            int[,] vt=new int[s.Length,s.Length];
            int len = s.Length;
            for(int i=0;i< s.Length;++i)
            {
                vt[i, i] = 0;
            }
            for(int i=0;i<s.Length-1;++i)
            {
                vt[i, i + 1] = s[i] == s[i + 1] ? 0 : 1;
            }
            for(int step=2;step<s.Length;++step)
            {
                for(int i=0;i+step<len;++i)
                {
                    int j=i+step;
                    vt[i, j] = vt[i + 1, j - 1] + (s[i] == s[j] ? 0 : 1);
                }
            }
            for(int i=1;i<=len;++i)
            {
                dp[i, 1] = vt[0,i - 1];
            }
            for(int i=1;i<=len;++i)
            {
                for (int j = 2; j <= k && j <= i; ++j)
                {
                    if (i == j)
                    {
                        dp[i,j] = 0;
                        continue;
                    }
                    else
                    {
                        int curmin = i;
                        for (int pre = i - 1; pre >= j - 1; --pre)
                        {
                            curmin = Math.Min(curmin, dp[pre,j - 1] + vt[pre,i - 1]);
                        }
                        dp[i,j] = curmin;
                    }
                }

            }



            return dp[ s.Length , k];
        }

        public int PalindromePartition(string s, int k)
        {
            if (s.Length == k)
                return 0;
            int[,] dp = new int[s.Length,  k];//i开头 , j结束，分了几段
            int[,] vt = new int[s.Length, s.Length];
            int len = s.Length;
            for (int i = 0; i < s.Length; ++i)
            {
                vt[i, i] = 0;
            }
            for (int i = 0; i < s.Length - 1; ++i)
            {
                vt[i, i + 1] = s[i] == s[i + 1] ? 0 : 1;
            }
            for (int step = 2; step < s.Length; ++step)
            {
                for (int i = 0; i + step < len; ++i)
                {
                    int j = i + step;
                    vt[i, j] = vt[i + 1, j - 1] + (s[i] == s[j] ? 0 : 1);
                }
            }
         

            for (int i = 0; i < dp.GetLength(0); i++)
            {
                dp[i, 0] = vt[0, i];
               
                for (int u = 1; u < k; ++u)
                {
                    dp[ i, u] = s.Length;
                }
                
            }
            for (int i = 1; i < s.Length; ++i)
            {
                for (int j = i; j < s.Length; ++j)
                {
                    for (int u = 1; u < k; ++u)
                    {
                        //dp[ j, u] = Math.Min(dp[ i - 1, u - 1] + dp[i, j, 0], dp[0, j, u]);
                        dp[ j, u] = Math.Min(dp[ i - 1, u - 1] + vt[i, j], dp[j, u]);
                    }
                }
            }
            return dp[ s.Length - 1, k - 1];
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
