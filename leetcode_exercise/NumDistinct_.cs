using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 115. 不同的子序列
    /// 困难
    /// </summary>
    internal class NumDistinct_
    {
        public int NumDistinct(string s, string t)
        {

            if (s.Length < t.Length)
                return -1;
            long[,] dp = new long[ s.Length + 1, t.Length + 1];
       
            for(int i=0;i<=s.Length;i++)
            {
                dp[i, 0] = 1;
            }
            for (int i=0;i<s.Length;++i)
            {
                for( int j=0;j<t.Length;++j)
                {
                    if (s[i] == t[j])
                    {                    
                         dp[i + 1, j + 1] = dp[i,j]+dp[i,j+1];
                    }else
                    {
                        dp[i + 1, j + 1] =  dp[i,j+1];
                    }
                   
                }
            }


            if(dp[s.Length, t.Length] is >int.MaxValue )
                return -1;
            return (int)(dp[s.Length, t.Length]);
        }
        static void Main(string[] args)
        {
            NumDistinct_ d = new();
            //Console.WriteLine(d.NumDistinct("bab", "b"));
            Console.WriteLine(d.NumDistinct("rabbbit", "rabbit"));
            Console.WriteLine(d.NumDistinct("babgbag", "bag"));
            Console.WriteLine(d.NumDistinct("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        }
    }
}
