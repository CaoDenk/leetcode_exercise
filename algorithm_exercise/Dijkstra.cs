using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    //class VNode
    //{
    //    public string name;
    //}
    //class Edge
    //{
    //   public VNode v1, v2;
    //   public int weight;

    //}
    public class Dijkstra
    {
        int start;
        int dest;
        int[,] map;
       public Dijkstra(int start,int dest, int[,] map)
        {
            this.start = start;
            this.dest = dest;
            this.map = map;
        }
        
        int Search()
        {
            bool[] visited=new bool[map.GetLength(0)];

            visited[start] = true;

            int begin = start;
            for (int i=0;i<map.GetLength(0);++i)
            {
                int mark = 0;
                int min = int.MaxValue;
                for (int j = 0; j < map.GetLength(0); ++j)
                {
                    if (visited[j])
                        continue;
                    if (min > map[begin, j])
                    {
                        mark = j;
                        min = map[begin, j];
                    }
                }
                visited[mark] = true;
                for (int j = 0; j < map.GetLength(0); ++j)
                {
                    if (map[begin, j] > map[begin, mark] + map[mark, i])
                    {
                        map[begin, j] = map[begin, mark] + map[mark, i];
                    }
                }
                begin = mark;
            }
           
            return map[start,dest];
        }

        static void Main(string[] args)
        {


        }

    }
}
