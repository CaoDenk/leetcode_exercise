using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 46. 全排列
    /// </summary>
    internal class Permute2
    {

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            List<int> output = new List<int>(nums);
            int n = nums.Length;
            Backtrack(n, output, res, 0);
            return res;
        }

        public void Backtrack(int n, List<int> output, IList<IList<int>> res, int first)
        {
            // 所有数都填完了
            if (first == n)
            {
                res.Add(new List<int>(output));
            }
            for (int i = first; i < n; i++)
            {

                (output[first], output[i]) = (output[i], output[first]);
                // 动态维护数组        
                // 继续递归填下一个数
                Backtrack(n, output, res, first + 1);
                // 撤销操作
                (output[first], output[i]) = (output[i], output[first]);
            }
        }


    }
}
