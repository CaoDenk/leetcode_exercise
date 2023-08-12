using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _ClimbStairs
    {
        public int ClimbStairs2(int n)
        {
            ++n;
            if(n<2) return 1;
            if(n==2) return 2;
            return Recur(n);
        }


        int Recur(int n)
        {
            
            if(n is 1 or 2)
            {
                return 1;
            }
            
            return Recur(n-1)+Recur(n-2);
        }





        static void Main()
        {
            _ClimbStairs c = new();
            
            //Console.WriteLine(c.ClimbStairs(3));
            //Console.WriteLine(c.ClimbStairs(4));
            //Console.WriteLine(c.ClimbStairs(5));
            //Console.WriteLine(c.ClimbStairs(6));

            //Console.WriteLine(c.ClimbStairs(45));

        }
    }
}
