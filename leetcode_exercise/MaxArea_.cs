using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1465. 切割后面积最大的蛋糕
    /// </summary>
    internal class MaxArea_
    {
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {

            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);
            long hlen = horizontalCuts[0];
            long wlen = verticalCuts[0];
            for(int i = 1;i<horizontalCuts.Length;++i)
            {
               hlen=Math.Max(hlen, horizontalCuts[i] - horizontalCuts[i-1]);
            }
            hlen = Math.Max(hlen, h - horizontalCuts[^1]);
            for (int i = 1; i < verticalCuts.Length; ++i)
            {
                wlen = Math.Max(hlen, verticalCuts[i] - verticalCuts[i - 1]);
            }
            wlen = Math.Max(wlen, w - verticalCuts[^1]);
            return (int)(hlen*wlen%(10_0000_0000+7));
        }
        static void Main(string[] args)
        {
            MaxArea_ m = new();
            {
                int h = 5;
                int w = 4;
                int[] horizontalCuts = [1, 2, 4];
                int[] verticalCuts = [1, 3];
                Console.WriteLine(m.MaxArea(h, w, horizontalCuts, verticalCuts));
            }

            {
                int h = 5;
                int w = 4;
                int[] horizontalCuts = [3,1];
                int[] verticalCuts = [3];
                Console.WriteLine(m.MaxArea(h, w, horizontalCuts, verticalCuts));
            }
            {
                int h = 5;
                int w = 4;
                int[] horizontalCuts = [3];
                int[] verticalCuts = [3];
                Console.WriteLine(m.MaxArea(h, w, horizontalCuts, verticalCuts));
            }

        }
    }
}
