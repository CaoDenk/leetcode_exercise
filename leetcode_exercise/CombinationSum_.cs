using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 39. 组合总和
    /// </summary>
    internal class CombinationSum_
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<int> ints = new List<int>();
            List<IList<int>> ans=new List<IList<int>>();
            int sum = 0;
            int start = 0;
            Dfs(ans, ints, ref sum, candidates, target,  start);
            return ans;
        }

        void Dfs(List<IList<int>> ans, List<int> list,ref int sum, int[] candidates,int target, int start)
        {
            if(sum==target)
            {
                ans.Add(list.ToList());
                return;
            }
            if(sum>target)return;
            for(int i=start;i<candidates.Length;++i)
            {                
                sum += candidates[i];
                list.Add(candidates[i]);
                Dfs(ans, list, ref sum, candidates, target, i);
                list.RemoveAt(list.Count - 1);
                sum -= candidates[i];
            }
           
        }

        static void Main(string[] args)
        {
            CombinationSum_ c = new();
            var res=c.CombinationSum([2, 3, 6, 7], 7);
            foreach (var item in res)
            {
                Console.WriteLine(string.Join(",",item));
            }
        }

    }
}
