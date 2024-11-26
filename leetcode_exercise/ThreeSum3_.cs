using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class ThreeSum3_
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> ret = new();
            for(int i=0;i<nums.Length-2;++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                int j=i+1;                    
                int k = nums.Length - 1;
                int target = -nums[i];
                while(j<k)
                {
                    int tmp = nums[j] + nums[k];
                    if (tmp<target)
                    {
                        j++;
                    }else if (tmp> target)
                    {
                        k--;
                    }
                    else
                    {
                        ret.Add(new List<int> { nums[i], nums[j], nums[k] });
                        while (k > j && nums[k] == nums[k - 1]) k--;
                        while (k > j && nums[j] == nums[j + 1]) j++;
                        ++j;
                        k--;
                    
                    }
                }
                   
            }


            return ret;
        }

        static void Main(string[] args)
        {

            //Test(new int[] { -1, 0, 1, 2, -1, -4 });
            //Test(new int[] { 3, 0, -2, -1, 1, 2});
            //Test(new int[] { 0,0,0,0});
            //Test(new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 });
            //Test(new int[] { -1, 0, 1, 2, -1, -4 });
            Test(new int[] { -2, 0, 1, 1, 2 });
            //Test(new int[] { 1, 2, -2, -1 });


        }
        static void Test(int[] arr)
        {
            ThreeSum3_ threeSum = new ThreeSum3_();
            var ret = threeSum.ThreeSum(arr);
            foreach (var i in ret)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }
    }
}
