using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2251. 花期内花的数目
    /// 挖坑
    /// </summary>
    internal class FullBloomFlowers_
    {
        public int[] FullBloomFlowers(int[][] flowers, int[] people)
        {
          
            SortedDictionary<int,int> cnt=new();
            foreach(var i in flowers)
            {
                cnt[i[0]] = cnt.GetValueOrDefault(i[0]) + 1;
                cnt[i[1] + 1] = cnt.GetValueOrDefault(i[1] + 1) - 1;
            }
            int[] indices =Enumerable.Range(0, people.Length).ToArray();

            Array.Sort(indices, (i, j) => people[i].CompareTo(people[j]));
            int[] res=new int[people.Length];
            int curr = 0;
            foreach(int x in  indices)
            {
                while (cnt.Count > 0 && people[x] >= cnt.First().Key)
                {
                    curr += cnt.First().Value;
                    int k = cnt.First().Key;
                  
                    cnt.Remove(k);
                }
                res[x] = curr;
            }
       
            return res;
        }



        static void Main(string[] args)
        {
            FullBloomFlowers_ f = new();
            {
                int[][] flowers = [[1, 10], [3, 3]];
                int[] people = [3, 3, 2];
                var res = f.FullBloomFlowers(flowers, people);
                Console.WriteLine(string.Join(",", res));
            }

            {
                int[][] flowers = [[1, 6], [3, 7], [9, 12], [4, 13]];
                int[] people = [2, 3, 7, 11];
                var res = f.FullBloomFlowers(flowers, people);
                Console.WriteLine(string.Join(",", res));
            }
        }


    }
}
