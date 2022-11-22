using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _LongestValidParentheses
    {

        struct Data
        {
            public bool isleft;
            public int pos;
            public Data(bool isleft, int pos)
            {

                this.isleft = isleft;
                this.pos = pos;

            }
        }
            


    class MyStack
     {

            Stack<Data> stack = new Stack<Data>();
            public void Push(int i)
            {
                stack.Push(new Data(true,i));                        
            }

            public int Pop(int pos)
            {

                if (stack.Count > 0&&stack.Peek().isleft)
                {
                    stack.Pop();
                    if (stack.Count == 0)
                        return pos +1;
                  return pos- stack.Peek().pos;
                  
                }else
                    stack.Push(new Data(false,pos));
                return 0;
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
                    max = max < len ? len : max;

                }
                i++;
            }

            

            return max;
        }




        public static void Main()
        {
            _LongestValidParentheses l = new();
            string s1 = "(((()))";
            string s2 = "()(()";
            string s3 = ")()())";
            string s4 = "()(())";
            string s5 = ")()())()()(";
            // int res = l.LongestValidParentheses(s3);
            Console.WriteLine(l.LongestValidParentheses(s2));
            Console.WriteLine(l.LongestValidParentheses(s3));
            Console.WriteLine(l.LongestValidParentheses(s4));
            Console.WriteLine(l.LongestValidParentheses(s5));

        }
    }
}
