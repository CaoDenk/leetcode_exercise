using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 40. 组合总和 II
    /// </summary>
    internal class CombinationSum2_
    {

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<int> ints = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            int sum = 0;
            int start = 0;
            Dfs(ans, ints, ref sum, candidates, target, start);
            return ans;
        }



        void Dfs(List<IList<int>> ans, List<int> list, ref int sum, int[] candidates, int target, int start)
        {
            if (sum == target)
            {
                ans.Add(list.ToList());
                return;
            }
            if (sum > target)
            {
                return;
            }
            for (int i = start; i < candidates.Length; ++i)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;
                sum += candidates[i];
                list.Add(candidates[i]);
                Dfs(ans, list, ref sum, candidates, target, i+1);
                list.RemoveAt(list.Count - 1);
                sum -= candidates[i];
            }
        }
        static void Main(string[] args)
        {
            {
                CombinationSum2_ c = new();
                var res = c.CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
                foreach (var i in res)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
            {
                CombinationSum2_ c = new();
                var res = c.CombinationSum2(new int[] { 2, 5, 2, 1, 2 }, 5);
                foreach (var i in res)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
        }
    }
}
