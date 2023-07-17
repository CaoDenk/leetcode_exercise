using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _HammingWeight
    {
        public int HammingWeight(uint n)
        {
            string s=Convert.ToString(n, 2);
            
            return s.Where(i => i == '1').Count();
        }
    }
}
