using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 43. 字符串相乘
    /// 不能使用任何内置的 BigInteger 库或直接将输入转换为整数 这个需要重写下
    /// </summary>
    internal class Multiply_
    {
        public string Multiply(string num1, string num2)
        {
            BigInteger bigInteger1=BigInteger.Parse(num1);
            BigInteger bigInteger2=BigInteger.Parse(num2);
            var res = bigInteger1 * bigInteger2;
            return res.ToString();

        }

    }
}
