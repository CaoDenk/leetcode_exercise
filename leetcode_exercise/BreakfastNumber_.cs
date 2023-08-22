using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// LCP 18. 早餐组合
    /// 超时。。。。。
    /// </summary>
    internal class BreakfastNumber_
    {
        public int BreakfastNumber(int[] staple, int[] drinks, int x)
        {
            Array.Sort(staple);
            Array.Sort(drinks);
            long count = 0;
            for (int i = 0; i < staple.Length; ++i)
            {
                if (staple[i] > x)
                    break;
                for (int j = 0; j < drinks.Length; ++j)
                {
                    if (staple[i] + drinks[j] > x)
                        break;
                    else
                        ++count;
                }
            }

            return (int)(count % 1000000007);
        }
    }
}
