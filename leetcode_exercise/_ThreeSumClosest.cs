using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _ThreeSumClosest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            //int res=0;
            //int j, k;
            int res = nums[0] + nums[1] + nums[2];
            for (int i=0; i<nums.Length-2;i++)
            {
                
                int j=i+1;
                int k=nums.Length-1; 
                int _num =target-nums[i];
                while(j<k)
                {
                    int tmpsum = nums[j] + nums[k];
                    int _res=Math.Abs(res-target);
                    int sum = tmpsum + nums[i];
                    if (Math.Abs(sum - target) < _res)
                    {
                        res = sum;
                    }
                    if (_num >tmpsum)
                    {                                               
                        j++;
                    }else
                    {
                        k--;
                    }
                }

            }


            return res;
        }
    }
}
