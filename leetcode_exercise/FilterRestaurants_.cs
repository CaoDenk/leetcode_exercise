using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1333. 餐厅过滤器
    /// </summary>
    internal class FilterRestaurants_
    {
        public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
        {
            PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>(Comparer<int>.Create((o1,o2)=>o2-o1));
            List<int> list = new List<int>();
            foreach(var arr in restaurants)
            {
                if(veganFriendly==1&& arr[2] != 1)
                {
                   continue;
                }
                if (arr[3] > maxPrice)
                    continue;
                if (arr[4] > maxDistance)
                    continue;
                priorityQueue.Enqueue(arr[0], arr[1]);

            }
            while(priorityQueue.Count > 0)
            {
                list.Add(priorityQueue.Dequeue());
            }

            return list;
        }
        static void Main(string[] args)
        {
            FilterRestaurants_ f = new();
            {
                int[][] restaurants = new int[5][];
                restaurants[0] = new int[5] { 1, 4, 1, 40, 10 };
                restaurants[1] = new int[5] { 2, 8, 0, 50, 5 };
                restaurants[2] = new int[5] { 3, 8, 1, 30, 4 };
                restaurants[3] = new int[5] { 4, 10, 0, 10, 3 };
                restaurants[4] = new int[5] { 5, 1, 1, 15, 1 };
                var res = f.FilterRestaurants(restaurants, 1, 50, 10);
                Console.WriteLine(string.Join(",",res));

            }
            {
                int[][] restaurants = new int[5][];
                restaurants[0] = new int[5] { 1, 4, 1, 40, 10 };
                restaurants[1] = new int[5] { 2, 8, 0, 50, 5 };
                restaurants[2] = new int[5] { 3, 8, 1, 30, 4 };
                restaurants[3] = new int[5] { 4, 10, 0, 10, 3 };
                restaurants[4] = new int[5] { 5, 1, 1, 15, 1 };

                var res = f.FilterRestaurants(restaurants, 0, 50, 10);
                Console.WriteLine(string.Join(",", res));

            }
        }
    }
}
