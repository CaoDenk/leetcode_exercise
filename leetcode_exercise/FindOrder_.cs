using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 210. 课程表 II
    /// </summary>
    internal class FindOrder_
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {

            var graphsList = Make(numCourses, prerequisites);
            List<int> result = new List<int>();
            while (graphsList.Count > 0)
            {
                bool flag = false;
                for (int i = graphsList.Count - 1; i >= 0; --i)
                {
                    if (graphsList[i].inNumber == 0)
                    {
                        foreach (var graph in graphsList[i].nextNodes)
                        {
                            --graph.inNumber;
                        }
                        result.Add(graphsList[i].value);
                        graphsList.RemoveAt(i);
                       
                        flag = true;
                    }

                }
                if (!flag)
                    return Array.Empty<int>();
            }
            return result.ToArray();
        }
        class GraphNode
        {
            public List<GraphNode> nextNodes = new List<GraphNode>();
            public int inNumber;//入度
            public int value;
            public GraphNode(int value)
            {
                this.value = value;
            }

        }

        List<GraphNode> Make(int numCourses, int[][] prerequisites)
        {

            GraphNode[] graph = new GraphNode[numCourses];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new GraphNode(i);
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                int course = prerequisites[i][0];
                int preLearn = prerequisites[i][1];
                graph[preLearn].nextNodes.Add(graph[course]);
                ++graph[course].inNumber;

            }
            return graph.ToList();
        }

    }
}
