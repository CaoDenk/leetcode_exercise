using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2544. 交替数字和
    /// </summary>
    internal class _AlternateDigitSum
    {
        public int AlternateDigitSum(int n)
        {
           Stack<int> q = new Stack<int>();
            do
            {
                n = Math.DivRem(n, 10, out int i);
                q.Push(i);
            } while (n != 0);

            bool flag = true;
            int sum = 0;
            while(q.Count > 0) 
            {
                if (flag)sum += q.Pop();
                else sum -= q.Pop();
                flag = !flag;
            }
            return sum;
        }
    }
}
