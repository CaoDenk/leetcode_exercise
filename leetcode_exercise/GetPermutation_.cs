using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 60. 排列序列
    /// </summary>
    internal class GetPermutation_
    {
        public string GetPermutation(int n, int k)
        {
            bool[] vis = new bool[n];
            string ans=null;
            int count = 0;
            Dfs(vis, n, 0, new List<int>(), ref ans, ref  count, k);
            return ans;
        }

        bool Dfs(in bool[] vis, in int n, int idx, List<int> l, ref string ans,ref int count,in int k)
        {
            
            if (idx == n)
            {
                ++count;
                if (count == k)
                {
                    ans = string.Join("", l);
                    return true;
                }else
                    return false;
            }
            for (int i = 1; i <= n; ++i)
            {
                if (vis[i-1])
                {
                    continue;
                }
                l.Add(i);
                vis[i-1] = true;
                //bool res= ;
                if (Dfs(vis, in n, idx + 1, l, ref ans, ref count, k))
                {
                    return true;  
                }
                l.RemoveAt(idx);
                vis[i-1] = false;
            }
            return false;
        }

        static void Main(string[] args)
        {
            GetPermutation_ g = new();
            Console.WriteLine(g.GetPermutation(3,3));
        }
    }
}
