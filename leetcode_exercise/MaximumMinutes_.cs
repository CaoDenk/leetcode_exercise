using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2258. 逃离火灾
    /// 挖坑
    /// </summary>
    internal class MaximumMinutes_
    {
        public int MaximumMinutes(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[,] fireTime = FireBfs(grid);
            int[,] humanTime=HumanBfs(grid);

            if (humanTime[m-1,n-1]==int.MaxValue)
            {
                return -1;
            }
            if (fireTime[m-1,n-1]==int.MaxValue)
            {
                return 10_0000_0000;
            }
            int ans = fireTime[m - 1, n - 1] - humanTime[m - 1, n - 1];
            if(ans < 0)
            {
                return -1;
            }
            if (humanTime[m - 1, n - 2] != int.MaxValue && ans + humanTime[m - 1, n - 2] < fireTime[m - 1, n - 2])
                return ans;
            if (humanTime[m - 2, n - 1] != int.MaxValue && ans + humanTime[m - 2, n - 1] < fireTime[m - 2, n - 1])
                return ans;
            return ans-1;
        }




        int[,] FireBfs(int[][] grid)
        {
            Queue<(int, int)> q = new();
            
            int[,] time = new int[grid.Length, grid[0].Length];
            int[][] visited = new int[grid.Length][];
            for(int i=0;i < grid.Length;++i)
            {
                visited[i]=new int[grid[i].Length];
                grid[i].CopyTo(visited[i],0);
            }
            for(int i = 0;i<grid.Length;++i)
            {
                for(int j = 0; j < visited[0].Length;++j)
                {
                    if (visited[i][j] == 1)
                    {
                        q.Enqueue((i, j));
                        time[i, j] = 0;
                    }
                    else
                        time[i, j] = int.MaxValue;

                }
            }
            return Bfs(q,visited,time);
        }
        int[,] HumanBfs(int[][] grid)
        {
            Queue<(int, int)> q = new();
            q.Enqueue((0, 0));
            int[,] time = new int[grid.Length, grid[0].Length];

            int[][] visited = grid.ToArray();
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < visited[0].Length; ++j)
                {
                    time[i, j] = int.MaxValue;
                }
            }
            visited[0][0] = 1;
            time[0, 0] = 0;
            
            return Bfs(q, visited, time);
        }

        int[,] Bfs(Queue<(int, int)> q,int[][] visited, int[,] time)
        {
            while (q.Count > 0)
            {
    
                (int i, int j) = q.Dequeue();
                if (i > 0 && visited[i - 1][j] == 0)
                {
                    visited[i - 1][j] = 1; 
                    time[i - 1, j] = time[i, j] + 1;
                    q.Enqueue((i - 1, j));
                }

                if (j > 0 && visited[i][j - 1] == 0)
                {
                    visited[i][j - 1] = 1;
                    time[i, j - 1] = time[i, j] + 1;
                    q.Enqueue((i, j - 1));
                }

                if (i < visited.Length - 1 && visited[i + 1][j] == 0)
                {
                    visited[i + 1][j] = 1;
                    time[i + 1, j] = time[i, j] + 1;
                    q.Enqueue((i + 1, j));
                }

                if (j < visited[i].Length - 1 && visited[i][j + 1] == 0)
                {
                    visited[i][j + 1] = 1;
                    time[i, j + 1] = time[i, j] + 1;
                    q.Enqueue((i, j + 1));
                }
            }
            return time;

        }



        static void Main(string[] args)
        {
            MaximumMinutes_ m = new();
            //{
            //    Console.WriteLine(m.MaximumMinutes([[0, 2, 0, 0, 0, 0, 0], [0, 0, 0, 2, 2, 1, 0], [0, 2, 0, 0, 1, 2, 0], [0, 0, 2, 2, 2, 0, 2], [0, 0, 0, 0, 0, 0, 0]]));
            //}
            {
                int[][] grid = [[0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 0, 2, 0, 0, 0, 0, 0], [0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2], [0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 2, 0, 2], [0, 0, 2, 0, 0, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0], [2, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0], [0, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 0, 0, 2, 0], [2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 2, 2, 0, 2, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 0, 2, 0], [2, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 2, 0, 0, 0, 0, 2, 0, 2, 0, 2, 2], [0, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 2, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2], [0, 2, 2, 0, 2, 0, 2, 0, 2, 1, 0, 0, 2, 2, 2, 0, 2, 0, 0, 2, 0, 0], [0, 2, 2, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 2, 0, 2, 2, 0, 0, 0, 2], [0, 2, 2, 0, 2, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 2, 1, 2, 2, 0, 2, 1], [0, 2, 2, 0, 2, 2, 2, 0, 2, 0, 2, 2, 0, 0, 0, 0, 2, 2, 0, 0, 0, 2], [0, 2, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 2, 2, 0, 0, 2, 0, 0], [2, 2, 2, 0, 2, 2, 0, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 0], [0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0]];
                Console.WriteLine(m.MaximumMinutes(grid));
            }
        }
    }
}
