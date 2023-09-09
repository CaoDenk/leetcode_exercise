using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MinCut_
    {
        /// <summary>
        /// 132. 分割回文串 II
        /// 困难  
        /// 挖坑
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinCut(string s)
        {
            int[] dp=new int[s.Length+1];
            dp[1] = 1;
            for(int i=1;i<s.Length;++i)
            {
                int min = int.MaxValue;
                for(int j=0;j<=i;j++)
                {
                    if (dp[j]+1<min&&IsPalindrome(s,j,i))
                    {
                        min = dp[j] + 1;
                    }
                }
                dp[i + 1] = min;

            }
            return dp[^1]-1;
        }

    
        bool IsPalindrome(string s,int start,int end)
        {
           if(end-start<=1) return true;
           for(;start<end;++start,--end)
           {
                if (s[start] != s[end])
                {
                    return false;
                }

           }
            return true;
        }
        static void Main(string[] args)
        {
            MinCut_ m = new();
            Console.WriteLine(m.MinCut("ababababababababababababcbabababababababababababa)"));
            Console.WriteLine(m.MinCut("fifgbeajcacehiicccfecbfhhgfiiecdcjjffbghdidbhbdbfbfjccgbbdcjheccfbhafehieabbdfeigbiaggchaeghaijfbjhi)"));
        }

    }
}
