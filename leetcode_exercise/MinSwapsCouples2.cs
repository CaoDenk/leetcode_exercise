using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 765. 情侣牵手
    /// </summary>
    internal class MinSwapsCouples2
    {
        public int MinSwapsCouples(int[] row)
        {
            int count = 0;
            int[] index= Enumerable.Range(0, row.Length).ToArray();
            Array.Sort(index, (o1, o2) => row[o1].CompareTo(row[o2]));
            for(int i=0;i<row.Length;i+=2)
            {
                int find = row[i] ^ 1;   
                int idx = index[find];
                int y = i + 1;
                if(idx!=y)
                {
                    index[row[y]] = idx;
                    ++count;
                    row[idx] = row[y];
                }
            }

            return count ;
        }
        static void Main(string[] args)
        {
            MinSwapsCouples2 m = new();
            {
                int[] row = [0, 2, 1, 3];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [3, 2, 0, 1];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [5, 4, 2, 6, 3, 1, 0, 7];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [1, 4, 0, 5, 8, 7, 6, 3, 2, 9];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [10, 7, 4, 2, 3, 0, 9, 11, 1, 5, 6, 8];//=4
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [4, 6, 1, 3, 5, 7, 12, 13, 15, 11, 0, 10, 2, 8, 9, 14];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
        }
    }
}
