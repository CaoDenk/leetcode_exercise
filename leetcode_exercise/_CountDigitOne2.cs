using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _CountDigitOne2
    {
        public int CountDigitOne(int n)
        {
            int ret = 0;
            for(int i=0; i <= n; i++)
            {
                ret+=Convert.ToString(i).Where(i=>i=='1').Count();
            }
           return ret;
        }
      

        static void Main()
        {
            _CountDigitOne2 _CountDigitOne2 = new _CountDigitOne2();
            Console.WriteLine(_CountDigitOne2.CountDigitOne(824883294));

        }

    }
}
