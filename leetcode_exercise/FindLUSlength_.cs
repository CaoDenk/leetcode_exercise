using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 521. 最长特殊序列 Ⅰ
    /// </summary>
    internal class FindLUSlength_
    {
        public int FindLUSlength(string a, string b)
        {
            if (a == b) return -1;
            return Math.Max(a.Length, b.Length);
        }
      
    }
}
