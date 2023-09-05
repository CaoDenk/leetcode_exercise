using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 所有出栈顺序
    /// 挖坑
    /// </summary>
    internal class PopStack
    {


        void Recursive(Stack<int> inistack,Stack<int> stack, Stack<int> outStack)
        {
            if (inistack.Count == 0)
                return;

            if(stack.Count==0)
            {
                stack.Push(inistack.Pop());//进栈
                Recursive(inistack, stack, outStack);
                outStack.Push(inistack.Pop());
            }else
            {
                stack.Push(inistack.Pop());//进栈
                Recursive(inistack, stack, outStack);
                stack.Pop();
                outStack.Push(inistack.Pop());
                Recursive(inistack, stack, outStack);//出栈

            }


        }

        static void Main(string[] args)
        {

        }




    }
}
