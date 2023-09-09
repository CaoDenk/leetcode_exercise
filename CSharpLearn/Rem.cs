using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class Rem
    {
        static void Main(string[] args)
        {
            int i = 10;
            int j = 3;

            int res = Math.DivRem(i, j, out int rem);
        }
    }
}
