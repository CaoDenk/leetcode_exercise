using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 414. 第三大的数
    /// </summary>
    internal class ThirdMax_
    {
        public int ThirdMax2(int[] nums)
        {
            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>(Comparer<int>.Create((o1,o2)=>o2.CompareTo(o1)));
            foreach (int i in nums)
            {
                priorityQueue.Enqueue(i, i);

            }
            long last=long.MaxValue;
            int k = 3;
            var max=priorityQueue.Peek();
            var num=max;
            while(priorityQueue.Count>0&& k>0)
            {
                num=priorityQueue.Dequeue();
                if (num != last)
                { 
                    --k; 
                    last = num;
                }

            }
            if (k == 0)
                return num;
            return max;
        }
        public int ThirdMax(int[] nums)
        {

            SortedSet<int> set = new();

            foreach (int i in nums)
            {
                set.Add(i);
                if(set.Count>3)
                {
                    set.Remove(set.Min);
                }
            }
            return set.Count == 3 ? set.Min : set.Max;
        }
        static void Main(string[] args)
        {
            ThirdMax_ t = new();
            {
                int[] nums = { -2147483648, 1, 1 };
                Console.WriteLine(t.ThirdMax(nums));

            }
            //{
            //    int[] nums = { 1, 2 };
            //    Console.WriteLine(t.ThirdMax(nums));

            //}
        }

     
    }
}
