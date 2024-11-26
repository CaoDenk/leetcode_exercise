using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 169. 多数元素
    /// </summary>
    internal class MajorityElement_
    {

        public int MajorityElement(int[] nums)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            int compare = (nums.Length) / 2;
            foreach (int i in nums)
            {
                if(dict.ContainsKey(i))
                {
                    dict[i] = 1;
                }else
                {
                    ++dict[i];
                    if (dict[i] >compare)
                    {
                        return i;
                    }
                }

            }
            return 0;
        }
        public int MajorityElement2(int[] nums)
        {
            if(nums.Length==1)
                return nums[0];

            int count = 1;
            int num = nums[0];
            for(int i=1;i<nums.Length;++i)
            {
                if (num == nums[i])
                    count++;
                else
                {
                    --count;
                    if(count==0)
                    {
                        num= nums[i];
                    }
                }    

            }
            
            return num;
        }



    }
}
