using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 超时了，需要修改
    /// </summary>
    internal class _ThreeSum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {

            Array.Sort(nums);
            List<IList<int>> ret = new List<IList<int>>();
            int? lastI = null;
            for (int i = 0; i < nums.Length - 2; ++i)
            {
                if (lastI == nums[i])
                    continue;
                lastI = nums[i];
                int? lastJ = null;
                for (int j = i + 1; j < nums.Length - 1; ++j)
                {
                    if (nums[j] == lastJ)
                        continue;
                    lastJ = nums[j];
                    int num = nums[i] + nums[j];
                    int target = -num;
                    int? lastK = null;
                    int k;
                    for (k = nums.Length - 1; k > j; --k)
                    {
                        if (nums[k] == lastK)
                            continue;
                        lastK = nums[k];
                        if (nums[k] > target)
                        {
                            continue;
                        }
                        else
                        {
                            if (nums[k] == target)
                            {
                                ret.Add(new List<int> { nums[i], nums[j], nums[k] });
                            }
                            break;
                        }
                    }
                    if (k == j)
                        break;
                }
            }

            return ret;
        }




        int Search(int start, int end, int[] nums, int target)
        {
            if (end - start == 0)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (nums[mid] == target)
                return mid;
            else if (nums[mid] > target)
                return Search(start, mid, nums, target);
            else
                return Search(mid + 1, end, nums, target);

        }

        static void Main(string[] args)
        {

            //Test(new int[] { -1, 0, 1, 2, -1, -4 });
            //Test(new int[] { 3, 0, -2, -1, 1, 2});
            //Test(new int[] { 0,0,0,0});
            Test(new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 });

        }
        static void Test(int[] arr)
        {
            _ThreeSum threeSum = new _ThreeSum();
            var ret = threeSum.ThreeSum(arr);
            foreach (var i in ret)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }
    }

        //class MyEqComparer : IEqualityComparer<int>
        //{

        //}
    

}
