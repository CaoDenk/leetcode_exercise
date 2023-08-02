using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _KItemsWithMaximumSum
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

       
        //int Recur(int numOnes, int numZeros, int numNegOnes, int k,ref int t)
        //{
        //    if(t==0)
        //    {
        //        return k == 0 ? 1 : 0;
        //    }
        //    int sum = 0;
        //    if (numOnes > 0)
        //    {
        //        --t;
        //        sum += Recur(numOnes - 1, numZeros, numNegOnes, k - 1,ref t);
        //        ++t;
        //    }
        //    if (numZeros > 0)
        //    {
        //        --t;
        //        sum += Recur(numOnes, numZeros - 1, numNegOnes, k,ref t);
        //        ++t;
        //    }

        //    if (numNegOnes > 0)
        //    {
        //        --t;
        //        sum += Recur(numOnes, numZeros, numNegOnes - 1, k + 1,ref t);
        //        ++t;
        //    }


        //    return sum;

        //}

        static void Main(string[] args)
        {
            _KItemsWithMaximumSum k = new();
            Console.WriteLine(k.KItemsWithMaximumSum(3,2,0,2));
            Console.WriteLine(k.KItemsWithMaximumSum(3,2,0,4));
        }
    }
}
