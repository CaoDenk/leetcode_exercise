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
            
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                string s = Convert.ToString(i);
                sb.Append(s);
            }
            return CountPerNum(sb.ToString());
        }


        /// <summary>
        /// 
        /// 个位是1的
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>

        int CountPerNum(string num)
        {

            CharEnumerator charEnumerator = num.GetEnumerator();
            int ret=0;
            while(charEnumerator.MoveNext())
            {
                char c = charEnumerator.Current;
                if (c == '1')
                    ++ret;
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
