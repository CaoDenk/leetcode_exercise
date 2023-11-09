
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2127. 参加会议的最多员工数
    /// 挖坑
    /// </summary>
    internal class MaximumInvitations_
    {

  
        public int MaximumInvitations(int[] favorite)
        {
            int[] deg=new int[favorite.Length];//InDegree
            foreach(int i in favorite) 
            {
                deg[i]++;//统计入度
            }

            List<int>[] rg = Enumerable.Repeat(new List<int>(),favorite.Length).ToArray();

            Queue<int> q = new Queue<int>();
            for(int i = 0;i<favorite.Length;++i)
            {
                if (deg[i]==0)
                    q.Enqueue(i);
            }
            int[] maxDepth =Enumerable.Repeat(1,favorite.Length).ToArray();
            while(q.Count > 0)
            {
                int x=q.Dequeue();
                int y = favorite[x];
                maxDepth[y] = maxDepth[x] + 1;
                if (--deg[y] == 0)
                {
                    q.Enqueue(y);
                }

            }
            int maxRingSize = 0;
            int chainSize = 0;
            for(int i = 0;i<favorite.Length;++i) //遍历环
            {
                if (deg[i] == 0) continue;
                deg[i] = 0;
                int ringSize = 1;
                for(int x = favorite[i]; x != i; x = favorite[x])
                {
                    ++ringSize;
                }
                if(ringSize==2)
                {
                    chainSize += maxDepth[i] + maxDepth[favorite[i]];
                }else
                {

                    maxRingSize=Math.Max(maxRingSize, ringSize);
                }


            }



            return Math.Max(maxRingSize,chainSize);
        }
    }
}
