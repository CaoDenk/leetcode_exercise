using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 461. 汉明距离
    /// 挖坑
    /// </summary>
    internal class HammingDistance_
    {
        public int HammingDistance(int x, int y)
        {
            //BitConverter.
            //string s1=Convert.ToString(x, 2);
            //string s2=Convert.ToString(y, 2);
            int count = x ^ y;
            
            return BitCount(count);
        }
        public int BitCount(int i)
        {
            i -= ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i += (i >> 8);
            i += (i >> 16);
            return i & 0x3f;
        }
    }
}
