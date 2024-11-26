using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 滑动窗口最大值
    /// </summary>
    internal class MaxSlidingWindow_
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {

            int[] result = new int[nums.Length-k+1];
            result[0] = nums[0];
            int maxpos = 0;
            for(int i=1;i<k;++i)
            {
                if (nums[i] >= result[0])
                {
                    result[0] = nums[i];
                    maxpos = i;
                }
                
            }


            for(int i=1;i<result.Length;++i)
            {
                if (nums[i + k-1] >= result[i-1]) //先判断新加入的这一个元素
                {
                    result[i] = nums[i+k-1];
                    maxpos=i+k-1;
                }else 
                {
                   
                    if(i-1!=maxpos)//如果滑动窗口，i的位置不是maxpos，说明最大值还是maxpos
                    {
                        result[i] = nums[maxpos];
                    }else
                    {
                        maxpos = i;
                        for(int j=i+1;j<i+k;j++)
                        {
                            if (nums[j] >= nums[maxpos])
                            {
                                maxpos=j;
                            }
                        }
                        result[i] = nums[maxpos];
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            MaxSlidingWindow__ maxSlidingWindow = new();
            { 
                var ret = maxSlidingWindow.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3);
                Console.WriteLine(string.Join(",", ret));
            } 
        }
    }
}
