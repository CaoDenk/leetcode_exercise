using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 78. 子集
    /// </summary>
    internal class Subsets_
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> ans=new List<IList<int>>();
            List<int> list=new List<int>();
            Recurse(nums,ans,list,0);
            return ans;
        }
        void Recurse(int[] nums,List<IList<int>> ans,List<int> l,int start)
        {
            if(start==nums.Length)
            {
                ans.Add(l.ToList());
                return;
            }
            l.Add(nums[start]);
            Recurse(nums,ans,l,start+1);//加入
            l.RemoveAt(l.Count - 1);

            Recurse(nums, ans, l, start + 1);//不加入
        }
    }
}
