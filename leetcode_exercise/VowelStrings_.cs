using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2586. 统计范围内的元音字符串数
    /// </summary>
    internal class VowelStrings_
    {
        public int VowelStrings(string[] words, int left, int right)
        {
            HashSet<char> set = ['a', 'e', 'i', 'o', 'u'];
            int ans = 0;
            for(int i = left;i<=right;++i)
            {
                if (set.Contains(words[i][0]) && set.Contains(words[i][^1]))
                {
                    ++ans;
                }
            }
            return ans;
        }
    }
}
