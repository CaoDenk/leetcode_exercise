using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _IsIsomorphic
    {
        public bool IsIsomorphic(string s, string t)
        {

            //Dictionary<char,int> tdict = new Dictionary<char,int>();
            Dictionary<char, char> stdict = new Dictionary<char, char>();
            Dictionary<char, char> tsdict = new Dictionary<char, char>();

            foreach (var (c, e) in Enumerable.Zip(s, t))
            {
                if (!stdict.ContainsKey(c))
                {
                    stdict[c] = e;
                }
                else if (stdict[c] != e)
                {
                    return false;
                }
                if(!tsdict.ContainsKey(e))
                {
                    tsdict[e] = c;
                }else if (tsdict[e]!=c)
                { 
                    return false;
                }
            }          
            return true;
        }

  

   
        string BuildString(string s,Dictionary<char,char> dict)
        {
            char[] chars=new char[s.Length];
            for(int i=0; i<s.Length; i++)
            {
                chars[i] = dict[s[i]];
            }
            return new string(chars);
        }
        Dictionary<char, char> FindMatch(string s, string t)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();

            foreach (var (c, e) in Enumerable.Zip(s, t))
            {
                if (!dict.ContainsKey(e))
                {
                    dict[c] = e;
                }
                else if (dict[c] != e)
                {

                }
            }
            return dict;

        }

        Dictionary<char, int> GetCharNumDict(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict[c] = 0;
                }
            }
            return dict;
        }
        void Cache(string s,string t)
        {
            var sdict = GetCharNumDict(s);
            var tdict = GetCharNumDict(t);
            foreach (var (c, e) in s.Zip(t))
            {
                if (sdict[c] != tdict[e])
                {
                   // return false;
                }
            }
        }

    }
}
