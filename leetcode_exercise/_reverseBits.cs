using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 190. 颠倒二进制位
    /// </summary>
    internal class _reverseBits
    {
        public uint reverseBits(uint n)
        {
            string s = new(Convert.ToString(n, 2).PadLeft(32, '0').Reverse().ToArray());
            return Convert.ToUInt32(s, 2);
        }
    }
}
