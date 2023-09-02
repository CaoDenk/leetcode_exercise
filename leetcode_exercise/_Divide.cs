using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Divide
    {
        public int Divide(int dividend, int divisor)
        {
            long res = 0;



            return 0;
        }

        static void Main()
        {
            _Divide divide = new();
            {
                int ret = divide.Divide(-2147483648, -1);
                Console.WriteLine(ret);
            }
            {
                int ret = divide.Divide(-2147483648, 2);
                Console.WriteLine(ret);
            }
        }
    }
}
