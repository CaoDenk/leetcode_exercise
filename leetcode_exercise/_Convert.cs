using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Convert
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
                    _=flag? ++i : --i;
                }
                else
                {
                    flag = !flag;
                    _=flag? i+= 2:i -= 2;
                    continue;
                }
                j++;
            }
            StringBuilder res = new StringBuilder();
           
            foreach(var ar in arr) 
            {
                res.Append(ar);
            }
            return res.ToString();
        }
    }
}
