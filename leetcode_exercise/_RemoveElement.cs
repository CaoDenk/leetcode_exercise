using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _RemoveElement
    {

        public int RemoveElement(int[] nums, int val)
        {
            int r = nums.Length-1;
            for(;r>=0;r--)
            {
                if (nums[r] == val)
                    break;

            }

            if (nums[0] == val)
                return 0;

            int l = 0;





            return 0;
        }


        void sawp(ref int l,ref int r)
        {



        }


        
    }
}
