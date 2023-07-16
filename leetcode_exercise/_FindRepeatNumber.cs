using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _FindRepeatNumber
    {
        public int FindRepeatNumber(int[] nums)
        {
            HashSet<int> result = new HashSet<int>();
            foreach (int num in nums)
            {
                if (result.Contains(num))
                {
                    return num;
                }else
                { result.Add(num); }
            }
            throw new Exception();
        }
    }
}
