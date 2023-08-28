using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class Insert_
    {

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> list = new List<int[]>();
            list.Add(newInterval);
            foreach (var interval in intervals)
            {
                list.Add(interval);
            }
            list.Sort((o1, o2) => { if (o1[0] != o2[0]) return o1[0] - o2[0]; else return o1[1] - o2[1]; });
            List<int[]> result = new() { list[0] };
            for (int i = 1; i < list.Count; ++i)
            {
                if (list[i][0] > result[^1][1])
                {
                    result.Add(list[i]);
                }
                else
                {
                    result[^1][1] = Math.Max(result[^1][1], list[i][1]);
                }

            }
            return result.ToArray();
        }

       
    }
}
