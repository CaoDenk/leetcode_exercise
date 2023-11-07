using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 数组中两个数的最大异或值
    /// 挖坑
    /// </summary>
    internal class FindMaximumXOR_
    {
        public int FindMaximumXOR(int[] nums)
        {
            int ans = 0;
            int mask = 0;

           for (int i = 30; i >= 0; --i)
           {
                mask |= 1 << i;
                int newAns = ans | 1 << i;
                HashSet<int> set = new();
                foreach (var num in nums)
                {
                    int x = num & mask;
                    if (set.Contains(newAns^x))
                    {
                        ans = newAns;
                        break;
                    }
                       
                    set.Add(x);
                }

           }

            return ans;
        }
    }
}
