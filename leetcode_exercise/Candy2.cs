using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 135. 分发糖果
    /// </summary>
    internal class Candy2
    {
        public int Candy(int[] ratings)
        {
            int n=ratings.Length;
            int[] left=new int[n];
            int[] right=new int[n];
            
            for(int i=1; i<n;++i)
            {
                if (ratings[i] > ratings[i-1])
                    left[i] = left[i-1]+1;

            }
            int count = left[^1];
            for (int i = n-2; i>=0; --i)
            {
                if (ratings[i] > ratings[i+1])
                    right[i] = right[i +1] + 1;
                count += Math.Max(left[i], right[i]);
            }
            return count + n;
        }
    }
}
