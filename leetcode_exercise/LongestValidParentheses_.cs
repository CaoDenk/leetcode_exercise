using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 32. 最长有效括号
    /// </summary>
    internal class LongestValidParentheses_
    {

  
        class MyStack
        {
            readonly Stack<(int pos,bool isLeft)> stack = new();
            public void Push(int i)=> stack.Push((i,true));        
            public int Pop(int pos)
            {
                int ans = 0;
                if (stack.Count > 0 && stack.Peek().isLeft)
                {
                    stack.Pop();
                    if (stack.Count == 0) ans= pos + 1;
                    else ans= pos - stack.Peek().pos;
                }
                else
                {
                    stack.Push((pos,false));
                }
                return ans;
            }

        }

        public int LongestValidParentheses(string s)
        {
            int i = 0;
            int max = 0;
            MyStack my = new();
            while (i<s.Length)
            {
                if (s[i] == '(')
                {
                    my.Push(i);
                }
                else
                {
                    int len = my.Pop(i);
                    max=Math.Max(max, len);
                }
                i++;
            }

            return max;
        }


        public static void Main()
        {
            LongestValidParentheses_ l = new();
            string s1 = "(((()))";
            string s2 = "()(()";
            string s3 = ")()())";
            string s4 = "()(())";
            string s5 = ")()())()()(";
            Console.WriteLine(l.LongestValidParentheses(s1));
            Console.WriteLine(l.LongestValidParentheses(s2));
            Console.WriteLine(l.LongestValidParentheses(s3));
            Console.WriteLine(l.LongestValidParentheses(s4));
            Console.WriteLine(l.LongestValidParentheses(s5));

        }
    }
}
