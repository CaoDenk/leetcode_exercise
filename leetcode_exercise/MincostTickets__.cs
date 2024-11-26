using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MincostTickets__
    {
        public int MincostTickets(int[] days, int[] costs)
        {
            int[] dura = [1, 7, 30];
            int[,] dp = new int[days.Length, costs.Length];
            int half = int.MaxValue / 2;
            for(int i = 0;i<costs.Length;++i)
            {
                for(int j = 0;j<days.Length;++j)
                {
                    for(int k = 0;k<dura.Length;++k)
                    {
                        if (days[j] - dura[k]>=0)
                        {
                            dp[0, 0] = 0;
                        }
                    }
                }
            }
            return dp[days.Length - 1, costs.Length - 1];
        }

        static void Main()
        {
            MincostTickets__ m = new();

        }
    }
}
