using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 232. 用栈实现队列
    /// </summary>
    internal class MyQueue
    {
        Stack<int> font = new();
        Stack<int> back = new();
        public MyQueue()
        {

        }

        public void Push(int x)
        {
            back.Push(x);
        }

        public int Pop()
        {
            while (back.Count > 1)
            {
                font.Push(back.Pop());
            }
            int ret=back.Pop();
            while(font.Count > 0)
            {
                back.Push(font.Pop());
            }
            return ret;
            
        }

        public int Peek()
        {
            while (back.Count > 1)
            {
                font.Push(back.Pop());
            }
            int ret = back.Peek();
            while (font.Count > 0)
            {
                back.Push(font.Pop());
            }
            return ret;
        }

        public bool Empty()
        {
            return back.Count == 0;
        }
    }
}
