using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 70. 爬楼梯
    /// 超时
    /// </summary>
    internal class ClimbStairs2
    {
        public int ClimbStairs(int n)
        {
            ++n;
            if(n<2) return 1;
            if(n==2) return 2;
            return Dfs(n);
        }


        int Dfs(int n)
        {
            
            if(n is 1 or 2)
            {
                return 1;
            }
            return Dfs(n-1)+ Dfs(n-2);
        }





        static void Main()
        {
            ClimbStairs2 c = new();
            
            //Console.WriteLine(c.ClimbStairs(3));
            //Console.WriteLine(c.ClimbStairs(4));
            //Console.WriteLine(c.ClimbStairs(5));
            //Console.WriteLine(c.ClimbStairs(6));

            //Console.WriteLine(c.ClimbStairs(45));

        }
    }
}
