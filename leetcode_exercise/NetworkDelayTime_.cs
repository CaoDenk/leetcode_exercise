using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 迪杰斯特拉 最小路径
    /// </summary>
    internal class NetworkDelayTime_
    {
        const int Inf = int.MaxValue / 2;
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var heights=ToMap(times,n);
            int start = k - 1;
            int begin =start;
            int[] dist = new int[n];
            Array.Fill(dist, Inf);
            for(int i = 0; i < n;++i)
            {
                dist[i] = heights[start,i];
            }
            dist[start] = 0;
            HashSet<int> visited = new()
            {
                begin
            };
            int mark = 0;
            for (; ; )
            {
                if (visited.Count ==n)
                    break;
                int min = Inf;
                for (int j = 0; j < n; ++j)
                {
                    if (visited.Contains(j))
                        continue;
                    if (min > dist[j])
                    {
                        mark = j;
                        min = dist[j];
                    }
                }
                if(min==Inf)
                {
                    return -1;
                }else
                {
                    visited.Add(mark);
                }
                
                for (int j = 0; j < n; ++j)
                {
                    int len = heights[mark, j] + dist[mark]; 
                    if (dist[j] > len)
                    {
                        //Console.WriteLine($" {start}->{j}:{heights[start,j]},  {start}->{mark}:{heights[start, mark]} ,{mark}->{j}: {heights[mark, j]} , 路程和{heights[start, mark] + heights[mark,j]}");
                        dist[j] = len;
                    }
                }
                //Console.WriteLine(string.Join(",",dist));
            }
            return dist.Max();
        }
        //foreach (var h in heights)
        //{
        //    Console.Write($"{h},");
        //}
        //Console.WriteLine();

        int[,]  ToMap(int[][] times,int n) 
        {
            int[,] map=new int[n,n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    map[i, j] = Inf;
                }
            }
           foreach(var i in times)
           {
                map[i[0]-1,i[1]-1] = i[2];
           }
            return map;

        }

        static void Main(string[] args)
        {
            {
                //[2,1,1],[2,3,1],[3,4,1
                int[][] times = [[2, 1, 1], [2, 3, 1], [3, 4, 1]];
                NetworkDelayTime_ n = new();
                Console.WriteLine(n.NetworkDelayTime(times, 4, 2));
            }
            {
                //[2,1,1],[2,3,1],[3,4,1
                int[][] times = [[1, 2, 1]];
                NetworkDelayTime_ n = new();
                Console.WriteLine(n.NetworkDelayTime(times, 2, 2));
            }
            //{
            //    //[2,1,1],[2,3,1],[3,4,1
            //    int[][] times = [[2, 13, 18], [15, 10, 92], [6, 15, 80], [2, 14, 68], [13, 14, 65], [14, 3, 63], [10, 13, 59], [9, 7, 42], [1, 14, 70], [15, 14, 34], new int[] { 11, 1, 48 }, new int[] { 6, 7, 2 }, new int[] { 8, 13, 48 }, new int[] { 15, 6, 92 }, new int[] { 8, 7, 19 }, new int[] { 9, 14, 53 }, new int[] { 3, 5, 48 }, new int[] { 3, 10, 70 }, new int[] { 3, 8, 57 }, new int[] { 5, 15, 5 }, new int[] { 10, 14, 8 }, new int[] { 9, 3, 8 }, new int[] { 15, 8, 52 }, new int[] { 10, 5, 96 }, new int[] { 4, 7, 52 }, new int[] { 14, 13, 87 }, new int[] { 14, 10, 91 }, new int[] { 5, 2, 17 }, new int[] { 3, 15, 5 }, new int[] { 5, 1, 39 }, new int[] { 13, 3, 39 }, new int[] { 7, 13, 71 }, new int[] { 13, 2, 41 }, new int[] { 4, 13, 20 }, new int[] { 11, 12, 61 }, new int[] { 8, 4, 4 }, new int[] { 9, 8, 80 }, new int[] { 9, 2, 45 }, new int[] { 7, 9, 88 }, new int[] { 8, 15, 96 }, new int[] { 1, 12, 92 }, new int[] { 2, 7, 0 }, new int[] { 7, 2, 43 }, new int[] { 3, 9, 21 }, new int[] { 4, 2, 95 }, new int[] { 2, 12, 35 }, new int[] { 2, 5, 32 }, new int[] { 1, 9, 97 }, new int[] { 4, 9, 95 }, new int[] { 15, 4, 81 }, new int[] { 5, 13, 30 }, new int[] { 1, 6, 43 }, new int[] { 1, 7, 22 }, new int[] { 10, 3, 60 }, new int[] { 11, 4, 9 }, new int[] { 4, 11, 55 }, new int[] { 14, 5, 5 }, new int[] { 7, 4, 13 }, new int[] { 15, 13, 72 }, new int[] { 11, 3, 55 }, new int[] { 11, 8, 50 }, new int[] { 3, 7, 25 }, new int[] { 12, 11, 29 }, new int[] { 7, 10, 71 }, new int[] { 7, 5, 24 }, new int[] { 12, 14, 18 }, new int[] { 9, 13, 89 }, new int[] { 7, 3, 25 }, new int[] { 2, 9, 2 }, new int[] { 5, 11, 83 }, new int[] { 6, 4, 48 }, new int[] { 14, 1, 27 }, new int[] { 14, 11, 21 }, new int[] { 8, 14, 12 }, new int[] { 10, 1, 74 }, new int[] { 4, 1, 97 }, new int[] { 4, 10, 46 }, new int[] { 14, 8, 16 }, new int[] { 13, 5, 39 }, new int[] { 9, 4, 6 }, new int[] { 11, 7, 98 }, new int[] { 1, 13, 10 }, new int[] { 8, 11, 22 }, new int[] { 9, 11, 96 }, new int[] { 1, 8, 56 }, new int[] { 3, 14, 81 }, new int[] { 6, 11, 45 }, new int[] { 5, 4, 48 }, new int[] { 4, 6, 71 }, new int[] { 11, 15, 64 }, new int[] { 3, 12, 74 }, new int[] { 2, 6, 71 }, new int[] { 7, 8, 35 }, new int[] { 11, 2, 20 }, new int[] { 7, 12, 12 }, new int[] { 6, 14, 8 }, new int[] { 2, 15, 42 }, new int[] { 8, 2, 24 }, new int[] { 6, 12, 67 }, new int[] { 5, 8, 90 }, new int[] { 2, 10, 36 }, new int[] { 15, 7, 0 }, new int[] { 15, 1, 68 }, new int[] { 12, 4, 43 }, new int[] { 1, 5, 78 }, new int[] { 13, 9, 97 }, new int[] { 2, 4, 51 }, new int[] { 13, 15, 39 }, new int[] { 9, 12, 93 }, new int[] { 5, 3, 79 }, new int[] { 7, 1, 34 }, new int[] { 8, 12, 37 }, new int[] { 12, 15, 36 }, new int[] { 8, 5, 92 }, new int[] { 7, 11, 96 }, new int[] { 14, 9, 94 }, new int[] { 8, 1, 31 }, new int[] { 14, 2, 18 }, new int[] { 2, 8, 62 }, new int[] { 15, 3, 84 }, new int[] { 6, 1, 3 }, new int[] { 10, 4, 91 }, new int[] { 1, 3, 75 }, new int[] { 1, 4, 9 }, new int[] { 11, 10, 69 }, new int[] { 7, 15, 88 }, new int[] { 6, 9, 25 }, new int[] { 9, 6, 44 }, new int[] { 6, 8, 68 }, new int[] { 6, 2, 96 }, new int[] { 1, 15, 16 }, new int[] { 6, 3, 61 }, new int[] { 12, 9, 50 }, new int[] { 13, 11, 27 }, new int[] { 8, 6, 40 }, new int[] { 13, 12, 45 }, new int[] { 14, 7, 61 }, new int[] { 4, 15, 8 }, new int[] { 12, 2, 87 }, new int[] { 14, 4, 94 }, new int[] { 11, 6, 37 }, new int[] { 12, 8, 10 }, new int[] { 13, 6, 0 }, new int[] { 9, 15, 70 }, new int[] { 1, 10, 26 }, new int[] { 14, 6, 30 }, new int[] { 15, 2, 58 }, new int[] { 3, 1, 12 }, new int[] { 10, 7, 96 }, new int[] { 2, 3, 4 }, new int[] { 5, 14, 99 }, new int[] { 8, 3, 85 }, new int[] { 12, 10, 38 }, new int[] { 14, 15, 34 }, new int[] { 4, 8, 31 }, new int[] { 10, 8, 13 }, new int[] { 4, 12, 57 }, new int[] { 12, 7, 4 }, new int[] { 3, 2, 65 }, new int[] { 15, 5, 85 }, new int[] { 12, 5, 42 }, new int[] { 3, 6, 53 }, new int[] { 4, 3, 3 }, new int[] { 10, 15, 29 }, new int[] { 9, 5, 47 }, new int[] { 4, 5, 43 }, new int[] { 9, 1, 98 }, new int[] { 13, 4, 72 }, new int[] { 3, 4, 88 }, new int[] { 5, 9, 21 }, new int[] { 10, 12, 41 }, new int[] { 13, 10, 3 }, new int[] { 3, 11, 77 }, new int[] { 13, 7, 21 }, new int[] { 5, 7, 88 }, new int[] { 6, 5, 22 }, new int[] { 12, 6, 72 }, new int[] { 15, 12, 37 }, new int[] { 9, 10, 94 }, new int[] { 11, 14, 0 }, new int[] { 1, 11, 51 }, new int[] { 5, 10, 44 }, new int[] { 14, 12, 34 }, new int[] { 15, 9, 85 }, new int[] { 11, 13, 74 }, new int[] { 6, 10, 54 }, new int[] { 8, 10, 9 }, new int[] { 13, 8, 68 }, new int[] { 2, 11, 13 }, new int[] { 2, 1, 91 }, new int[] { 12, 3, 31 }, [12, 13, 99], new int[] { 1, 2, 84 }, new int[] { 12, 1, 89 }, new int[] { 4, 14, 9 }, new int[] { 5, 12, 34 }, new int[] { 7, 14, 53 }, new int[] { 7, 6, 87 }, new int[] { 11, 9, 20 }, new int[] { 3, 13, 6 }, new int[] { 6, 13, 40 }, new int[] { 13, 1, 94 }, new int[] { 10, 11, 20 }, new int[] { 10, 6, 67 }, new int[] { 5, 6, 27 }, new int[] { 8, 9, 97 }, [11, 5, 66], new int[] { 10, 2, 73 }, new int[] { 10, 9, 17 }, [15, 11, 48]];
            //    NetworkDelayTime_ n = new();
            //    Console.WriteLine(n.NetworkDelayTime(times, 15, 2));
            //}
        }
    }
}
