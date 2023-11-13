using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 97. 交错字符串
    /// 超时
    /// </summary>
    internal class IsInterleave_
    {

    
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            bool[,,] dp=new bool[s1.Length+1, s2.Length+1,s3.Length+1];
            bool[,,] visited=new bool[s1.Length + 1, s2.Length + 1, s3.Length + 1];
            int i= 0;
            int j = 0;
            dp[0, 0, 0] = true;
            Stack<(int, int,int)> stack = new();
            stack.Push((0, 0, 0));

            for(int k=0;k<s3.Length;)
            {

                if (i<s1.Length&& !visited[i + 1, j, k + 1] && s1[i] == s3[k])
                {
                    //++i;
                    stack.Push((i, j, k));
                    dp[++i, j, ++k] = true;
                    visited[i, j, k] = true;
                    continue;
                }
                if (j < s2.Length && !visited[i , j+1, k + 1] && s2[j] == s3[k])
                {
                    //++i;
                    stack.Push((i, j, k));
                    dp[i, ++j, ++k] = true;
                    visited[i, j, k] = true;
                    continue;
                }
                if(stack.Count == 0)
                    return false;
                (i, j, k) = stack.Pop();
                dp[i, j, k] = false;

            }

            return dp[s1.Length,s2.Length,s3.Length];
        }

   
        static void Main(string[] args)
        {
            IsInterleave_ i = new();
            {
                string s1= "aabcc";
                string s2= "dbbca";
                string s3= "aadbbbaccc";
                Console.WriteLine(i.IsInterleave(s1,s2,s3));
            }
            {//s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
                string s1 = "aabcc";
                string s2 = "dbbca";
                string s3 = "aadbbcbcac";
                Console.WriteLine(i.IsInterleave(s1, s2, s3));
            }
            {
                string s1 = "abababababababababababababababababababababababababababababababababababababababababababababababababbb";
                string s2 = "babababababababababababababababababababababababababababababababababababababababababababababababaaaba";
                string s3 = "abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb";
                Console.WriteLine(i.IsInterleave(s1, s2, s3));
            }
            {
                string s1 = "";
                string s2 = "";
                string s3 = "";
                Console.WriteLine(i.IsInterleave(s1, s2, s3));
            }
        }

    }
}
