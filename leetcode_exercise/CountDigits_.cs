using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2520. 统计能整除数字的位数
    /// </summary>
    internal class CountDigits_
    {
        public int CountDigits(int num)
        {
            Dictionary<int, int> dict = new();
            int n = num;
            do
            {
                num = Math.DivRem(num, 10, out int rem);
                dict[rem] = dict.GetValueOrDefault(rem) + 1;
            } while (num != 0);
            int res = 0;
            foreach (var item in dict.Keys)
            {
                if (n % item == 0)
                    res += dict[item];
            }
            return res;
        }
    }
}
