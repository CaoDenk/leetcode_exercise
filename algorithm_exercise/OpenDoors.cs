using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 拿钥匙通关，只有通过i的关，才能同i+1的
    /// </summary>
    internal class OpenDoors
    {


        static int[] Solve(int[] keys)
        {

            PriorityQueue<int, int> priorityQueue = new();
            int[] days=new int[keys.Length+1];
            bool[] b=new bool[keys.Length+1];
            b[0] = true;
            for(int i=0;i<keys.Length; i++)
            {
                priorityQueue.Enqueue(keys[i], keys[i]);
                while (priorityQueue.Count > 0 && priorityQueue.Peek() <= i + 1 && b[priorityQueue.Peek()-1])
                {
                    int day = priorityQueue.Dequeue();
                    days[day] = i+1;
                    b[day] = true;
                }

            }
            return days[1..];
        }
        static void Main(string[] args)
        {
            int[] keys = [5, 3,6, 1, 2, 4];
            var res=Solve(keys);
            Console.WriteLine(string.Join(" ",res));
        }
    }
}
