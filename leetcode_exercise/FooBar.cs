using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    public class FooBar
    {

        private int n;

        public FooBar(int n)
        {
            this.n = n;
        }
        System.Threading.AutoResetEvent event1 =new(true);
        System.Threading.AutoResetEvent event2 =new(false);
        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                // printFoo() outputs "foo". Do not change or remove this line.
                event1.WaitOne();
                printFoo();
                //event1.Reset();
                event2.Set();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                event2.WaitOne();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                event1.Set();
            }
        }

        //static void Main()
        //{
        //    FooBar fooBar = new(10);
        //    Thread thread1 = new Thread(() =>
        //    {
        //        fooBar.Foo(() =>
        //        {
        //            Console.WriteLine("foo");
        //        });
        //    });
        //    Thread thread2 = new Thread(() =>
        //    {
        //        fooBar.Bar(() =>
        //        {
        //            Console.WriteLine("Bar");
        //        });
        //    });

        //    thread1.Start();
        //    thread2.Start();
        //}

    }
}
