using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    internal class LengthOfLastWord_
    {
        public int LengthOfLastWord(string s)
        {
            string str=s.Trim();
            if(str.Length == 0)
                return 0;
            int end=str.Length-1;
            int len = 0;
            for(; end>=0; )
            {
                if(s[end] != ' ')
                {
                    --end;
                    ++len;
                }else
                    break;

            }


            return len;
        }

    }
}
