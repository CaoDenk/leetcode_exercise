using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 挖坑
    /// </summary>
    internal class _StrStr
    {
        public int StrStr(string haystack, string needle)
        {
            return FindString(haystack,needle);
        }

        public int FindString(string str, string fstr)
        {
            int[] nextJ = GetNextJ(fstr);
            int j = 0;
            int i = 0;
            while (i < str.Length)
            {
                Console.WriteLine($"i={i},j={j}");
                if (j>=0&&str[i] == fstr[j])
                {
                  
                    ++i;
                    ++j;
                }
                else
                {
                    if(j<0)
                    {
                        j = 0;
                        ++i;
                        continue;
                    }else if(j>0)
                    {
                        j = nextJ[j - 1];
                    }else //说明j==0 并且str[i]!=fstr[0]
                    {
                        ++i;
                    }
                    
               
                    Console.WriteLine($"i={i},j={j}");
                    continue;
                }
                if (j >= fstr.Length)
                {
                    return i - fstr.Length;
                }
            }
            return -1;
        }
        int[] GetNextJ(string fstr)
        {
            int[] nextj = new int[fstr.Length];
            nextj[0] = -1;
            for (int i = 1; i < fstr.Length; ++i)
            {
                if (fstr[i] == fstr[i - 1])
                {
                    nextj[i] = nextj[i - 1] + 1;
                }
                else
                {
                   
                }
            }
            return nextj;
        }

        static void Main(string[] args)
        {
            _StrStr s = new();
            //Console.WriteLine(s.StrStr("aabaaabaaac", "aabaaac"));
            Console.WriteLine(s.StrStr("mississippi", "issip"));
            Console.WriteLine("mississippi".IndexOf("issip"));
        }
    }
}
