using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2300. 咒语和药水的成功对数
    /// 挖坑，二分法错误
    /// </summary>
    internal class SuccessfulPairs_
    {
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Dictionary<int, int> dict = new();
            int[] ans=new int[spells.Length];
            Array.Sort(potions);
            for (int i = 0; i < spells.Length; i++)
            {
                if (dict.TryGetValue(spells[i], out int result))
                {
                    ans[i]= result;
                    continue;
                }
             
                double cmp = (double)success / spells[i];
                int count = BinSearch(potions, cmp);
                ans[i] = count;
                dict[spells[i]] = count;
            }
            return ans;
        }
        int BinSearch(int[] potions, double target) 
        {
            if (target <= potions[0]) return potions.Length;
            if (target > potions[^1]) return 0;

            int left = 0;
            int right=potions.Length-1;
            int ans;
            while(true)
            {
                if (potions[left] < target && potions[left + 1] >= target)
                {
                    ans=potions.Length - 1 - left;
                    break;
                }
                int mid = (left + right) / 2;
                if (potions[mid] < target)left = mid;
                else right = mid;
            }
            return ans;
        
        }
        //int BinarySearch(int[] arr, int left, int right, double target)
        //{



        //    if ( arr[left] < target && arr[left + 1] >= target)
        //        return arr.Length-1- left;
        //    int mid=(left+right)/2;
        //    if (arr[mid] < target)
        //    {
        //        return BinarySearch(arr, mid, right, target);
        //    }
        //    else
        //        return BinarySearch(arr, left, mid, target);

        //}


        static void Main(string[] args)
        {
            SuccessfulPairs_ s = new();
            //{
            //    int[] spells = [5, 1, 3];
            //    int[] potions = [1, 2, 3, 4, 5];
            //    int success = 7;
            //    var res = s.SuccessfulPairs(spells, potions, success);
            //    Console.WriteLine(string.Join(",", res));
            //    //Console.WriteLine();
            //}
            //{
            //    int[] spells = [3, 1, 2];
            //    int[] potions = [8,5,8];
            //    int success = 16;
            //    var res = s.SuccessfulPairs(spells, potions, success);
            //    Console.WriteLine(string.Join(",", res));
            //    //Console.WriteLine();
            //}
            {

                int[] spells = [20, 26, 38, 23, 23, 20, 14, 30];
                int[] potions = [24, 1, 7, 26, 19, 17, 7];
                int success = 510;
                var res = s.SuccessfulPairs(spells, potions, success);
                Console.WriteLine(string.Join(",", res));
            }
        }
    }
}
