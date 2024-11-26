using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2600. K 件物品的最大和
    /// </summary>
    internal class KItemsWithMaximumSum_
    {
        public int KItemsWithMaximumSum(int numOnes, int numZeros, int numNegOnes, int k)
        {
            if(numOnes >= k) {
                return k;
            }
            int sum = numOnes;
            k -= numOnes;

            if (numZeros >= k)
                return sum;
            k-= numZeros;
            return sum-k;

        }



        static void Main(string[] args)
        {
            KItemsWithMaximumSum_ k = new();
            Console.WriteLine(k.KItemsWithMaximumSum(3,2,0,2));
            Console.WriteLine(k.KItemsWithMaximumSum(3,2,0,4));
        }
    }
}
