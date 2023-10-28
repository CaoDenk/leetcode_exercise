using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 344. 反转字符串
    /// </summary>
    internal class _ReverseString
    {
        public void ReverseString(char[] s)
        {
            for(int i=0;i<s.Length/2;++i)
            {
                (s[i], s[^(i + 1)]) = (s[^(i + 1)], s[i]);
            }
        }
    }
}
