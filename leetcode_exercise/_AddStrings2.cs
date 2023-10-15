using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 415. 字符串相加
    /// </summary>
    internal class _AddStrings2
    {
        public string AddStrings(string num1, string num2)
        {
            int add = 0,i=num1.Length-1,j=num2.Length-1;
            StringBuilder sb = new StringBuilder();
            while(i>=0||j>=0||add!=0)
            {
                int n1 = i >= 0 ? num1[i] - '0' : 0;
                int n2 = j >= 0 ? num2[j] - '0' : 0;

                int result = n1 + n2 + add;

                add= Math.DivRem(result, 10, out int rem);
                sb.Append(rem);
                --i;
                --j;
            }
            var ienum = sb.ToString().Reverse().ToArray();
            return new string(ienum);
        }
        static void Main(string[] args)
        {
            _AddStrings2 a = new();
            var ret = a.AddStrings("11", "123");
            Console.WriteLine(ret);
        }
    }
}
