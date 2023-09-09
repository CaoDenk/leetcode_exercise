using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 87. 扰乱字符串
    ///困难
    ///挖坑
    /// </summary>
    internal class IsScramble_
    {
        /// <summary>
        /// 思路
        /// i,j,k  i和j代表字符串起始坐标，k代表长度
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool IsScramble(string s1, string s2)
        {
            int n = s1.Length;
            bool[,,] dp = new bool[n + 1, n + 1, n + n];
            for(int k=1;k<=n;++k) //分割长度
            {
                for(int i=0; i+k-1<n;++i) //枚举两个字符串的枚举下标
                {
                    for(int j=0;j+k-1<n ;++j)
                    {
                        if (k == 1)
                        {
                            dp[i, j, k] = s1[i] == s2[j];
                            continue;
                        }
                        for(int u=1;u<k;++u)//枚举分割点
                        {
                            bool o1 = dp[i, j, u] && dp[i + u, j + u, k - u];//不交换数据
                            bool o2 = dp[i , j+k-u, u] && dp[i+u,j,  k-u];//交换数据
                            if(o1||o2)
                            {
                                dp[i, j, k] = true;
                                break;
                            }

                        }

                    }

                }

            }

            return dp[0,0,n];
        }



        static void Main(string[] args)
        {
            IsScramble_ i = new();
            //{
            //    Console.WriteLine(i.IsScramble("great", "rgeat"));
            //}
            {
                Console.WriteLine(i.IsScramble("abced", "caebd"));
            }
        }
    }
}
