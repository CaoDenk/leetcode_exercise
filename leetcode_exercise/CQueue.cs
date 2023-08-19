using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 剑指 Offer 09. 用两个栈实现队列
    /// </summary>
    internal class CQueue
    {
        Stack<int> font = new();
        Stack<int> back = new();
        public CQueue() { }

        public void AppendTail(int value)
        {
            back.Push(value);
        }

        public int DeleteHead()
        {
            if (back.Count == 0)
                return -1;
            while (back.Count > 1)
            {
                font.Push(back.Pop());
            }
            int ret = back.Pop();
            while (font.Count > 0)
            {
                back.Push(font.Pop());
            }
            return ret;
        }
    }
}
