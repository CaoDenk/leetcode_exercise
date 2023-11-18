using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1921. 消灭怪物的最大数量
    /// </summary>
    internal class EliminateMaximum_
    {
        public int EliminateMaximum(int[] dist, int[] speed)
        {

            int[] arr=new int[dist.Length];
            
            for(int i=0; i<dist.Length;++i)
            {
                arr[i]= Math.DivRem(dist[i], speed[i], out int rem);
                if (rem != 0)++arr[i];
            }

            Array.Sort(arr);
          
            for (int i = 1; i < arr.Length;++i)
            {
                if (arr[i] < i+1 &&arr[i] == arr[i-1]) //怪兽同时来的个数大于1，
                    return i;
            }

            return arr.Length;
        }

        static void Main(string[] args)
        {
            EliminateMaximum_ e = new();
            Console.WriteLine(e.EliminateMaximum([1,3,4],[1,1,1]));
            Console.WriteLine(e.EliminateMaximum([1,1,2,3],[1,1,1,1]));
            Console.WriteLine(e.EliminateMaximum([3, 2, 4], [5,3,2]));
            Console.WriteLine(e.EliminateMaximum([4, 2, 3], [2,1,1]));
            Console.WriteLine(e.EliminateMaximum([3, 5, 7, 4, 5], [2, 3, 6, 3, 2]));

        }


    }
}
