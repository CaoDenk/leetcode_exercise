using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2496. 数组中字符串的最大值
    /// </summary>
    internal class MaximumValue_
    {
        public int MaximumValue(string[] strs)
        {
            int max = 0;
            foreach (string str in strs)
            {
                int len = 0;
                try
                {
                    len = int.Parse(str);
                }catch (FormatException)
                {
                    len = str.Length;
                }
                max=Math.Max(max, len);
            }
            return max;

        }
    }
}
