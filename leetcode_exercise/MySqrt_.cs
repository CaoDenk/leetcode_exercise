using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MySqrt_
    {

        public int MySqrt(int x)
        {
            if(x<1)
                return 0;
           if(x==1)
                return 1;
            int ret = 0;
            for(long i = 0; i < x/2; i++)
            {
                if (i * i <= x && (i + 1) * (i + 1) > x)
                    break;

            }
            return ret;

        }


        static void Main()
        {

            MySqrt_ m = new();
            Console.WriteLine(m.MySqrt(2147395600));

        }

    }
}
