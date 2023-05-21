using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Tribonacci
    {

        public int Tribonacci(int n)
        {
            List<int> list = new()
            {
                0,
                1,
                1
            };
            int i;
            for(; (i=list.Count) <= n+1;) {
                int num = list[i - 3] + list[i - 2]+list[i - 1];
                list.Add(num);
            }
            return list[n];
        }

        static void Main()
        {
            _Tribonacci t = new();
            {
                Console.WriteLine(t.Tribonacci(4));
            }

        }
    }
}
