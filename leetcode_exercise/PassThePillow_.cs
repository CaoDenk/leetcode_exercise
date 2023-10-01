using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class PassThePillow_
    {
        public int PassThePillow(int n, int time)
        {

            //int everyTurn = 2 * (n - 1);

            int t = Math.DivRem(time, n - 1, out int rem);
            if(t%2==0)
            {

                return rem;
            }else
            {
                return n - rem;
            }


        }

    }
}
