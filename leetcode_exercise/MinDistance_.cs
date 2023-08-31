using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 72. 编辑距离
    /// 挖坑
    /// </summary>
    internal class MinDistance_
    {
        /// <summary>
        /// i:word1 j:word2
        /// 到dp[i+1,j+1]有三条路 
        /// 一: 从 dp[i,j] 的替换
        /// 二: 从 dp[i+1,j] 的删除
        /// 三: 从 dp[i,j+1] 的插入
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int[,] dp=new int[word1.Length+1,word2.Length+1];
            for(int i=1; i<=word1.Length; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 1; j <= word2.Length; j++)
            {
                 dp[0, j ] = j;
            }
            for (int i=0;i< word1.Length;++i)
            {
                for(int j=0;j< word2.Length;++j)
                {

                    if (word1[i] != word2[j]) 
                    {
                        dp[i + 1, j + 1] = Math.Min(dp[i, j], Math.Min(dp[i, j + 1], dp[i+1,j])) + 1;
                    }else
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }

                }
            }
            //Print(dp);
            return dp[word1.Length,word2.Length];
        }



        static void Print(int[,] dp)
        {

            for(int i=0;i<dp.GetLength(0);i++)
            {
                for(int j=0; j<dp.GetLength(1);j++)
                {
                    Console.Write(dp[i,j]+",");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            MinDistance_ m = new();
            Console.WriteLine(m.MinDistance("horse", "ros"));
            Console.WriteLine(m.MinDistance("intention", "execution"));
            Console.WriteLine(m.MinDistance("", "a"));
            Console.WriteLine(m.MinDistance("a", "ab"));
        }
    }
}
