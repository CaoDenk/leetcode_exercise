using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 5. 最长回文子串
    /// </summary>
    internal class LongestPalindrome_
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1) return s;
            bool[,] dp = new bool[s.Length,s.Length];
            for(int i=0;i<s.Length;i++)
            {
                dp[i, i] = true;
            }
            (int, int) mark = (0, 0);
            for (int i=0;i<s.Length-1;++i)
            {
                if (s[i] == s[i+1])
                {
                    mark=(i,i+1);
                    dp[i, i + 1] = true;
                }

            }
            int step = 2;
          
            for(; step<s.Length;++step )
            {
                for (int i = 0; i + step < s.Length; i++)
                {
                    int j = i + step;

                    if (dp[i + 1, j - 1] && s[i] == s[j])
                    {
                        dp[i, j] = true;
                        mark = (i, j);
                    }
                }
            }
            return s[mark.Item1..(mark.Item2+1)];
        }
        static void Main(string[] args)
        {
            LongestPalindrome_ l = new();
            var res = l.LongestPalindrome("babad");
            Console.WriteLine(res);
        }
    }
}
