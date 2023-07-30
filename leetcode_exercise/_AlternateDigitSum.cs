using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _AlternateDigitSum
    {
        public int AlternateDigitSum(int n)
        {
            List<int> list = new List<int>();
            do
            {

                n = Math.DivRem(n, 10, out int i);
                list.Add(i);
            } while (n != 0);

            bool flag=true;
            list.Reverse();
            int sum = 0;
            foreach(var item in list)
            {
                if (flag)
                {
                    sum += item;
                }
                else
                    sum -= item;
                flag=!flag;
            }
            
            return sum;
        }
    }
}
