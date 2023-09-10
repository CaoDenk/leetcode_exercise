using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class ValueTupleTest
    {
        static void Main(string[] args)
        {
            ValueTuple<int, int> v = new();
            v = (1, 2);

        }
    }
}
