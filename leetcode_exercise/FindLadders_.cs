using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 126. 单词接龙 II
    /// 挖坑，怎么改都超时，要不报错
    /// </summary>
    internal class FindLadders_
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return Array.Empty<List<string>>();

            List<IList<string>> res = new();
  
            HashSet<string> beginSet = new HashSet<string>() { beginWord };
            HashSet<string> surroudings;
            Dictionary<string, HashSet<string>> dict = new();
            int level = 0;
            HashSet<string> lastLevel = new HashSet<string>();
            while (beginSet.Count > 0 )
            {
                surroudings = new HashSet<string>();
                bool flag = false;

                for (int i = 0; i < beginSet.Count; i++)
                {
                    string word = beginSet.ElementAt(i);
                    wordList.Remove(word);
                    int count = wordList.Count - 1;
                    dict[word] = new HashSet<string>();
                    for (int j = count; j >= 0; j--)
                    {
                        if (Compare(word, wordList[j]))
                        {
                            if (lastLevel.Contains(wordList[j]))
                            {
                                continue;
                            }

                            dict[word].Add(wordList[j]);
                            if (endWord == wordList[j])
                            {

                                dict[word].Clear();
                                dict[word].Add(endWord);
                                flag = true;
                                break;
                            }
                            surroudings.Add(wordList[j]);
                        }
                    }
                    wordList.Add(word);
                }
                ++level;
                if (flag)
                {
                    List<HashSet<string>> lhh = new();
                    AddRecurse(lhh, new HashSet<string>() { beginWord }, dict, 0, level,endWord);
                    
                    foreach(var  l in lhh)
                    {
                        res.Add(l.ToList());
                    }
                    return  res;
                }
               
                beginSet = surroudings;
            }
            return Array.Empty<List<string>>();
        }

        void AddRecurse(List<HashSet<string>> ans,HashSet<string> l, Dictionary<string, HashSet<string>> dict,int start,int level,string endword)
        {
            if(start>=level)
            {
                if(l.ElementAt(^ 1)==endword)
                    ans.Add(l);
                return;
            }
            
            string key = l.ElementAt(^1);
            if(!dict.TryGetValue(key,out var set))
            {
                return;
            }
            foreach(var item in set)
            {
                if(l.Contains(item))
                {
                    continue;
                }
                var newl=l.ToHashSet();
                newl.Add(item);
                AddRecurse(ans, newl,dict,start+1,level,endword);
            }
        }

      
        bool Compare(string s, string charArray)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != charArray[i])
                {
                    if (count == 0)
                        ++count;
                    else return false;
                }
            }
            return count == 1;
        }
        static void Main(string[] args)
        {
            FindLadders_ f = new();
            {
                //beginWord = "hit", endWord = "cog"
                string beginWord = "hit";
                string endWord = "cog";
                List<string> wordlist = new() { "hot", "dot", "dog", "lot", "log", "cog" };
                var res = f.FindLadders(beginWord, endWord, wordlist);
                foreach (var a in res)
                {
                    Console.WriteLine(string.Join(",", a));
                }
            }
            {
                //beginWord = "hit", endWord = "cog"
                string beginWord = "a";
                string endWord = "c";
                List<string> wordlist = new() { "a", "b", "c" };
                var res = f.FindLadders(beginWord, endWord, wordlist);
                foreach (var a in res)
                {
                    Console.WriteLine(string.Join(",", a));
                }
            }

            {
                //beginWord = "hit", endWord = "cog"
                string beginWord = "red";
                string endWord = "tax";
                List<string> wordlist = new() { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" };
                var res = f.FindLadders(beginWord, endWord, wordlist);
                foreach (var a in res)
                {
                    Console.WriteLine(string.Join(",", a));
                }
            }

            {
                //beginWord = "hit", endWord = "cog"
                string beginWord = "qa";
                string endWord = "sq";
                List<string> wordlist = new() { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" };
                var res = f.FindLadders(beginWord, endWord, wordlist);
                Console.WriteLine(res.Count);
                foreach (var a in res)
                {
                    Console.WriteLine(string.Join(",", a));
                }
            }
        }

    }
}
