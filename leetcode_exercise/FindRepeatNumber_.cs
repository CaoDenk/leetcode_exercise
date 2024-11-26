using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class FindRepeatNumber_
    {
        public int FindRepeatNumber(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            int ans = 0;
            foreach (int num in nums)
            {
                if (!result.Add(num))
                {
                    ans = num;
                    break;
                }
            }
            return ans;
        }
    }
}
