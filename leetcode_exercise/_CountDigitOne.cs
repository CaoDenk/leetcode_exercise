using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _CountDigitOne
    {
        public int CountDigitOne(int n)
        {
            int ret = 0;
            for(int i = 1; i <= n; i++)
            {
                string s = Convert.ToString(i);
                ret += CountChar(s, '1');

            }
            return ret;
        }


        int CountChar(string s,char c)
        {
            int count = 0;
            for(int i=0;i<s.Length; i++)
            {
                if (s[i] == c)
                    ++count;
                
            }
            return count;
        }
        static void Main()
        {
            _CountDigitOne _CountDigitOne = new _CountDigitOne();
            Console.WriteLine(_CountDigitOne.CountDigitOne(824883294));

        }
    }
}
