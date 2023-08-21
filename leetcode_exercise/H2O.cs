using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1117. H2O 生成
    /// </summary>
    internal class H2O
    {
        
        public H2O()
        {

        }
        private System.Threading.Semaphore hydrogenSemaphore = new System.Threading.Semaphore(2, 2);
        private System.Threading.Semaphore oxygenSemaphore = new System.Threading.Semaphore(0, 1);
        private System.Threading.Barrier barrier = new System.Threading.Barrier(3);

        public void Hydrogen(Action releaseHydrogen)
        {
            hydrogenSemaphore.WaitOne();
            barrier.SignalAndWait(); // 等待其他线程到达屏障
            releaseHydrogen();
            hydrogenSemaphore.Release();
        }

        public void Oxygen(Action releaseOxygen)
        {
            oxygenSemaphore.WaitOne();
            barrier.SignalAndWait(); // 等待其他线程到达屏障
            releaseOxygen();
            oxygenSemaphore.Release();
        }
        static void Run(int n)
        {
            H2O h2O = new H2O();
            Thread[] threads1=new Thread[n];
            Thread[] threads2=new Thread[n*2];
            for (int i = 0;i<n;++i)
            {
                threads1[i] = new Thread(() => { Console.WriteLine('O'); });
                threads2[i*2] = new Thread(() => { Console.WriteLine('H'); });
                threads2[i*2+1] = new Thread(() => { Console.WriteLine('H'); });
            }
            for (int i = 0; i < n; ++i)
            {
                threads2[i * 2 + 1].Start();
                threads1[i].Start();
                threads2[i * 2].Start();
        
            }
        }
        static void Main(string[] args)
        {
            Run(200);
        }
    }
}
