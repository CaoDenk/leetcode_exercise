using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 216. 组合总和 III
    /// 挖坑
    /// </summary>
    internal class CombinationSum3_
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {

            List<int> ints = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();
            int sum = 0;
            int start = 0;
            Recursive(ans, ints, ref sum, k, n, start);
            return ans;
        }

        void Recursive(List<IList<int>> ans, List<int> list, ref int sum,int k, int target, int start)
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

            for (int i = start; i <k; ++i)
            {
               
                sum += i;
                list.Add(i);
                Recursive(ans, list, ref sum, k, target, i + 1);
                list.RemoveAt(list.Count - 1);
                sum -= i;
            }

        }
        static void Main(string[] args)
        {
            CombinationSum3_ c = new();
            var res = c.CombinationSum3(3, 7);
            foreach (var i in res)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }
    }
}
