using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 最大舒适度
    /// </summary>
    internal class Seat
    {
     
        static int MaxComfort(int n, int m, List<ValueTuple<int, int>> comfort)
        {
            switch((n,m))
            {
                case (1,_):
                    return comfort[0].Item2;
                case (2,2): return comfort[0].Item1 + comfort[1].Item1;
                case (2, _):
                    return Math.Max(comfort[0].Item2 + comfort[1].Item2, comfort[0].Item1 + comfort[1].Item1);//要不都有人，要不都没人
            }
            int[] arr = [1];  
            PriorityQueue<(int,int), int> unsitted = new(Comparer<int>.Create((o1,o2)=>o2-o1));
            int sum = 0;
            foreach (var i in comfort)
            {
                if(i.Item1>=i.Item2)
                {
                    sum += i.Item1;
                }else
                {
                    int diff = i.Item2 - i.Item1;
                    unsitted.Enqueue(i, diff) ;
                }
            }
            int noNeighnour = MaxPeopleWithoutNeighbour(m, n);
                    
            if (noNeighnour>unsitted.Count)
            {
                
                while (unsitted.Count > 0)
                {
                    sum += unsitted.Dequeue().Item2;
                }
            }
            else
            {
                for(int i=0;i<noNeighnour;i++)
                {
                    sum += unsitted.Dequeue().Item2;
                }
                while (unsitted.Count > 0)
                {
                    sum += unsitted.Dequeue().Item1;
                }
            }
            return sum;
        }

        static int MaxPeopleWithoutNeighbour(int m, int n)
        {
            int emptyseat = m - n;
            if (n - emptyseat == 1)
                return emptyseat + 1;
            return emptyseat;
        }

        static void Main(string[] args)
        {
            //int n, m;
            //Console.WriteLine("请输入员工人数n和工位数m：");
            //string[] input = Console.ReadLine().Split(' ');
            //n = int.Parse(input[0]);
            //m = int.Parse(input[1]);

            //List<Tuple<int, int>> comfort = new List<Tuple<int, int>>();
            //Console.WriteLine("请依次输入每个员工在工位旁边有人和没人时的舒适度（以空格分隔）：");
            //for (int i = 0; i < n; i++)
            //{
            //    input = Console.ReadLine().Split(' ');
            //    int ai = int.Parse(input[0]);
            //    int bi = int.Parse(input[1]);
            //    comfort.Add(new Tuple<int, int>(ai, bi));
            //}

            //int result = MaxComfort(n, m, comfort);
            //Console.WriteLine("最大总舒适度：" + result);

            //Console.ReadLine();
            {
                List<(int, int)> list = [(1, 100), (100, 1), (100, 1), (100, 1)];
                int res = MaxComfort(4, 5, list);
                Console.WriteLine(res);
            }
            {
                List<(int, int)> list = [(1, 10), (1, 10)];
                int res = MaxComfort(2, 2, list);
                Console.WriteLine(res);
            }
            {
                List<(int, int)> list = [(100, 50), (1, 1000)];
                int res = MaxComfort(2, 3, list);
                Console.WriteLine(res);
            }
            {
                List<(int, int)> list = [(3, 5), (2, 6),(4,3),(1,2)];
                int res = MaxComfort(4, 6, list);
                Console.WriteLine(res);
            }
            {
                List<(int, int)> list = [(2, 4), (2, 4), (2, 4)];
                int res = MaxComfort(3, 5, list);
                Console.WriteLine(res);
            }
        }

    }
}
