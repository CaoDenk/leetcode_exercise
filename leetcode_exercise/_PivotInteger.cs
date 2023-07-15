using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2485. 找出中枢整数
    /// </summary>
    internal class _PivotInteger
    {
        public int PivotInteger1(int n)
        {
            for(int i = 1; i <= n;++i)
            {
                for(int j=1;j<=i;++j)
                {
                    int num1 = (1 + i) * i / 2;
                    int num2 = (i + n) * (n - i + 1) / 2;
                    if (num1 == num2)
                        return i;
                }
            }
            return -1;
        }
        public int PivotInteger(int n)
        {
            int num = n * n + n / 2;
            double sq=Math.Sqrt(num);
            int i = (int)sq;
            if(i*i==num)
            {
                return i;
            }
            return -1;
        }
    }
}
