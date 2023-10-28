using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 多核处理器解决依赖关系的任务
    /// </summary>
    internal class TaskHandle
    {

        class GraphNode
        {
            public List<GraphNode> nextNodes = new List<GraphNode>();
            public int inNumber;//入度
            public int time;
            public int num;
            public GraphNode(int time,int num)
            {
                this.time = time;
                this.num = num;
            }
        }

        List<GraphNode> Make(int[] times, int[] dep)
        {
            GraphNode[] graph = new GraphNode[times.Length];
            for (int i = 0; i < times.Length; i++)
            {
                graph[i] = new GraphNode(times[i],i+1);
            }
            for (int i = 0; i < dep.Length; i++)
            {
                int pre = dep[i];
                if (pre == 0)
                    continue;
                graph[pre-1].nextNodes.Add(graph[i]);
                ++graph[i].inNumber;

            }
            return graph.ToList();
        }

        GraphNode? FindZeroInNumber(List<GraphNode> graph)
        {
            foreach (GraphNode node in graph)
            {
                if (node.inNumber == 0)
                    return node;
            }
            if (graph.Count > 0)
                throw new Exception();
            return null;
        }
        
        int GetMinTime(int[] times, int[] dep,int  core)
        {
            List<GraphNode> graph = Make(times, dep);
            PriorityQueue<int, int> p = new(Comparer<int>.Create((x,y)=>x.CompareTo(y)));
            for(int i=0;i<core;i++)
            {
                p.Enqueue(0, 0);
            }
            while( FindZeroInNumber(graph) is { } n)
            {
                foreach(var item in n.nextNodes)
                {
                    --item.inNumber;
                }
                graph.Remove(n);
                int t=p.Dequeue();
                t += n.time;
                p.Enqueue(t, t);
            }

            while(p.Count > 1)
            {
                p.Dequeue();
            }

            return p.Dequeue();
        }
        static void Main(string[] args)
        {
            TaskHandle t = new();
            {
                int res = t.GetMinTime([2, 5, 4, 6], [0, 1, 2, 0], 2);
                Console.WriteLine(res);
            }
            {
                int res = t.GetMinTime([2, 6,4,5,4], [0,0,0,0,0], 3);
                Console.WriteLine(res);
            }
        }
    }
}
