using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _ReplaceSpace
    {
        public string ReplaceSpace(string s)
        {
          StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c!=' ')
                {
                    sb.Append(c);

                }else
                {
                    sb.Append("%20");
                }
            }
            return sb.ToString();

        }

    }
}
