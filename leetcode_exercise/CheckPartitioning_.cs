using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1745. 分割回文串 IV
    /// 困难
    /// </summary>
    internal class CheckPartitioning_
    {
        public bool CheckPartitioning(string s)
        {

            return PalindromePartition(s,3)==0;
        }
        bool Check(string s,int left,int right)
        {
            while(left<right)
            {

                if (s[left] != s[right]) return false;
                    ++left;
                    --right;
                
            }
            return true;
        }
        public int PalindromePartition(string s, int k)
        {
            if (s.Length == k)
                return 0;
            int[,,] dp = new int[s.Length, s.Length, k];//i开头 , j结束，分了几段
            for (int i = 0; i < s.Length; ++i)
            {
                for (int j = i + 1; j < s.Length; ++j)
                {
                    int start = i;
                    int end = j;
                    while (start < end)
                    {
                        if (s[start] != s[end]) ++dp[i, j, 0];
                        ++start;
                        --end;
                    }
                }
            }
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); ++j)
                {

                    for (int u = 1; u < k; ++u)
                    {
                        dp[i, j, u] = s.Length;
                    }
                }
            }
            for (int i = 1; i < s.Length; ++i)
            {
                for (int j = i; j < s.Length; ++j)
                {
                    for (int u = 1; u < k; ++u)
                    {
                        dp[0, j, u] = Math.Min(dp[0, i - 1, u - 1] + dp[i, j, 0], dp[0, j, u]);
                    }
                }
            }
            return dp[0, s.Length - 1, k - 1];
        }
    }

}
