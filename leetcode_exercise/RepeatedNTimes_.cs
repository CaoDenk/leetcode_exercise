using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class RepeatedNTimes_
    {
        public int RepeatedNTimes(int[] nums)
        {
            Dictionary<int,int> result = new();
            foreach (int n in nums)
            {
                if (result.ContainsKey(n))
                {
                    ++result[n];

                    if (result[n] == nums.Length / 2)
                        return n;
                }else
                {
                    result[n] = 1;
                }
            }
            return -1;
        }
    }
}
