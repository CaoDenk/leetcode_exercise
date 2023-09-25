using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    
    internal class BreakInto
    {
        /// <summary>
        /// 将一个整数分解成若干个立方数之和，分解个数最少
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        int Break(int num)
        {
            //int n = (int)Math.Pow(num, 1.0 / 3.0)+1;
            int[] dp=new int[num+1];
           
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;
            dp[1] = 1;
            for (int i=2;i<=num;++i)
            {

                for(int j=1;;++j)
                {
                    int cub = j * j * j;
                    if (cub > i)
                        break;
                    dp[i] = Math.Min(dp[i], dp[i - cub] + 1);

                }

            }
           

            return dp[num];
        }

        static void Main(string[] args)
        {
            BreakInto b=new BreakInto();
            b.Break(100);
        }

    }
}
