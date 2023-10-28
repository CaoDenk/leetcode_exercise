using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 28. 找出字符串中第一个匹配项的下标
    /// </summary>
    internal class _StrStr
    {

        public int StrStr(string str, string fstr)
        {
            int[] nextJ = GetNextJ(fstr);
            int j = 0,i = 0;
            while (i < str.Length)
            {
                if (j >=0 && str[i] == fstr[j])
                {
                    ++i;
                    if (++j >= fstr.Length)
                        return i - j;
                }
                else if (j > 0)
                    j = nextJ[j];
                else 
                {
                    ++i;
                    j = 0;
                }
            }
            return -1;
        }
        int[] GetNextJ(string fstr)
        {
            int[] nextj = new int[fstr.Length];
            nextj[0] = -1;
            int i = 1,pos = -1;
            while(i<fstr.Length)
            {
                if (pos < 0||fstr[i-1] == fstr[pos])
                    nextj[i++] = ++pos;
                else
                    pos = nextj[pos];
            }
            return nextj;
        }

        static void Main(string[] args)
        {
            _StrStr str = new();
            Console.WriteLine(str.StrStr("sadbutsad", "sad"));
            Console.WriteLine(str.StrStr("mississippi", "issip"));
            Console.WriteLine(str.StrStr("mississippi", "issipi"));
            Console.WriteLine(str.StrStr("babba", "bbb"));
            Console.WriteLine(str.StrStr("hello", "ll"));
            Console.WriteLine(str.StrStr("a", "a"));


            //Console.WriteLine(str.StrStr("aabaaabaaac", "aabaaac"));
            //int[] j = str.GetNextJ("aabaaace");
            //Console.WriteLine(string.Join(",",j));
            //{
            //    int[] j = str.GetNextJ("issipi");
            //    Console.WriteLine(string.Join(",", j));
            //}

        }
    }
}
