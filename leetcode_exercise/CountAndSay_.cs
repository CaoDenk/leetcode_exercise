using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 38. 外观数列
    /// </summary>
    internal class CountAndSay_
    {
        public string CountAndSay(int n)
        {
            return Qn(n);
        }

        string Qn(int n)
        {   
            if (n == 1) return "1";
            string res =Qn(n-1);
            int count = 0;
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (; i < res.Length; i++)
            {
                if (i > 0 && res[i] != res[i - 1])
                {
                    sb.Append($"{count}{res[i - 1]}");
                    count = 1;
                }
                else
                {
                    count++;
                }
            }
            if (i > 0)
                sb.Append($"{count}{res[^1]}");
            return sb.ToString();
        }


        static void Main(string[] args)
        {
            CountAndSay_ c = new();
            Console.WriteLine(c.CountAndSay(1));
            Console.WriteLine(c.CountAndSay(2));
            Console.WriteLine(c.CountAndSay(3));
            Console.WriteLine(c.CountAndSay(4));
            //Console.WriteLine(Test());
        }
    }
}
