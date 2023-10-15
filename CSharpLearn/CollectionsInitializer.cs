using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class CollectionsInitializer
    {
        static void Main(string[] args)
        {
            List<int> l =[1, 2, 3];
            int[] arr = [4, 5, 6];
            HashSet<int> set = [5, 2];
            Dictionary<int, char> dict = new() { { 5, 'a' } ,  };
        }
    }
}
