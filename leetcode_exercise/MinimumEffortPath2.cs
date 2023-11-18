namespace leetcode_exercise
{
    /// <summary>
    /// 1631. 最小体力消耗路径
    /// 使用dijistra
    /// </summary>
    internal class MinimumEffortPath2
    {

        record struct Edge(int x, int y, int d);

        public int MinimumEffortPath(int[][] heights)
        {
            int[,] dirs = new int[4, 2] { { -1, 0 },{ 1,0},{ 0,-1},{ 0,1} };
            int rows=heights.Length;
            int cols = heights[0].Length;
            int[,] dist=new int[rows,cols];
            for(int i=0; i<rows;i++)
                for (int j = 0; j < cols; j++)dist[i, j] = int.MaxValue;
            dist[0,0] = 0;
            bool[,] seen=new bool[rows, cols];
            PriorityQueue<Edge, int> p = new();
            p.Enqueue(new Edge(), 0);
            while (p.Count > 0)
            {
                Edge e=p.Dequeue();
                if (seen[e.x,e.y])continue;
                if (e.x == rows - 1 && e.y == cols - 1) break;
                seen[e.x,e.y] = true;
                for (int i = 0;i<4;++i)
                {
                    int nx = e.x+ dirs[i,0];
                    int ny = e.y + dirs[i,1];
                    int t;
                    if (nx >= 0 && nx < rows && ny >= 0 && ny < cols
                        && ( t= Math.Max(e.d, Math.Abs(heights[e.x][e.y] - heights[nx][ny]) ))< dist[nx,ny])
                    {
                        dist[nx, ny] = t;
                        p.Enqueue(new Edge(nx, ny, t), t);
                    }
                }
            }
            return dist[rows-1,cols-1];
        }


        static void Main(string[] args)
        {
            MinimumEffortPath2 m = new();
            //{
            //    int[][] heights = [[1, 2, 2], [3, 8, 2], [5, 3, 5]];
            //    Console.WriteLine(m.MinimumEffortPath(heights));
            //}
            {
                int[][] heights = [[1, 10, 6, 7, 9, 10, 4, 9]];
                Console.WriteLine(m.MinimumEffortPath(heights));
            }
        }
    }
}
