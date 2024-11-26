using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 6. N 字形变换
    /// </summary>
    internal class Convert_
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            string[] arr=Enumerable.Repeat(string.Empty, numRows).ToArray();
            int i = 0, j = 0;
            bool flag = true;
            while (j < s.Length)
            {
                if (i < numRows && i >= 0)
                {
                    arr[i] += s[j];
                    i += flag ? 1 : -1;
                }
                else
                {
                    flag = !flag;
                    i += flag ? 2 : -2;
                    continue;
                }
                j++;
            }
            return string.Concat( arr);
        }
    }
}
