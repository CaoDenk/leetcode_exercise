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
            Dictionary<Dictionary<char, int>, List<string>> map = new(new MyEq());
            IList<IList<string>> res ;
            foreach (var i in strs)
            {
                var d = Deconstruct(i);
                if (map.ContainsKey(d))
                {
                    map[d].Add(i);
                }else
                {
                    map[d] = new List<string>() { i };
                }
            }

            res = map.Values.ToList<IList<string>>();
            return res;
        }

        Dictionary<char,int> Deconstruct(string s)
        {
            Dictionary<char,int> dict = new Dictionary<char,int>();
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else dict[c] = 1;
            }
            return dict;
        }

        class MyEq : IEqualityComparer<Dictionary<char, int>>
        {
            public bool Equals(Dictionary<char, int> x, Dictionary<char, int> y)
            {
                if(x.Count != y.Count)
                    return false;
                foreach(char c in x.Keys)
                {
                    if (!y.ContainsKey(c) || x[c] != y[c])
                        return false;
                }
                return true;
            }

            public int GetHashCode([DisallowNull] Dictionary<char, int> obj)
            {
                return 99999;
            }
        }
        static void Main(string[] args)
        {
            GroupAnagrams_ g = new();
            //{
            //    var res = g.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            //    foreach (var item in res)
            //   Console.WriteLine(string.Join(",", item));
            //}
            {
                var res = g.GroupAnagrams(new string[] { "", "b" });
                foreach (var item in res)
                    Console.WriteLine(string.Join(",", item));
            }
        }
    }

    


}
