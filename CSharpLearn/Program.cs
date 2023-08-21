using System.Threading;

namespace CSharpLearn
{
    internal class Program
    {
        int num = 1;

        object obj=new object();


        void Run2()
        {
            while (num <= 100)
            {
                lock (obj)
                {
                    while((num&1)==1)
                    {
                        Monitor.Wait(obj);
                    }
                    Console.WriteLine($"num={num},{Thread.CurrentThread.Name}");
                    num++;
                    Monitor.Pulse(obj);
                }

            }
        }
        void Run1()
        {
            while (num <= 100)
            { 
                lock(obj)
                {
                    while ((num & 1) == 0)
                    {
                        Monitor.Wait(obj);
                    }
                    Console.WriteLine($"num={num},{Thread.CurrentThread.Name}");
                    num++;
                   Monitor.Pulse(obj);
                }
                
            }
        }


        static void Main(string[] args)
        {
            //ThreadPool.SetMaxThreads()
            Program p=new Program();
            Thread t1 = new Thread(p.Run1);
            Thread t2 = new Thread(p.Run2);
            t2.Start();
            t1.Start();
           
            //t1.Join();
            //t2.Join();
        }
    }
}