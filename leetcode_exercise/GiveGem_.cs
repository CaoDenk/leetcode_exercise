using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// LCP 50. 宝石补给
    /// </summary>
    internal class GiveGem_
    {
        public int GiveGem(int[] gem, int[][] operations)
        {
            for(int i=0;i< operations.Length;++i)
            {
                int braveSender = operations[i][0];
                int braveReceiver= operations[i][1];
                int half = gem[braveSender] / 2;
                gem[braveSender] -= half;
                gem[braveReceiver] += half;

            }
            

            return gem.Max()-gem.Min();
        }
    }
}
