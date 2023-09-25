using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2591. 将钱分给最多的儿童
    /// </summary>
    internal class DistMoney_
    {
        public int DistMoney(int money, int children)
        {
            if (money < children)
            {
                return -1;
            }
            int left = money - children;

            int count = Math.DivRem(left, 7, out int rem);

            if(count>children)
            {
                return children - 1;
            }
            if(count==children)
            {
                if (rem == 0)
                {
                    return children;
                }
                else
                    return children - 1;

            }

           if(count<children)
            {
                
                if(rem==3&&count>0)
                {
                    if(children-count<=1)
                        return count - 1;
                }
           }
         
            return count;
        }

        static void Main(string[] args)
        {
            DistMoney_ d = new();
            {
                Console.WriteLine(d.DistMoney(20, 3));
                Console.WriteLine(d.DistMoney(16, 2));
                Console.WriteLine(d.DistMoney(8, 2));
                Console.WriteLine(d.DistMoney(13, 3));
                Console.WriteLine(d.DistMoney(9, 2));
            }
        }
    }
}
