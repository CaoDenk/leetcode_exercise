using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 90. 子集 II
    /// </summary>
    internal class SubsetsWithDup_
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> ans = new();
            Recurse(nums, ans, new List<int>(), 0);

            return ans;
        }

        void Recurse(int[] nums, List<IList<int>> ans, List<int> l, int start)
        {

            ans.Add(l.ToList());//不继续选的已经终止了
            if (start == nums.Length)
            {
                return;
            }
            for(int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i-1])
                {
                    continue;
                }else
                {
                    l.Add(nums[i]);
                    Recurse(nums, ans, l, i + 1);//加入
                    l.RemoveAt(l.Count - 1);
                }
            }
        }
        static void Main(string[] args)
        {
            SubsetsWithDup_ s = new();
            {
                int[] nums = [1, 2, 2];
                var res=s.SubsetsWithDup(nums);
                Console.WriteLine(res.Count);
                foreach (var i in res)
                {
                    Console.WriteLine(string.Join(",",i));
                }
            }

        }

    }
}
