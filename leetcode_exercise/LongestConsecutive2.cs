using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 128. 最长连续序列
    /// 要求是O(n)
    /// </summary>
    internal class LongestConsecutive2
    {
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                set.Add(num);
            }
            //Dictionary<int,int> map = new Dictionary<int,int>();
            
            int longestStreak = 0;
            foreach (int num in set)
            {
                if (!set.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (set.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;

        }
    }
}
