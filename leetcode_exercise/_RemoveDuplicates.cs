using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _RemoveDuplicates
    {

        public int RemoveDuplicates(int[] nums)
        {

            HashSet<int> set = new HashSet<int>();
            foreach(int num in nums)
            {
                set.Add(num);
            }
            int idex = 0;
            foreach(int i in set)
            {
                nums[idex++] = i;
                
            }

            return set.Count;
        }
        public int RemoveDuplicates2(int[] nums)
        {

            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                set.Add(num);
            }
            int idex = 0;
            foreach (int i in set)
            {
                nums[idex++] = i;

            }

            return set.Count;
        }


    }
}
