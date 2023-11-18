using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 44. 通配符匹配
    /// </summary>
    internal class _IsMatch2
    {
        public bool IsMatch(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;
            bool[,] dp = new bool[m + 1,n + 1];
            dp[0,0] = true;
            for (int i = 1; i <= n; ++i)
            {
                if (p[i - 1] == '*')
                {
                    dp[0,i] = true;
                }
                else
                {
                    break;
                }
            }
            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i,j] = dp[i,j - 1] || dp[i - 1,j];
                    }
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        dp[i,j] = dp[i - 1,j - 1];
                    }
                }
            }
            return dp[m,n];
        }



        static void Main()
        {

            _IsMatch2 _IsMatch = new _IsMatch2();
            {

                string s = "aa";
                string p = "a";
                Console.WriteLine(_IsMatch.IsMatch(s, p));

            }
            {
                string s = "aa";
                string p = "*";
                Console.WriteLine(_IsMatch.IsMatch(s, p));
            }
            {
                string s = "acdcb";
                string p = "a*c?b";
                Console.WriteLine(_IsMatch.IsMatch(s, p));
            }
            {

                string s = "";
                string p = "******";
                Console.WriteLine(_IsMatch.IsMatch(s, p));

            }

            {

                string s = "abcabczzzde";
                string p = "*abc???de*";
                Console.WriteLine(_IsMatch.IsMatch(s, p));

            }
            {
                string s = "aab";
                string p = "c*a*b";
                Console.WriteLine(_IsMatch.IsMatch(s, p));
            }
            {
                string s = "mississippi";
                string p = "m??*ss*?i*pi";
                Console.WriteLine(_IsMatch.IsMatch(s, p));
            }
        }

    }
}
