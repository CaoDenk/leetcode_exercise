using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 274. H 指数
    /// </summary>
    internal class HIndex_
    {
        public int HIndex(int[] citations)
        {
            Array.Sort(citations);
            int h=citations.Length;
            int count = 0;
            int i = h - 1;
            while( i >= 0&& count < h)
            {
                if (citations[i]>=h)
                {
                    count++;
                    --i;
                }
                else
                {
                    --h;
                }
            }
            return h;

        }
        static void Main(string[] args)
        {
            HIndex_ h = new();
            {
                Console.WriteLine(h.HIndex([3, 0, 6, 1, 5]));
                Console.WriteLine(h.HIndex([4,4,0,0]));
                Console.WriteLine(h.HIndex([1,3,1]));
                Console.WriteLine(h.HIndex([1, 7, 9, 4]));
            }
        }
    }
}
