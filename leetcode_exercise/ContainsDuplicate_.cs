using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 217. 存在重复元素
    /// </summary>
    internal class ContainsDuplicate_
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            foreach (int i in nums)
            {
                if (!result.Add(i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
