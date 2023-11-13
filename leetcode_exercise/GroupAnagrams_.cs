using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 49. 字母异位词分组
    /// </summary>
    internal class GroupAnagrams_
    {

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new();
            IList<IList<string>> res ;
            foreach (var i in strs)
            {
                var d = BreakUp(i);
                if (map.TryGetValue(d, out List<string>? value))
                {
                    value.Add(i);
                }else
                {
                    map[d] = new List<string>() { i };
                }
            }

            res = map.Values.ToList<IList<string>>();
            return res;
        }

   

        string BreakUp(string s)
        {
            char[] chars = new char[26];
            foreach (char c in s)
            {
                chars[c - 'a']++;
            }
            return  new string(chars);
        }
      
        static void Main(string[] args)
        {
            GroupAnagrams_ g = new();

            {
                var res = g.GroupAnagrams(new string[] { "", "b" });
                foreach (var item in res)
                    Console.WriteLine(string.Join(",", item));
            }
        }
    }

    


}
