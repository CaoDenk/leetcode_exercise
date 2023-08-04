using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _SortedSquares
    {
        public int[] SortedSquares(int[] nums)
        {
            var arr= nums.Select(x=>x*x).ToArray();
            Array.Sort(arr);
            return arr;
        }
    }
}
