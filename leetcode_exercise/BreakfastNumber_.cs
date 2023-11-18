using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// LCP 18. 早餐组合
    /// 超时。。。。。
    /// </summary>
    internal class BreakfastNumber_
    {
        public int BreakfastNumber(int[] staple, int[] drinks, int x)
        {
            if (staple.Length > drinks.Length)
            {
                (staple,drinks)=(drinks,staple);  //drink更长
            }
            Array.Sort(drinks);
            long count = 0;
            Dictionary<int,int> map = new Dictionary<int,int>();
            foreach(var i in staple)
            {
                if (i >= x)
                    continue;
               if(map.ContainsKey(i))
                {
                    count += map[i];
                }else
                {
                    int target = x - i;
                    if (target >= drinks[^1])
                    {
                        count += drinks.Length;
                        map[i] = drinks.Length;
                        continue;
                    }
                    if (target < drinks[0])
                        continue;

                    int size=  BinSearch(drinks, target);
                    Console.WriteLine(size);
                    count += size;
                    map[i] = size;
                }
            }

            return (int)(count % 1000000007);
        }
        /// <summary>
        /// 去找到最后一个小于等于target的
        /// </summary>
        /// <param name="drinks"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        int BinSearch(int[] drinks,int target) 
        {
            return BinSearch(drinks, target, 0, drinks.Length);

        }
        int BinSearch(int[] drinks,int target, int min, int max)
        {

            int mid=(min+max)/2;

            if (drinks[mid] <= target && drinks[mid+1]>target)
            {
                return mid+1;
            }
            if (target < drinks[mid])
            {
                return BinSearch(drinks,target,min,mid);
            }else
                return BinSearch(drinks,target,mid,max);

        }
        static void Main(string[] args)
        {
            BreakfastNumber_ b = new();
            //{
            //    int[] staple = { 10, 20, 5 };
            //    int[] drinks = { 5, 5, 2 };
            //    int count= b.BreakfastNumber(staple, drinks,15);
            //    Console.WriteLine(count);
            //}
            {
                int[] staple = [2,1,1];
                int[] drinks = [8, 9, 5, 1];
                int count = b.BreakfastNumber(staple, drinks, 9);
                Console.WriteLine(count);
            }
        }

    }
}
