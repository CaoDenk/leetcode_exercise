using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    /// <summary>
    /// 2731. 移动机器人
    /// </summary>
    internal class FindTheArrayConcVal_
    {
        public long FindTheArrayConcVal(int[] nums)
        {
            int i = 0;
            int j = nums.Length - 1;
            long sum = 0;
            while (i < j)
            {
                sum += Add(nums[i], nums[j]);
                i++;
                j--;
            }
            if(i==j)
            { 
                sum += nums[i];
            }
            return sum;
        }
        long Add(int num1, int num2)
        {
            int num = num2;
            int n = num1;
            do
            {
                num2 /= 10;
                n *= 10;
            } while (num2 != 0);
            return n + num;
        }

     
    }


}
