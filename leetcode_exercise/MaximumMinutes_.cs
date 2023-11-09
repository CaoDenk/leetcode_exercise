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
            Stack<(int x, int y)> stack = new Stack<(int x, int y)>();
            bool[,] map=new bool[grid.Length,grid[0].Length];
            stack.Push((0, 0));
            map[0, 0] = true;
            int time=0;
            int max=0;
            int x = 0, y = 0;
            while(true)
            {


                (int nx, int ny) = GetNextStep(x, y, grid, map);
                if (nx == grid.Length - 1 && y == grid[0].Length - 1)
                {
                    while(true)
                    {
                        State _state= Spread(grid, nx, ny);
                        if (_state == State.Never) return 10_0000_0000;
                        if (_state == State.Safe)
                        {
                            time++;
                            max=Math.Max(max, time);
                        }
                        else return max;
                    }
                }

                if (nx<0)
                {
                    if (stack.Count > 0)
                    {
                        map[x, y] = false;
                        (x, y) = stack.Pop();
                        time--;
                    } else
                    {
                        return max;
                    }
                       
                }else
                {
                    State _state = Spread(grid, nx, ny);
                    if (_state == State.Never) return 10_0000_0000;
                    if(_state== State.Safe)
                    {
                        map[nx, ny] = true;
                        stack.Push((nx, ny));
                        time++;
                        max=Math.Max(max, time);
                        x = nx;
                        y = ny;
                    }else
                    {
                        if (stack.Count > 0)
                        {
                            map[x, y] = false;
                            (x, y) = stack.Pop();
                            time--;
                        }
                        else
                        {
                            return max;
                        }
                    }
            
                }
            }

        }

        enum State
        {
            Never,
            Safe,
            Fire
        }
        /// <summary>
        /// 返回true说明人被烧到了
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        State Spread(int[][] grid,int x,int y)
        {
            List<(int pos1, int pos2)> pos = new();
            for(int i = 0;i<grid.Length;++i)
            {
                for(int j = 0; j < grid[i].Length;++j)
                {
                    if (grid[i][j] == 0)
                    {
                        if (i > 0 && grid[i - 1][j] == 0)
                            pos.Add((i - 1, j));
                        if (j > 0 && grid[i][j - 1] == 0)
                            pos.Add((i, j - 1));
                        if (i < grid.Length - 1 && grid[i + 1][j] == 0)
                            pos.Add((i + 1, j));
                        if (j < grid[i].Length - 1 && grid[i][j + 1] == 0)
                            pos.Add((i, j + 1));
                    }
             
                }
            }
            if(pos.Count == 0) 
            {
                return State.Never;
            }
            foreach((int pos1, int pos2) in pos)
            {
                grid[pos1][pos2] = 1;
            }
             if(grid[x][y]==1)return State.Fire;
             else return State.Safe;
        }

        (int x, int y) GetNextStep(int x, int y, int[][] grid, bool[,] map)
        {
            if (x <grid.Length-1 && grid[x + 1][y] == 0&& !map[x+1,y])
            {
                return (x+1,y);
            }
            if (y < grid.Length - 1 && grid[x ][y+1] == 0 && !map[x , y+1])
            {
                return (x, y+1);
            }
            if (x < grid.Length - 1 && grid[x + 1][y] == 0 && !map[x + 1, y])
            {
                return (x + 1, y);
            }
            if (y < grid.Length - 1 && grid[x][y + 1] == 0 && !map[x, y + 1])
            {
                return (x, y + 1);
            }
            return (-1, -1);
        }


        static void Main(string[] args)
        {
            MaximumMinutes_ m = new();
            {
                Console.WriteLine(m.MaximumMinutes([[0, 2, 0, 0, 0, 0, 0], [0, 0, 0, 2, 2, 1, 0], [0, 2, 0, 0, 1, 2, 0], [0, 0, 2, 2, 2, 0, 2], [0, 0, 0, 0, 0, 0, 0]]));
            }
        }
    }
}
