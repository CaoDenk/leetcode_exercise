using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 205. 同构字符串
    /// </summary>
    internal class _IsIsomorphic
    {
        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> stdict = new Dictionary<char, char>();
            Dictionary<char, char> tsdict = new Dictionary<char, char>();

            foreach (var (c, e) in Enumerable.Zip(s, t))
            {
                if (stdict.TryGetValue(c, out char value)&&value!=e||tsdict.TryGetValue(e, out char value2)&& value2 != c)
                {
                    return false;
                }
                else 
                {
                    stdict[c] = e;
                    tsdict[e] = c;
                }
            }          
            return true;
        }

  

    }
}
