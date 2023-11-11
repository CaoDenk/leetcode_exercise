using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2316. 统计无向图中无法互相到达点对数
    /// 挖坑
    /// </summary>
    internal class CountPairs_
    {

       

        public long CountPairs(int n, int[][] edges)
        {
            int[] pa= Enumerable.Range(0, n).ToArray();
            int[] count = Enumerable.Repeat(1,n).ToArray();
            foreach(var edge in edges)
            {
                Union(edge[0], edge[1], pa,count);
            }
            long ans = 0;
            long t = 0;
            for (int i = 0; i < n; i++)
            {
                if (count[i] == 0) continue;
                ans += t * count[i];
                t += count[i];
            }
                
            return ans;
        }

        int Find(int x, int[] pa) => pa[x] == x ? x : Find(pa[x], pa);

        void Union(int x,int y, int[] pa, int[] count)
        {
            int px=Find(x, pa);
            int py=Find(y, pa);
            if(px!=py)
            {
                pa[py]= px;
                count[px] += count[py];
                count[py] = 0;
            }

        }

          
        
        static void Main(string[] args)
        {
            CountPairs_ c = new();
            {
                int n = 7;
                int[][] edges = [[0, 2], [0, 5], [2, 4], [1, 6], [5, 4]];
                long res = c.CountPairs(n, edges);
                Console.WriteLine(res);
            }
           
        }
    }
}
