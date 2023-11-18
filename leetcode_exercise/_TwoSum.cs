using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1. 两数之和
    /// </summary>
    internal class _TwoSum
    {

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new int[] {  dict[target - nums[i]],i };
                }else
                {
                    dict[nums[i]] = i;
                }

            }           
            return null;
        }
        static void Main(string[] args)
        {
            _TwoSum t = new();

            var ret = t.TwoSum([3, 2, 4], 6);
            Console.WriteLine(string.Join(",",ret));
        }
    }
}
