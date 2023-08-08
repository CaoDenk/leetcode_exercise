using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
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
