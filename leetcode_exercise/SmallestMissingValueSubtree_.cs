using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class SmallestMissingValueSubtree_
    {
        public int[] SmallestMissingValueSubtree(int[] parents, int[] nums)
        {
            int[] ans = Enumerable.Repeat(1, parents.Length).ToArray();
            int node = Array.FindIndex(nums, x => x == 1);
            if (node < 0) return ans;
            var children = Build(parents);
            HashSet<int> vis = new();
            int cnt = 2;
            while (node >= 0)
            {
                Dfs(children, vis, nums, node);
                while (vis.Contains(cnt)) cnt++;
                ans[node] = cnt;
                node = parents[node];

            }
            return ans;
        }
        void Dfs(List<int>[] children, HashSet<int> vis, int[] nums, int i)
        {
            vis.Add(nums[i]);
            foreach (int child in children[i])
            {
                if (!vis.Contains(nums[child])) Dfs(children, vis, nums, child);
            }
        }


        List<int>[] Build(int[] parents)
        {
            List<int>[] children = Enumerable.Range(0, parents.Length).Select(_ => new List<int>()).ToArray();
            for (int i = 1; i < parents.Length; i++) children[parents[i]].Add(i);
            return children;
        }
        static void Main(string[] args)
        {
            SmallestMissingValueSubtree_ s = new();
            //{
            //    int[] parents = [-1, 0, 0, 2];
            //    int[] nums = [1, 2, 3, 4];
            //    var ans=s.SmallestMissingValueSubtree(parents,nums);
            //    Console.WriteLine(string.Join(",",ans));

            //}
            {
                int[] parents = [-1, 0, 1, 0, 3, 3];
                int[] nums = [5, 4, 6, 2, 1, 3];
                var ans = s.SmallestMissingValueSubtree(parents, nums);
                Console.WriteLine(string.Join(",", ans));

            }
        }

    }
}
