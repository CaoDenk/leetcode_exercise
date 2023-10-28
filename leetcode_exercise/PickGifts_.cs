using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2558. 从数量最多的堆取走礼物
    /// </summary>
    internal class PickGifts_
    {
        public long PickGifts(int[] gifts, int k)
        {
            PriorityQueue<int,int> priorityQueue = new(Comparer<int>.Create((o1,o2)=>o2.CompareTo(o1)));
            for(int i = 0;i< gifts.Length; i++)
            {
                priorityQueue.Enqueue(gifts[i], gifts[i]);
            }
            long ans = 0;
            for (int i=0;i<k;i++)
            {
               int gift= priorityQueue.Dequeue();
                if (gift == 1)
                {
                    ++ans;
                    break;
                }  
                else
                {
                    int g=(int)Math.Sqrt(gift);
                    priorityQueue.Enqueue(g, g);
                }

            }
            while(priorityQueue.Count > 0)
            {
                ans+= priorityQueue.Dequeue();
            }
            return ans;

        }
    }
}
