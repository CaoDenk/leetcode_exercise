using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Intersection
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>(nums1);

            HashSet<int>  ret= new HashSet<int>();
            foreach(int i in nums2) 
            {
                if(set.Contains(i))
                    ret.Add(i);
            
            }
            return ret.ToArray();
        }
    }
}
