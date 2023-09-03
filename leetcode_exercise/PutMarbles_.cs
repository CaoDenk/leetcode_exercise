using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2551. 将珠子放入背包中
    ///困难
    /// </summary>
    internal class PutMarbles_
    {
        public long PutMarbles(int[] weights, int k)
        {
            if(weights.Length==k)
                return 0;

            List<int> list = new List<int>(weights.Length);
            for(int i=0;i<weights.Length-1;++i)
            {
                list.Add(weights[i] + weights[i+1]);
            }
            list.Sort();
            long res = 0;
            Console.WriteLine(string.Join(",",list));
            for (int i=0,j=list.Count-1;i<k-1;++i,--j)
            {
                //Console.WriteLine($"list[j]={list[j]} list[i]{list[i]}");
                res += list[j] - list[i];
                //Console.WriteLine(res);
            }

            return res;
        }
        static void Main(string[] args)
        {
            PutMarbles_ p = new();
            Console.WriteLine(p.PutMarbles(new int[] { 1, 4, 2, 5, 2 },3));
        }
    }
}
