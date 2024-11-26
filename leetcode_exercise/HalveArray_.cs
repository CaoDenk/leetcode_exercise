using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2208. 将数组和减半的最少操作次数
    /// </summary>
    internal class HalveArray_
    {
        public int HalveArray(int[] nums)
        {
            //long sum = nums.Sum();
            long sum = nums.Select(x=>(long)x).Sum();
            double half = sum / 2d;
            PriorityQueue<double,double> priorityQueue = new(Comparer<double>.Create((o1,o2)=>o2.CompareTo(o1)));
            foreach (int i in nums)
            {
                priorityQueue.Enqueue(i,i);
            }

            int ans = 0;
            double tsum = 0;
            while (true)
            {
                double v= priorityQueue.Dequeue();
                double halfV = v / 2;
                tsum += halfV;
                ans++;
                if (tsum>=half)
                {
                    return ans;
                }
                priorityQueue.Enqueue(halfV, halfV);
            }
          
      
        }

        static void Main()
        {
            HalveArray_ h = new();
            {
                int[] nums = [3, 8, 20];
                int ret = h.HalveArray(nums);
                Console.WriteLine(ret);
            }
        }


    }

  
}
