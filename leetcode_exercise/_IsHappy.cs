using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _IsHappy
    {
        public bool IsHappy(int n)
        {
            HashSet<int> visited = new HashSet<int>();
            while (true)
            {
                visited.Add(n);
                int sum = 0;
                do
                {
                    n = Math.DivRem(n, 10, out int i);
                    sum += i * i;

                } while (n!=0);
              
                if(sum == 1)
                    return true;
              
                if (visited.Contains(sum))
                    return false;
                n = sum;
            }
        }

     
        static void Main(string[] args)
        {
            _IsHappy isHappy = new();
            //Console.WriteLine(isHappy.IsHappy(19));
            Console.WriteLine(isHappy.IsHappy(2));
        }
    }
}
