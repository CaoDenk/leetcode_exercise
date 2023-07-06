using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _IsPowerOfTwo
    {

        public bool IsPowerOfTwo(int n)
        {
            if(n < 1)
                return false;
            return (n & (n - 1)) == 0;
          
        }
        public bool IsPowerOfTwo2(int n)
        {

            return false;
        }
        static void Main()
        {
            _IsPowerOfTwo i = new _IsPowerOfTwo();
            Console.WriteLine(i.IsPowerOfTwo(5));
            Console.WriteLine(i.IsPowerOfTwo(6));
            Console.WriteLine(i.IsPowerOfTwo(7));
            Console.WriteLine(i.IsPowerOfTwo(8));

        }

    }
}
