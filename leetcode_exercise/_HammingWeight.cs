using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 191. 位1的个数
    /// </summary>
    internal class _HammingWeight
    {
        public int HammingWeight2(uint n) => Convert.ToString(n, 2).Where(i => i == '1').Count();
        public int HammingWeight(uint n)
        {
            n -= (n >> 1) & 0x55555555;
            n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
            n = n + (n >> 4) & 0x0f0f0f0f;
            n += n >> 8;
            n += n >> 16;
            return (int)(n & 0x3f);
        }
    }
}
