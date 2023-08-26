using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 41. 缺失的第一个正数
    /// </summary>
    internal class FirstMissingPositive_
    {
        public int FirstMissingPositive(int[] nums)
        {
            for(int i=0;i<nums.Length;++i)
            {
       
                if(nums[i] >0 && nums[i] < nums.Length && nums[nums[i]-1] != nums[i])
                {
                    (nums[nums[i]-1], nums[i]) = (nums[i], nums[nums[i]-1]);
                }
            }
       
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != i + 1)
                    return i + 1;
            }
            
            return nums.Length+1;
        }

        static void Main(string[] args)
        {
            FirstMissingPositive_ f = new();
            //Console.WriteLine(f.FirstMissingPositive(new int[] {3,4,1,-1}));
            //Console.WriteLine(f.FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 }));
            //Console.WriteLine(f.FirstMissingPositive(new int[] { 1, 2, 0 }));
            Console.WriteLine(f.FirstMissingPositive(new int[] { -1, 4, 2, 1, 9, 10 }));
        }
    }
}
