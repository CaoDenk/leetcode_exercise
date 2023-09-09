using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class NumDecodings_
    {
        public int NumDecodings(string s)
        {
            int[] dp = new int[s.Length+1];
            if (s[0] == '0')
                return 0;
            dp[0] = 1;
            dp[1] = 1;
            for(int i=1;i<s.Length;++i)
            {
                if (s[i]=='0')
                {
                    if (s[i-1] is '1' or '2')
                    {
                         dp[i+1] = dp[i - 1];
                    }
                    else
                    {
                        dp[i+1] = 0;
                    }
                }else if (s[i]<='6')
                {
                    if (s[i-1] is '1' or '2')
                    {
                        dp[i + 1] = dp[i - 1]+dp[i];

                    }else
                    {
                        dp[i+1] = dp[i];
                    }
                }else if (s[i-1]=='1')
                {

                    dp[i + 1] = dp[i - 1] + dp[i];
                }
                else
                {
                    dp[i+1] = dp[i];
                }
            }
            return dp[^1];
        }


        bool IsValid(string s)
        {
            if (s[0] == '1')
                return true;
            if (s[0] == '2'&& s[1]<='6')
                return true;
            return false;
        }

        public int NumDecodings2(string s)
        {
            int count = 0;
            Recursive(s, 0, ref count);
            return count;
        }

        void Recursive(string s,int start,ref int count) 
        {
            if (start >= s.Length)
            {
                count++;
                return;
            }
            if (s[start] == '0')
                return;
            Recursive(s,start+1,ref count);
            if(s.Length-start>=2&& IsValid(s[start..(start + 2)]))
            {
                Recursive(s,start+2,ref count);
            }
        }
        static void Main(string[] args)
        {
            NumDecodings_ n = new();
            Console.WriteLine(n.NumDecodings("10"));
            Console.WriteLine(n.NumDecodings("12"));
            Console.WriteLine(n.NumDecodings("226"));
            Console.WriteLine(n.NumDecodings("111111111111111111111111111111111111111111111"));
            Console.WriteLine(n.NumDecodings("2101"));
            Console.WriteLine(n.NumDecodings("1123"));//1,1,2  ;1,12,11,2
            //1,1,2,3
            //1,1,23
            //1,12,3
            //11,2,3
            //11,23

            //1,1,2
            //1,12
            //11,2
            //
        }
    }
}
