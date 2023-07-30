using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _ThreeSum3
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> ret = new();
            for(int i=0;i<nums.Length-2;++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for(int j=i+1;j<nums.Length-1;++j)
                {
                    if (j>i+1&&nums[j] == nums[j - 1])
                        continue;
                    int k = nums.Length - 1;
                    int target = -nums[i] - nums[j];

                    for(; k>j;--k )
                    {
                        if (nums[k] > target)
                            continue;
                        else
                            break;
                    }
                    if (k == j)
                        break;
                    if (nums[k]==target)
                    {
                        ret.Add(new List<int> { nums[i], nums[j], nums[k] });
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
            //Test(new int[] {-1, 0, 1, 2, -1, -4});
            Test(new int[] { 1, 2, -2, -1 });


        }
        static void Test(int[] arr)
        {
            _ThreeSum3 threeSum = new _ThreeSum3();
            var ret = threeSum.ThreeSum(arr);
            foreach (var i in ret)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }
    }
}
