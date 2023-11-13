using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 56. 合并区间
    /// 挖坑
    /// </summary>
    internal class Merge_
    {
        public int[][] Merge(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();

            Array.Sort(intervals, (o1, o2) => { if (o1[0] != o2[0]) return o1[0] - o2[0]; else return o1[1] - o2[1]; });
            result.Add(intervals[0]);
            foreach (var i in intervals)
            {
                Console.WriteLine($"{i[0]},{i[1]}");
            }
            for (int i=1;i<intervals.Length;++i)
            {
                if (intervals[i][0] > result[^1][1])
                {
                    result.Add(intervals[i]);
                }else
                {
                    result[^1][1] = Math.Max(result[^1][1], intervals[i][1]);
                }

            }
            return result.ToArray();
        }


        static void Main(string[] args)
        {
            //[1,3],[2,6],[8,10],[15,18]
            Merge_ m = new();
            #region
            //{
            //    int[][] intervals = new int[4][];
            //    intervals[0] = new int[] { 1, 3 };
            //    intervals[1] = new int[] { 2, 6 };
            //    intervals[2] = new int[] { 8, 10 };
            //    intervals[3] = new int[] { 15, 18 };
            //    var res = m.Merge(intervals);
            //    foreach (var i in res)
            //    {
            //        Console.WriteLine($"{i[0]},{i[1]}");
            //    }
            //}
            //{
            //    int[][] intervals = new int[2][];
            //    intervals[0] = new int[] { 1, 4 };
            //    intervals[1] = new int[] { 4, 5 };

            //    var res = m.Merge(intervals);
            //    foreach (var i in res)
            //    {
            //        Console.WriteLine($"{i[0]},{i[1]}");
            //    }
            //}


            //{
            //    //[2,3],[5,5],[2,2],[3,4],[3,4]
            //    int[][] intervals = new int[5][];
            //    intervals[0] = new int[] { 2, 3 };
            //    intervals[1] = new int[] { 5, 5 };
            //    intervals[2] = new int[] { 2, 2 };
            //    intervals[3] = new int[] { 3, 4 };
            //    intervals[4] = new int[] { 3, 4 };
            //    var res = m.Merge(intervals);
            //    foreach (var i in res)
            //    {
            //        Console.WriteLine($"{i[0]},{i[1]}");
            //    }
            //}
            //{
            //    //5,5],[1,3],[3,5],[4,6],[1,1],[3,3],[5,6],[3,3],[2,4],[0,0]
            //    int[][] intervals = new int[10][];
            //    intervals[0] = new int[] { 5, 5 };
            //    intervals[1] = new int[] { 1, 3 };
            //    intervals[2] = new int[] { 3, 5 };
            //    intervals[3] = new int[] { 4, 6 };
            //    intervals[4] = new int[] { 1, 1 };
            //    intervals[5] = new int[] { 3, 3 };
            //    intervals[6] = new int[] { 5, 6 };
            //    intervals[7] = new int[] { 3, 3 };
            //    intervals[8] = new int[] { 2, 4 };
            //    intervals[9] = new int[] { 0, 0 };
            //    var res = m.Merge(intervals);
            //    foreach (var i in res)
            //    {
            //        Console.WriteLine($"{i[0]},{i[1]}");
            //    }
            //}
            #endregion

            {
                //[5,7],[5,5],[1,1],[0,0],[3,3],[4,5],[1,1],[3,4]
                int[][] intervals =
                [
                    [5, 7],
                    [5, 5 ],
                    [1, 1 ],
                    [0, 0 ],
                    [3, 3 ],
                    [4, 5 ],
                    [1, 1 ],
                    [3, 4 ],
                ];
                //intervals[8] = new int[] { 2, 4 };
                //intervals[9] = new int[] { 0, 0 };
                var res = m.Merge(intervals);
                foreach (var i in res)
                {
                   Console.WriteLine($"{i[0]},{i[1]}");
                }
            }
        }
    }
}
