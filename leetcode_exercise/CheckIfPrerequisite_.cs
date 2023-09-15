using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1462. 课程表 IV
    /// </summary>
    internal class CheckIfPrerequisite_
    {
        public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
        {
            List<int>[] listArr=new List<int>[numCourses];
            int[] indegree=new int[numCourses];
            Queue<int> queue=new Queue<int>();
            bool[][] isPre=new bool[numCourses][];//[][]前面是后面的先决条件
            for(int i=0;i<numCourses;++i)
            {
                listArr[i]=new List<int>();
                isPre[i]=new bool[numCourses];
            }
            foreach(var item in prerequisites)
            {
                ++indegree[item[1]];
                listArr[item[0]].Add(item[1]);
            }
            
            for(int i= 0;i<numCourses;++i)
            {
                if (indegree[i]==0)
                {
                    queue.Enqueue(i);
                }
            }
            while(queue.Count > 0)
            {
                int pre= queue.Dequeue();
                foreach(var cur in listArr[pre])
                {
                    isPre[pre][cur]=true;
                    for(int i=0;i< numCourses;++i)
                    {
                        isPre[i][cur] = isPre[i][cur] || isPre[i][pre];
                    }
                    --indegree[cur];
                    if (indegree[cur]==0)
                    {
                        queue.Enqueue(cur);
                    }
                }
               
            }
            List<bool> res=new List<bool>();
            foreach(var item in queries)
            {                
                res.Add(isPre[item[0]][item[1]]);
            }

            return res;
        }

    }
}
