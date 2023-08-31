using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 901. 股票价格跨度
    /// 这是o(n^2)
    /// </summary>
    internal class StockSpanner
    {
        public StockSpanner()
        {

        }
        List<int> list = new List<int>();
        List<int> pos=new List<int>();
        public int Next(int price)
        {
            if (list.Count == 0)
            {
                list.Add(price);
                pos.Add(1);
            }
            else if(list.Count==1)
            {
                list.Add(price);
                if (price < list[0]) pos.Add(1);
                else pos.Add(2);
            }else
            {
                int j = list.Count - 1;
                while (j >= 0 && price >= list[j])
                {
                    j -= pos[j];
                }
                pos.Add(list.Count - j);
                list.Add(price);
            }
            return pos[^1];
        }

        static void Main(string[] args)
        {
            StockSpanner s = new();
            int[] arr = { 100,80,60, 70, 60, 75, 85 };
            foreach (int i in arr)
            {
               var res= s.Next(i);
                Console.WriteLine(res);
            }
        }
    }
}
