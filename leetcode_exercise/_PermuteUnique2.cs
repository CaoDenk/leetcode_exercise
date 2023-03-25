using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace leetcode_exercise
{
    internal class _PermuteUnique2
    {
        bool[] vis;

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> ans = new List<IList<int>>();
            List<int> perm = new List<int>();
            vis = new bool[nums.Length];
            Array.Sort(nums);
           
            backtrack(nums, ans, 0, perm);
            return ans;
        }

        public void backtrack(int[] nums, List<IList<int>> ans, int idx, List<int> perm)
        {
            if (idx == nums.Length)
            {
                ans.Add(new List<int>(perm));
                return;
            }
            for (int i = 0; i < nums.Length; ++i)
            {
                if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]))
                {
                    continue;
                }
                
                perm.Add(nums[i]);
                vis[i] = true;
                backtrack(nums, ans, idx + 1, perm);
                vis[i] = false;
                perm.RemoveAt(idx);
                //perm.Remove(idx);
            }
        }
        static void Print( IList<IList<int>> list)
        {
            foreach (var i in list)
            {
                foreach(var j in i)
                    Console.Write(j);
                Console.WriteLine();
            }


        }
        static void Main()
        {
            _PermuteUnique2 p = new();
            int[] arr ={1, 1,1,2};
            var ret= p.PermuteUnique(arr);
            Print(ret);
        }
    }

}
