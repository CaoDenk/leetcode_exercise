using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 225. 用队列实现栈
    /// </summary>
    internal class MyStack
    {
        Queue<int> q1 = new Queue<int>();
        Queue<int> q2 = new Queue<int>();
        public MyStack()
        {

        }

        public void Push(int x)
        {
            q2.Enqueue(x);
        }

        public int Pop()
        {
            while (q2.Count > 1)
            {
                q1.Enqueue(q2.Dequeue());
            }
            int ret= q2.Dequeue();
            while(q1.Count > 0)
            {
                q2.Enqueue(q1.Dequeue());
            }
            return ret;
        }

        public int Top()
        {
            while (q2.Count > 1)
            {
                q1.Enqueue(q2.Dequeue());
            }
            int ret = q2.Dequeue();
            q1.Enqueue(ret);
            while (q1.Count > 0)
            {
                q2.Enqueue(q1.Dequeue());
            }
            return ret;
        }

        public bool Empty()
        {
            return q2.Count== 0;
        }

    }
}
