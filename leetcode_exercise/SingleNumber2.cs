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
    internal class SingleNumber2
    {
        public int[] SingleNumber(int[] nums)
        {
            Dictionary<int, int> dict = [];
            
            foreach (int i in nums)
            {
                dict[i] = dict.GetValueOrDefault(i) + 1;
            }
            int[] arr = new int[2];
            int j = 0;
            foreach((int k,int v) in dict)
            {
                if (v == 1)
                    arr[j++] = k;
                if (j == 2)
                    break;
            }
            return arr;

        }

    }
}
