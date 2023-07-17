using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _ContainsDuplicate
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            foreach (int i in nums)
            {
                if (result.Contains(i))
                {
                    return true;
                }else
                    result.Add(i);
            }
            return false;
        }
    }
}
