using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 207. 课程表
    /// 挖坑、
    /// 检测能否成为环
    /// </summary>
    internal class CanFinish_
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var graphsList = Make(numCourses, prerequisites);

            while(graphsList.Count > 0)
            {   
                bool flag=false;
                for (int i = graphsList.Count - 1; i >= 0; --i)
                {
                    if (graphsList[i].inNumber == 0)
                    {
                        foreach (var graph in graphsList[i].nextNodes)
                        {
                            --graph.inNumber;
                        }
                        graphsList.RemoveAt(i);
                        flag = true;
                    }

                }
                if(!flag)
                    return false;
            }
            return true;
        }

        class GraphNode
        {
            public List<GraphNode> nextNodes=new List<GraphNode>();
            public int inNumber;//入度
            public int value;
            public GraphNode(int value)
            {
                this.value = value;
            }

        }

        List<GraphNode> Make(int numCourses, int[][] prerequisites)
        {

            GraphNode[] graph=new GraphNode[numCourses];
            for(int i = 0; i < graph.Length; i++)
            {
                graph[i] = new GraphNode(i); 
            }
            for(int i=0;i<prerequisites.Length; i++)
            {
                int course = prerequisites[i][0];
                int preLearn = prerequisites[i][1];
                graph[preLearn].nextNodes.Add(graph[course]);
                ++graph[course].inNumber;

            }
            return graph.ToList();
        }


        static void Main(string[] args)
        {
            CanFinish_ canFinish_ = new();
            {
                int[][] prerequisites = new int[1][];
                prerequisites[0] = new int[] { 1, 0 };
                Console.WriteLine(canFinish_.CanFinish(2, prerequisites));
            }
            {
                int[][] prerequisites = new int[2][];
                prerequisites[0] = new int[] { 1, 0 };
                prerequisites[1] = new int[] { 0, 1 };
                Console.WriteLine(canFinish_.CanFinish(2, prerequisites));
            }
            {
                int[][] prerequisites = new int[2][];
                prerequisites[0] = new int[] { 2, 1 };
                prerequisites[1] = new int[] { 1, 0 };
                Console.WriteLine(canFinish_.CanFinish(3, prerequisites));
            }
            {
                int[][] prerequisites = new int[4][];
                prerequisites[0] = new int[] { 1, 4 };
                prerequisites[1] = new int[] { 2, 4 };
                prerequisites[2] = new int[] { 3, 1 };
                prerequisites[3] = new int[] { 3, 2 };
                Console.WriteLine(canFinish_.CanFinish(5, prerequisites));
            }
            {
                int[][] prerequisites = new int[5][];
                prerequisites[0] = new int[] { 1, 4 };
                prerequisites[1] = new int[] { 2, 4 };
                prerequisites[2] = new int[] { 3, 1 };
                prerequisites[3] = new int[] { 3, 2 };
                prerequisites[4] = new int[] { 5, 5 };
                Console.WriteLine(canFinish_.CanFinish(6, prerequisites));
            }
            {//1,0],[1,2],[0,1
                int[][] prerequisites = new int[3][];
                prerequisites[0] = new int[] { 1, 0 };
                prerequisites[1] = new int[] { 1, 2 };
                prerequisites[2] = new int[] { 0, 1 };

                Console.WriteLine(canFinish_.CanFinish(3, prerequisites));
            }
            {
                //0,1],[2,3],[1,2],[3,0
                //0,1],[2,3],[1,2],[3,0]
                int[][] prerequisites = new int[4][];
                prerequisites[0] = new int[] { 0, 1 };
                prerequisites[1] = new int[] { 2, 3 };
                prerequisites[2] = new int[] { 1, 2 };
                prerequisites[3] = new int[] { 3, 0 };

                Console.WriteLine(canFinish_.CanFinish(4, prerequisites));
            }
            {//1,0],[1,2],[0,1
                int[][] prerequisites = new int[3][];
                prerequisites[0] = new int[] { 1, 0 };
                prerequisites[1] = new int[] { 0, 2 };
                prerequisites[2] = new int[] { 2, 1 };

                Console.WriteLine(canFinish_.CanFinish(3, prerequisites));
            }
        }


        
    }
}
