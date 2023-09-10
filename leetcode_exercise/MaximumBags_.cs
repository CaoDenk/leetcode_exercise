using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2279. 装满石头的背包的最大数量
    /// </summary>
    internal class MaximumBags_
    {

        public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
        {
          
            var  num= capacity.Zip(rocks,(n1,n2)=>n1-n2).ToArray();
            Array.Sort(num);
            int count = 0;
            foreach(int n in num)
            {
                if(additionalRocks-n>=0)
                {
                    ++count;
                    additionalRocks -= n;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            MaximumBags_ m = new();
            int[] capacity = { 2, 3, 4, 5 };
            int[] rocks = { 1, 2, 4, 4 };
            int additionalRocks = 2;
            Console.WriteLine(m.MaximumBags(capacity,rocks,additionalRocks));
        }
    }
}
