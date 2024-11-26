using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MinSubArrayLen2
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int sum = 0;
            int len = int.MaxValue;
   
            int j = 0;//起始位置
            for (int i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                while (j<=i&&sum >= target)
                {
                    sum -= nums[j];
                    len = Math.Min(len, i - j + 1);
                    j++;                  
                }
            }
            return len==int.MaxValue?0:len;
        }
        static void Main(string[] args)
        {
            MinSubArrayLen2 m = new();
            Console.WriteLine(m.MinSubArrayLen(7, [2, 3, 1, 2, 4, 3]));
            Console.WriteLine(m.MinSubArrayLen(4, [1,4,4]));
            //Console.WriteLine(m.MinSubArrayLen(11,new int[] { 1, 2, 3, 4, 5 }));
            //Console.WriteLine(m.MinSubArrayLen(15, new int[] { 1, 2, 3, 4, 5 }));
            //Console.WriteLine(m.MinSubArrayLen(7, new int[] { 5 }));
        }
    }
}
