using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpLearn
{
    internal class Rem
    {
        static void Main()
        {
            // Create a cancellation token source.
            CancellationTokenSource cts = new CancellationTokenSource();

            // Create a task that will be cancelled after 5 seconds.
            Task task = Task.Factory.StartNew(() =>
            {
                // Do some work.
                Thread.Sleep(5000);

                // Check if the task has been cancelled.
                while(true)
                {
                    if (cts.IsCancellationRequested)
                    {
                        // The task has been cancelled.
                        Console.WriteLine("取消");
                        return;
                    }
                }
             

                // Do some more work.
                // ...
            });

            // Wait for the task to complete.
            
            
            cts.Cancel();
            Console.ReadLine();
        }

        static int CalculateSum(int a, int b)
        {
            // 模拟耗时计算
            Thread.Sleep(8000);

            return a + b;
        }
    }

}
