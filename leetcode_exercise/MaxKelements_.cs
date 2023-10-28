using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2530. 执行 K 次操作后的最大分数
    /// </summary>
    internal class MaxKelements_
    {
        public long MaxKelements(int[] nums, int k)
        {
            //SortedList<int,int> sortedList = new(Comparer<int>.Create((x, y) => { if (x != y) return x.CompareTo(y); else return 1; }));
            PriorityQueue<int, int> p = new(Comparer<int>.Create((x,y)=>y.CompareTo(x)));
            foreach (int i in nums)
            {
                p.Enqueue(i, i);
            }
            long sum=0;
            for(int i = 0;i<k;i++)
            {
                int n = p.Dequeue();
               
                sum += n;
                n = (n + 2) / 3;
                p.Enqueue(n, n);
            }
           
            return sum;

        }
        static void Main(string[] args)
        {
            MaxKelements_ m = new();
            {
                Console.WriteLine(m.MaxKelements([10, 10, 10, 10, 10],5));
            }
        }
    }
}
