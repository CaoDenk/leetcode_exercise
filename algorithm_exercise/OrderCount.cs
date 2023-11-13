using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class OrderCount
    {
        public static void Main()
        {
            //Stack<int> ints = new Stack<int>();
            //int[] arr = { 3, 2, 1 };
            //foreach(int i in arr)
            //{
            //    ints.Push(i);
            //}
            //StringBuilder sb = new();
            //visit(sb, ints);

            Order("0123", "", "");
        }

        static void Order(string s1, string s2, string s3)
        {
            if (s1.Length == 0 && s2.Length == 0)
            {
                Console.WriteLine(s3.ToString());
            }
            if (s1.Length > 0)
            {
                char c = s1[^1];

                Order(s1.Remove(s1.Length - 1), s2 + c, s3);
            }
            if (s2.Length > 0)
            {
                char c = s2[^1];

                Order(s1, s2.Remove(s2.Length - 1), s3 + c);

            }

        }

    }
}
