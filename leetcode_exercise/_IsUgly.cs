using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 263. 丑数
    /// </summary>
    internal class _IsUgly
    {
        public bool IsUgly(int n)
        {
            if (n == 0) return false;
            if (n == 1) return true;
            int num = Math.DivRem(n, 2, out int i);
            if (i == 0)
                return IsUgly(num);
            num = Math.DivRem(n, 3, out i);
            if (i == 0)
                return IsUgly(num);
            num = Math.DivRem(n, 5, out i);
            if (i == 0)
                return IsUgly(num);
            return false;
        }
    }
}
