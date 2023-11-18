using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2656. K 个元素的最大和
    /// </summary>
    internal class MaximizeSum_
    {
        public int MaximizeSum(int[] nums, int k)
        {
            PriorityQueue<int,int> priorityQueue = new(Comparer<int>.Create((o1,o2)=>o2.CompareTo(o1)));
            foreach (int i in nums)
            {
                priorityQueue.Enqueue(i, i);
            }
            int sum = 0;
            for(int i = 0;i<k;++i)
            {
                int num = priorityQueue.Dequeue();
                sum += num;
                priorityQueue.Enqueue(num+1, num+1);
            }
            return sum;

        }
    }
}
