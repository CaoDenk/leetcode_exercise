using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 5. 最长回文子串
    /// </summary>
    internal class _LongestPalindrome
    {
     

        public string LongestPalindrome(string s)
        {
            int start = 0, end = -1;
            s='#'+string.Join('#',s.ToArray())+'#';

            List<int> arm_len = new();
            int right = -1, j = -1;
            for (int i = 0; i < s.Length; ++i)
            {
                int cur_arm_len;
                if (right >= i)
                {
                    int i_sym = j * 2 - i;
                    int min_arm_len = Math.Min(arm_len[i_sym], right - i);
                    cur_arm_len = Expand(s, i - min_arm_len, i + min_arm_len);
                }
                else
                {
                    cur_arm_len = Expand(s, i, i);
                }
                arm_len.Add(cur_arm_len);
                if (i + cur_arm_len > right)
                {
                    j = i;
                    right = i + cur_arm_len;
                }
                if (cur_arm_len * 2 + 1 > end - start)
                {
                    start = i - cur_arm_len;
                    end = i + cur_arm_len;
                }
            }
            
            return new string(s[start..(end+1)].Where(x => x != '#').ToArray());
        }

        public int Expand(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                --left;
                ++right;
            }
            return (right - left - 2) / 2;
        }
    }
}
