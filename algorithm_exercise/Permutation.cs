using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class Permutation
    {

        public static List<List<int>> Permute(int[] arr)
        {
            List<List<int>> list = new();
            PermuteRecur(new bool[arr.Length], arr, 0, new List<int>(), list);
            return list;
        }

        static void  PermuteRecur(bool[] vis,int[] arr,int idx,List<int> l,List<List<int>> ans)
        {
            if(idx==arr.Length)
            {
                ans.Add(l.ToList());
                return;
            }
            for(int i=0; i<arr.Length;++i)
            {
                if (vis[i])
                {
                    continue;
                }
                l.Add(arr[i]);
                vis[i] = true;
                PermuteRecur(vis,arr,idx+1,l,ans);
                l.RemoveAt(idx);
                vis[i] = false;
            }
        }
        static void Main(string[] args)
        {
          var res=  Permute(new int[] { 1, 2, 3, 4, });
            foreach(var i in res)
            {
                Console.WriteLine(string.Join(",",i));
            }
        }

    }
}
