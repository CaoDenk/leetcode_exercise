using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    //修改几次变成等差数列
    internal class MakeArray
    {
        int MinCount(int[] arr)
        {
            int count = 0;
            Range r= new Range(arr[0] + 1, arr[0]+1);
            for(int i=1;i<arr.Length;i++)
            {
               
            }

            return count;
        }

        static void Main(string[] args)
        {
            MakeArray m = new();
            Console.WriteLine(m.MinCount(new int[] { 1,5,6,7}));

        }

    }
}
