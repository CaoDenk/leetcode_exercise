using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2316. 统计无向图中无法互相到达点对数
    /// copy 
    /// </summary>
    internal class CountPairs_
    {

            private int[] parents;
            private int[] counts;

            public long CountPairs(int n, int[][] edges)
            {
                parents = new int[n];
                counts = new int[n];
                Array.Fill(parents, -1);
                Array.Fill(counts, 1);
                foreach (int[] edge in edges)
                {
                    Union(edge[0], edge[1]);
                }
                int count = 0;
                long ans = 0;
                for (int i = 0; i < n; ++i)
                {
                    ans += (long)count * counts[i];
                    count += counts[i];
                }
                return ans;
            }

            private int Find(int a)
            {
                if (parents[a] == -1)
                {
                    return a;
                }
                int root = Find(parents[a]);
                parents[a] = root;
                return root;
            }

            private void Union(int a, int b)
            {
                int s = Find(a);
                int t = Find(b);
                if (s != t)
                {
                    parents[t] = s;
                    counts[s] += counts[t];
                    counts[t] = 0;
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
