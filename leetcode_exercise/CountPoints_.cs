using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2103. 环和杆
    /// </summary>
    internal class CountPoints_
    {
        public int CountPoints(string rings)
        {
            Dictionary<int, HashSet<char>> dict = new();
            for (int i = 0; i < rings.Length; i += 2)
            {
                if (dict.TryGetValue(rings[i+1],out var value))
                {
                    value.Add(rings[i]);
                }else
                {
                    dict[rings[i+1]] = new HashSet<char>() { rings[i] };
                }
    
            }
            return dict.Values.Count(item=>item.Count>3 );

        }
    }
}
