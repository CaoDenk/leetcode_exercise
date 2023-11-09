using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2609. 最长平衡子字符串
    /// </summary>
    internal class FindTheLongestBalancedSubstring_
    {
        public int FindTheLongestBalancedSubstring(string s)
        {
            if(s.Length == 0) return 0;
            int[,] dp = new int[s.Length, 2];//[,0]是左边零的个数，[,1]是右边1的个数

            for (int i = s.Length - 2; i >= 0; --i)
            {
                if (s[i + 1] == '1')dp[i, 1] = dp[i + 1, 1] + 1;
            }
            int max = 0;
            for (int i = 1;i<s.Length;++i)
            {
                int min;
                if (s[i-1]=='0')
                {
                    dp[i, 0] = dp[i - 1, 0] + 1;
                    min = Math.Min(dp[i-1, 0] + 1, dp[i-1, 1]);
                }else
                {
                    min = Math.Min(dp[i-1, 0], dp[i-1, 1] + 1);
                }
                max = Math.Max(max, min);
            }

            return max*2;
        }
        static void Main(string[] args)
        {
            FindTheLongestBalancedSubstring_ f = new();
            {
                Console.WriteLine(f.FindTheLongestBalancedSubstring("01000111"));
            }
        }
    }
}
