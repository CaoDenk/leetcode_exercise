using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2342. 数位和相等数对的最大和
    /// </summary>
    internal class MaximumSum_
    {
        public int MaximumSum(int[] nums)
        {
            Dictionary<int,int> dict= new() ;
            int ans = -1;
            foreach(int i in nums)
            {
                int num=Decompose(i);
                if (dict.TryGetValue(num,out var value))
                {
                    dict[num] = Math.Max(i,value);
                    ans=Math.Max(ans,value+i);
                }else
                {
                    dict.Add(num, i);
                }

            }
            return ans;
        }
        int Decompose(int num)
        {
            int ans = 0;
            do
            {
                num = Math.DivRem(num, 10, out int rem);
                ans += rem;
            }while (num !=0);
            return ans;
        }
        static void Main(string[] args)
        {
            MaximumSum_ m = new();
            {
                int[] nums = [18, 43, 36, 13, 7];
                Console.WriteLine(m.MaximumSum(nums));
            }
            {
                int[] nums = [10, 12, 19, 14];
                Console.WriteLine(m.MaximumSum(nums));
            }
        }
    }
}
