using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class SeqPrint
    {
         int i = 1;
    
        void Add()
        {
            lock (this)
            {
                if(i<=1000)
                {
                    Console.WriteLine($"{i},id={Thread.CurrentThread.ManagedThreadId}");
                    ++i;
                }
            
            }
          
        }
        void Print()
        {
        
            while(i<=1000)
            {
                Add();
            }
        
        }
        void Run()
        {

            Thread[] threads= new Thread[3];
            for(int i=0; i<threads.Length; i++)
            {
                threads[i]=new Thread(Print);
            }

          
            for (int j = 0; j < threads.Length; j++)
            {
                threads[j].Start();
            }

        }

        static void Main(string[] args)
        {
            SeqPrint s = new();
            s.Run();


        }

    }
}
