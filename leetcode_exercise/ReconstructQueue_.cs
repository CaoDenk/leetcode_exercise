using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class ReconstructQueue_
    {
        public int[][] ReconstructQueue(int[][] people)
        {

            var list= people.ToList();
            list.Sort((o1, o2) => { if (o1[0] != o2[0]) return o2[0] - o1[0]; else return o1[1] - o2[1]; } );
            for (int i = 1;  i < list.Count;++i)
            {
                int pos = list[i][1];
                if (pos==i)
                {
                    continue;
                }else
                {
                    var backup= list[i];
                    list.RemoveAt(i);
                    list.Insert(pos, backup);
                }
            }
            return list.ToArray();
        }

 


        static void Main(string[] args)
        {
            int[][] people = new int[][] { new int[]  { 7, 0 }, new int[] { 4, 4 }, new int[] { 7, 1 }, new int[] { 5, 0 }, new int[] { 6, 1 }, new int[] { 5, 2 } };
            //int[][] people = new int[][] { new int[]  { 7, 0 },  new int[] { 5, 0 } };
            ReconstructQueue_ r=new();
            var ret=r.ReconstructQueue(people);
            foreach(var i in ret)
            {
                Console.Write($"{{{string.Join(",",i)}}}");
            }
            Console.WriteLine();
        }
       


    }
}
