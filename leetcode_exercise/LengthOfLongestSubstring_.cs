using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class LengthOfLongestSubstring_
    {
       
        public int LengthOfLongestSubstring(string s)
        {
            if(s.Length == 0) return 0;
            Dictionary<char,int> map = new Dictionary<char,int>();
            int start = 0;
            int maxLen = 0;
            map[s[0]] = 0;
            int newStart;
            for (int i=1;i<s.Length;++i)
            {
                if (map.ContainsKey(s[i]) && (newStart = map[s[i]]+1)>start)
                {
                        start = newStart;
                }else
                {
                    int end = i;
                    maxLen =maxLen>end-start?maxLen:end-start;
                }
                map[s[i]] = i;
            }

            return maxLen+1;
        }
        static void Main(string[] args)
        {
            LengthOfLongestSubstring_ l = new();
            Console.WriteLine(l.LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(l.LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine(l.LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine(l.LengthOfLongestSubstring("aab"));
            Console.WriteLine(l.LengthOfLongestSubstring("tmmzuxt"));
        }
    }
}
