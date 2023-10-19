using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 137. 只出现一次的数字 II
    /// </summary>
    internal class SingleNumber_
    {
        public int SingleNumber(int[] nums)
        {
            HashSet<int> key= new();
            HashSet<int> set = new HashSet<int>();
            foreach (int i in nums)
            {
                if(key.Contains(i))
                {
                    set.Remove(i);
                }else
                {
                    key.Add(i);
                    set.Add(i);
                }
            }
            
            return set.First();
        }
    }
}
