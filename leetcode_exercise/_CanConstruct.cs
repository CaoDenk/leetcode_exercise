using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 383. 赎金信
    /// </summary>
    internal class _CanConstruct
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
     
            Dictionary<char, int> mag = new();
            foreach (char c in magazine) 
            {
                mag[c] = mag.GetValueOrDefault(c) + 1;
            }
            foreach (char c in ransomNote)
            {
                if (mag.GetValueOrDefault(c)==0)
                    return false;
                mag[c]--;
            }
            return true;

        }
    }
}
