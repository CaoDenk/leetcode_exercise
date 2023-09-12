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
            bool[,] dp = new bool[s.Length, s.Length];

           
            //int len = s.Length;
            for (int i = 0; i < s.Length; ++i)
            {
                dp[i, i] = true;
            }
            for (int i = 0; i < s.Length - 1; ++i)
            {
                dp[i, i + 1] = s[i] == s[i + 1] ;
            }
            for(int step=2;step<s.Length;++step)
            {
                for(int i=0;i+step<s.Length;++i)
                {
                    int j=i+step;
                    if (s[i] == s[j] && dp[i+1,j-1])
                        dp[i, j] = true;
                    
                }
            }

            //for(int i=0;i<dp.GetLength(0);++i)
            //{
            //    for(int j=0;j<dp.GetLength(1);++j)
            //    {
            //        Console.Write(dp[i,j]+",");
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 0; i < s.Length - 2; ++i)
            {
                if (!dp[0,i])
                    continue;
                for (int j = i + 1; j < s.Length - 1; ++j)
                {
                    if (!dp[i+1,j])
                        continue;
                    if (dp[j+1,s.Length-1])
                        return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            CheckPartitioning_ c = new();
            {
                bool res = c.CheckPartitioning("abcbdd");
                Console.WriteLine(res);
            }
            {
                bool res = c.CheckPartitioning("xxdtzghekllxsiqydgnsktyjpshdbhbkiutwdxjgikdpowshccjfcgdeldgaloovpwpvzopqvpvgvpfpogzwzgrtuuezvqcqoymmcoabiaydtiyvfbgqpzkucdqnwkgfwg");
                Console.WriteLine(res);
            }
        }

    }

}
