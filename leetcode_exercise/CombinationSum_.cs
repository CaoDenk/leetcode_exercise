using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 39. 组合总和
    /// 挖坑
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
            Recursive(ans, ints, ref sum, candidates, target,  start);
            return ans;
        }

        void Recursive(List<IList<int>> ans, List<int> list,ref int sum, int[] candidates,int target, int start)
        {
          
            if (sum==target)
            {
                ans.Add(list.ToList());
                sum -= list[^1];
                list.RemoveAt(list.Count-1);
                Recursive(ans, list, ref sum, candidates, target, start + 1);
            }
            if(sum>target)
            {
                sum -= list[^1];
                list.RemoveAt(list.Count - 1);
                Recursive(ans, list, ref sum, candidates, target,  start+1);

            }
            else
            {
                sum += candidates[start];
                list.Add(candidates[start]);
                Recursive(ans, list, ref sum, candidates, target,  start);
            }
        }

        static void Main(string[] args)
        {
            CombinationSum_ c = new();
            var res=c.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            foreach (var item in res)
            {
                Console.WriteLine(string.Join(",",item));
            }
        }

    }
}
