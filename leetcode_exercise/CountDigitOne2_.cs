using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 小于n 转字符串1的个数 
    /// 位1的个数
    /// </summary>
    internal class CountDigitOne2_
    {
        public int CountDigitOne(int n)
        {
            int res = 0;
            int low = 0;
            int digit = 1;//位因子
            int hight=Math.DivRem(n, 10,out int cur);

            while(hight!=0||cur!=0)
            {
                if (cur == 0)
                {
                    res += hight * digit;
                }
                else if (cur == 1)
                {
                    res += hight * digit + low + 1;
                }
                else
                    res += (hight + 1) * digit;

                low += cur * digit;
                hight=Math.DivRem(hight, 10, out cur);
                digit *= 10;
            }

           return res;
        }
      

        static void Main()
        {
            CountDigitOne2_ _CountDigitOne2 = new CountDigitOne2_();
            Console.WriteLine(_CountDigitOne2.CountDigitOne(824883294));

        }

    }
}
