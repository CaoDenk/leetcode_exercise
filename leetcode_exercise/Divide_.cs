using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 29. 两数相除
    /// </summary>
    internal class Divide_
    {
        public int Divide(int dividend, int divisor)
        {
            if (dividend == 0) return 0;
            if(divisor==1) return dividend;
            if(divisor==-1)
            {
                if (dividend == int.MinValue) return int.MaxValue;
                else return -dividend;
            }
            int[] divisorArr = new int[33];
            bool signed = false;
            int res = 0;
            switch((dividend, divisor))
            {
                case ( > 0, < 0):
                    signed = true;
                    if (divisor == int.MinValue) return 0;
                    divisor = -divisor;
                    break;
                case ( < 0, > 0):
                    signed = true;
                    if (dividend == int.MinValue)
                    {
                        dividend += divisor;
                        ++res;
                    }
                    dividend = -dividend;
                    break;
                case ( < 0, < 0):

                    if (divisor == int.MinValue)
                    {
                        if (dividend == int.MinValue) return 1;
                        else return 0;
                    }
                    if (dividend == int.MinValue)
                    {
                        dividend -= divisor;
                        ++res;
                    }
                    dividend = -dividend;
                    divisor = -divisor;
                    break;
            }

            divisorArr[0] = divisor;
            int i = 0;
            while (true)
            {
                if (dividend < divisorArr[0]) break;

                if (dividend == divisorArr[i])
                {
                    res += (1<<i);
                    break;
                }
               
                do
                {
                    ++i;
                    divisorArr[i] = divisorArr[i - 1] + divisorArr[i - 1];
                } while (divisorArr[i] > 0 && dividend > divisorArr[i]);
                dividend -= divisorArr[i-1];
                res += 1 << i-1;
                i = 0;
            }
            return  signed?-res:res;
        }

        static void Main()
        {
            Divide_ divide = new();
            //{
            //    int ret = divide.Divide(-2147483648, -1);
            //    Console.WriteLine(ret);
            //}
            //{
            //    int ret = divide.Divide(100, 2);
            //    Console.WriteLine(ret);
            //}
            //{
            //    int ret = divide.Divide(-2147483648, 2);
            //    Console.WriteLine(ret);
            //}
            //{
            //    int ret = divide.Divide(-2147483648, -3);
            //    Console.WriteLine(ret == -2147483648 / (-3));
            //}
            //{
            //    int divided = -1006986286;
            //    int divisor = -2145851451;
            //    int ret = divide.Divide(divided,divisor);
            //    Console.WriteLine(divided/divisor);
            //}
            //{
            //    int divided = -1021989372;
            //    int divisor = -82778243;
            //    int ret = divide.Divide(divided, divisor);
            //    Console.WriteLine(ret==divided / divisor);
            //}
            //{
            //    int divided =  1038925803;
            //    int divisor = -2147483648;
            //    int ret = divide.Divide(divided, divisor);
            //    Console.WriteLine(ret == divided / divisor);
            //}
            {
                int divided = -2147483648;
                int divisor = -3;
                int ret = divide.Divide(divided, divisor);
                Console.WriteLine(ret);
                Console.WriteLine( divided / divisor);
            }
        }
    }
}
