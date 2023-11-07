using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 187. 重复的DNA序列
    /// </summary>
    internal class FindRepeatedDnaSequences_
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            const int L = 10;
            Dictionary<string, int> dict = new();
            HashSet<string> set = new();
            for(int i = 0;i<=s.Length-L;++i)
            {
                string t = s.Substring(i, L);
                dict[t]=dict.GetValueOrDefault(t)+1;
                if (dict[t]>=2)
                {
                    set.Add(t);
                }
            }
            return set.ToList();
        }
        static void Main(string[] args)
        {
            FindRepeatedDnaSequences_ f = new();
            var res=f.FindRepeatedDnaSequences("AAAAAAAAAAA");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

        }
    }
}
