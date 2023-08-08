using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _HalveArray
    {
        public int HalveArray(int[] nums)
        {
            long sum = 0;
            foreach(var i in nums)
            {
                sum += i;
            }
            double half = sum / 2d;
            PriorityQueue<double,double> priorityQueue = new(new ReverComparer());
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
            _HalveArray h = new();
            {
                int[] nums = new int[] { 3, 8, 20 };
                int ret = h.HalveArray(nums);
                Console.WriteLine(ret);
            }
        }
        class ReverComparer : IComparer<double>
        {
            public int Compare(double x, double y)
            {
                return y.CompareTo(x);
            }
        }

    }

  
}
