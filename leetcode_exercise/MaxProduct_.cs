using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 318. 最大单词长度乘积
    /// </summary>
    internal class MaxProduct_
    {
        public int MaxProduct(string[] words)
        {
            List<HashSet<char>> breakUp = words.Select(word => new HashSet<char>(word)).ToList();
            int ans = 0;
            for(int i = 0;i<words.Length-1;++i)
            {
                for(int j = i+1;j<words.Length;++j)
                {
                    if (!words[i].Any(words[j].Contains))
                        ans = Math.Max(ans, words[i].Length * words[j].Length);

                }
            }
            return ans;
        }
    }
}
