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
            if (divisor == 1)
            {
                if (dividend != int.MinValue)
                    return dividend;
                return int.MinValue;
            }
            if (divisor == -1)
            {
                if (dividend != int.MinValue)
                    return -dividend;
                return int.MaxValue;
            }
               

            
            if (dividend > 0)
            {
                if (divisor > 0)
                {                   
                    int ret = 0;
                    while ((dividend -= divisor) >= 0)
                    {
                        ++ret;
                    }
                    return ret;
                }
                else
                {
                    if (divisor == -1)
                    {
                        return -dividend;   
                    }

                    int ret = 0;
                    while ((dividend += divisor) >= 0)
                    {
                        ++ret;
                    }
                    return -ret;

                }

            }
            else
            {
                if (divisor > 0)
                {
                   

                    int d = -dividend;
                    int ret = 0;
                    //num1 = dividend - divisor;
                    while ((d -= divisor) >= 0)
                    {
                        ++ret;
                    }
                    return -ret;
                }
                else
                {
                   
                    int d = -dividend;
                    int ret = 0;
                    //num1 = dividend - divisor;
                    while ((d += divisor) >= 0)
                    {
                        ++ret;
                    }
                    return ret;

                }
            }

        
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
