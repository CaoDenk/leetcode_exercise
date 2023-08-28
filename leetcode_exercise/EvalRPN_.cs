using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// LCR 036. 逆波兰表达式求值
    /// 150. 逆波兰表达式求值
    /// </summary>
    internal class EvalRPN_
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new();
           
            foreach (string token in tokens)
            {
                if (char.IsDigit(token[0]))
                {
                    stack.Push(int.Parse(token));
                }else if (token[0]=='-')
                {
                    if(token.Length==1)
                    {
                        int num1=stack.Pop();
                        int num2=stack.Pop();
                        int t = num2 - num1;
                        stack.Push(t);
                    }
                    else
                    {
                        stack.Push(int.Parse(token));
                    }

                }else if (token=="+")
                {
                    stack.Push(stack.Pop()+stack.Pop());

                }else if(token=="*")
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }else
                {
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    int t = num2 / num1;
                    stack.Push(t);
                }
            }
            return stack.Pop();
        }
      

    }
}
