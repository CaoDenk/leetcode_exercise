using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1195. 交替打印字符串
    /// </summary>
    public class FizzBuzz
    {
        private int n;
        int i = 1;
        object obj=new object();
        public FizzBuzz(int n)
        {
            this.n = n;
        }

        // printFizz() outputs "fizz".
        Action fizz =()=> { Console.WriteLine("fizz"); };
        Action buzz =()=> { Console.WriteLine("buzz"); };
        Action fizzbuzz = () => { Console.WriteLine("fizzbuzz"); };
        Action<int> printNumber = i=> { Console.WriteLine(i); };
        public void Fizz(Action printFizz)
        {
            while (true)
            {
                lock (obj)
                {
                    if (i > n)
                    {
                        break;
                    }
                    if (i % 5 != 0 && i % 3 == 0)
                    {
                        printFizz();
                        ++i;
                    }

                }
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            while (true)
            {
                lock (obj)
                {
                    if (i > n)
                    {
                        break;
                    }
                    if (i % 5 == 0 && i % 3 != 0)
                    {
                        printBuzz();
                        ++i;
                    }

                }

            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (true)
            {
                lock (obj)
                {
                    if(i>n)
                    {
                        break;
                    }
                     if(i % 5 == 0 && i % 3 == 0)
                    {
                        printFizzBuzz();
                        ++i;
                    }

                }

            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            while (true)
            {
                lock (obj)
                {
                    if (i > n)
                    {
                        break;
                    }
                    if (i % 5 != 0 && i % 3 != 0)
                    {
                        printNumber(i);
                        ++i;
                    }

                }

            }
        }

        static void Main(string[] args)
        {
            FizzBuzz f = new FizzBuzz(15);
            Thread[] threads = new Thread[4];
            threads[0] = new Thread(() => { f.Fizz(f.fizz); });
            threads[1] = new Thread(() => { f.Buzz(f.buzz); });
            threads[2] = new Thread(() => { f.Fizzbuzz(f.fizzbuzz); });
            threads[3] = new Thread(() => { f.Number(_ => f.printNumber(f.i)); });
            for(int i=0;i< threads.Length;++i)
            {
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i].Join();
            }

        }
    }
}
