using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1716. 计算力扣银行的钱
    /// </summary>
    internal class TotalMoney_
    {
        static int Sum = new[] {1,2,3,4,5,6,7 }.Sum();
        public int TotalMoney(int n)
        {
            int ret = 0;
           int weeknum=Math.DivRem(n,7,out int rem);

            for(int i=0;i< weeknum; i++)
            {
                ret += Sum;
                Sum += 7;
            }
            
            int r = rem*weeknum;
            for(int i=1;i<=rem;++i)
            {
                r += i;
            }
            return ret + r;
        }
        static void Main(string[] args)
        {
            //{
            //    _TotalMoney t = new();
            //    Console.WriteLine(t.TotalMoney(4));
            //}
            {
                TotalMoney_ t = new();
                Console.WriteLine(t.TotalMoney(20));
            }

        }
    }
}
