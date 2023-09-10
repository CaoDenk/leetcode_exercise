using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 392. 判断子序列
    /// </summary>
    internal class IsSubsequence_
    {
        public bool IsSubsequence(string s, string t)
        {

            int lastPos = -1;
            foreach (var c in s)
            {
                lastPos = t.IndexOf(c, lastPos + 1);
                if (lastPos == -1)
                    return false;
            }
            return true;
        }
    }
}
