using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 45. 跳跃游戏 II
    /// </summary>
    internal class Jump_
    {
        public int Jump(int[] nums)
        {
            if (nums.Length == 1)
                return 0;
            int len = nums.Length;
            int[] minStep = new int[len];
            Array.Fill(minStep, int.MaxValue);
            minStep[0] = 0;
            for (int i = 0; i < len; ++i)
            {
                int distance = nums[i];
                if(i+distance>= len - 1)
                    return minStep[i]+1;          
                for (int j = distance; j >0; --j)
                {
                    if (minStep[i + j] - 1 > minStep[i])
                    {
                        minStep[i + j] = minStep[i] + 1;
                    }
                    else
                        break;
                }
            }
            return minStep[^1];
        }

        static void Main(string[] args)
        {
            Jump_ j = new();
            Console.WriteLine(j.Jump(new int[] { 2, 3, 1, 1, 4 }));
            Console.WriteLine(j.Jump(new int[] { 2,1 }));
            Console.WriteLine(j.Jump(new int[] { 1, 2, 1, 1, 1 }));
        }
    }
}
