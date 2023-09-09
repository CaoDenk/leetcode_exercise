using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 131. 分割回文串
    /// 挖坑，坑还挺多
    /// 留给明天
    /// </summary>
    internal class Partition_
    {
        public IList<IList<string>> Partition(string s)
        {
            //i和j都包含
            List<IList<string>> ans=new();
            Recursive(ans, new List<string>(), s, 0);
            return ans;
        }


        void Recursive(List<IList<string>> ans,List<string> l,string s,int start) 
        {
            if(start>=s.Length)
            {
                ans.Add(l.ToList());
                return;
            }
            for (int i = start; i < s.Length; ++i)
            {
                if (IsPalindrome(s,start,i))
                {
                    l.Add(s[start..(i+1)]);
                    Recursive(ans, l, s, i + 1);
                    l.RemoveAt(l.Count - 1);
                }
            }

        }
        bool IsPalindrome(string s, int start, int end)
        {
            if (end == start) return true;
            for (; start < end; ++start, --end)
            {
                if (s[start] != s[end])
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Partition_ p = new();
            var res=p.Partition("aab");
            foreach(var item in res)
            {
                Console.WriteLine(string.Join(",",item));
            }

        }
    }
}
