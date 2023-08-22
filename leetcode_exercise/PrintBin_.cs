using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 面试题 05.02. 二进制数转字符串
    /// </summary>
    internal class PrintBin_
    {
        public string PrintBin(double num)
        {
            StringBuilder sb = new StringBuilder("0.");
            while (sb.Length<=32)
            {
                if (num == 0)
                    break;
                num *= 2;
                int digit = (int)num;
                sb.Append(digit);
                num -= digit;
            }
            if (sb.Length > 32)
                return "ERROR";
            else
                return sb.ToString();
            
        }
        static void Main(string[] args)
        {
            PrintBin_ p = new();
            Console.WriteLine(p.PrintBin(0.625));
        }
    }
}
