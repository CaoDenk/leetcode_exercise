using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class ZeroEvenOdd2
    {

        private int n;
        Semaphore pool;
        public ZeroEvenOdd2(int n)
        {
            this.n = n;
            pool = new Semaphore(0, 3);
        }

        
        // printNumber(x) outputs "x", where x is an integer.
        // volatile  int i = 0;
        public void Zero(Action<int> printNumber)
        {
          
            for(int i = 0; i < n; i++)
            {
                pool.WaitOne();
                printNumber(0);
                pool.Release();
            }

        }
        public void Odd(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i+=2)
            {
                
                pool.WaitOne();
                printNumber(i);
                pool.Release();
            }


        }
        public void Even(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                pool.WaitOne();
                printNumber(i);
                pool.Release();
            }

        }

       static Action<int> printNumber = i => Console.WriteLine(i);

        public static void Main()
        {
            ZeroEvenOdd2 z = new(5);
            Thread[] threads = new Thread[3];
            threads[0] = new Thread(() => { z.Zero(printNumber); });
            threads[1] = new Thread(() => { z.Odd(printNumber); });
            threads[2] = new Thread(() => { z.Even(printNumber); });
            z.pool.Release();
            for(int i=0;i<threads.Length;i++)
            {

                threads[i].Start();

            }
        }
    }
}
