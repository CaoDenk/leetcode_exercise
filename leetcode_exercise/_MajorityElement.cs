using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 169. 多数元素
    /// </summary>
    internal class _MajorityElement
    {

        public int MajorityElement(int[] nums)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            int compare = (nums.Length) / 2;
            foreach (int i in nums)
            {
                if(dict.ContainsKey(i))
                {
                    dict[i] = 1;
                }else
                {
                    ++dict[i];
                    if (dict[i] >compare)
                    {
                        return i;
                    }
                }

            }
            return 0;
        }
    }
}
