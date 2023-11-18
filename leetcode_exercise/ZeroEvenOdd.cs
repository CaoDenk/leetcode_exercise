using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1116. 打印零与奇偶数
    /// </summary>
    public class ZeroEvenOdd
    {
        private int n;

        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }

        System.Threading.AutoResetEvent resetEvent1 = new(true);
        System.Threading.AutoResetEvent resetEvent2 = new(false);
        System.Threading.AutoResetEvent resetEvent3 = new(false);
        // printNumber(x) outputs "x", where x is an integer.
      // volatile  int i = 0;
        public void Zero(Action<int> printNumber)
        {
            for(int i=0;i<n;i++)
            {
                resetEvent1.WaitOne();
                printNumber(0);
                if (i % 2 == 1)
                    resetEvent2.Set();
                else
                    resetEvent3.Set();
            }
          
                
        }
        public void Odd(Action<int> printNumber)
        {

            for (int i = 1; i <=n; i+=2)
            {
                resetEvent1.WaitOne();
                printNumber(i);
                resetEvent1.Set();
            }

        }
        public void Even(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                resetEvent2.WaitOne();
                printNumber(i);
                resetEvent1.Set();
            }

        }

        //public static void Main()
        //{

        //}
       
    }
}
