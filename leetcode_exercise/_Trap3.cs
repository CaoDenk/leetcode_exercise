using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 42. 接雨水
    /// </summary>
    internal class _Trap3
    {

        public int Trap(int[] height)
        {
            if(height.Length<2)
                return 0;
            int max = height[0];
            int pos = 0;
            for(int i=1;i<height.Length;++i)
            {
                if (height[i]>max)
                {
                    max= height[i];
                    pos = i;
                }
            }
            int[] dp=new int[height.Length];
            dp[0] = height[0];
            int area = 0;
            for(int i=1;i<=pos;++i)
            {
                dp[i] = Math.Max(dp[i-1], height[i]);
                area += dp[i]-height[i];
            }
            dp[^1] = height[^1];
            for (int i = height.Length-1; i>pos; --i)
            {
                dp[i-1] = Math.Max(dp[i], height[i-1]);
                area += dp[i-1] - height[i - 1];
            }

            //Console.WriteLine(string.Join(",",dp));

            return area;
        }
        static void Main(string[] args)
        {
            _Trap3 t = new();
            Console.WriteLine(t.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }
    }
}
