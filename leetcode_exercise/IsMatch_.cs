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
    internal class IsMatch_
    {
        /// <summary>
        /// 思路
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>

        public bool IsMatch(string s, string p)
        {

            if (s.Length == 0)
            {
                for (int j = 0; j < p.Length; j++)
                    if (p[j] != '*')
                        return false;
                return true;
            }

            bool[,] dp = new bool[p.Length + 1, s.Length + 1];

            dp[0, 0] = true;

            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (p[i] == '*')
                    {

                        if (dp[i, j])
                        {

                            for (int k = j, c = i + 1; k <= s.Length; k++)
                            {
                                dp[c, k] = true;
                            }
                            break;
                        }
                        dp[i + 1, j + 1] = dp[i, j + 1];
                    }
                    else if (p[i] == '?' || p[i] == s[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                }
            }
            return dp[p.Length, s.Length];

        }

        static void Main()
        {
            IsMatch_ _IsMatch = new IsMatch_();
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

        
    
        


