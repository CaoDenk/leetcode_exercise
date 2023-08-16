using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 771. 宝石与石头
    /// </summary>
    internal class NumJewelsInStones_
    {
        public int NumJewelsInStones(string jewels, string stones)
        {

            HashSet<char> jewelsSet = new();
          

            foreach (char jewel in jewels)
            {
                jewelsSet.Add(jewel);
            }
            int count = 0;
            foreach (char jewel in stones)
            {
                if (jewelsSet.Contains(jewel))
                    ++count;
            }

            return count;

        }
    }
}
