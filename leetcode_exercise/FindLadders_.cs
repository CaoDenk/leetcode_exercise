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
    /// </summary>
    internal class FindLadders_
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return Array.Empty<List<string>>();

            List<IList<string>> res = new()
            {
                new List<string>() { beginWord }
            };
            HashSet<string> beginSet = new HashSet<string>() { beginWord };
            HashSet<string> endSet = new HashSet<string>() { endWord };

            HashSet<string> surroudings;
            while (beginSet.Count > 0 && endSet.Count > 0)
            {
                surroudings = new HashSet<string>();
                bool flag = false;
                for (int i = 0; i < beginSet.Count; i++)
                {
                    string word = beginSet.ElementAt(i);

                    wordList.Remove(word);
                    int count = wordList.Count - 1;
                    if (res.Count == 0)
                        return Array.Empty<List<string>>();
                    int len = res[0].Count;
                    for (int j = count; j >= 0; j--)
                    {
                        if (Compare(word, wordList[j]))
                        {
                            Add(res, word,wordList[j]);

                            if ( endSet.Contains(wordList[j]))
                            {

                                Add(res, wordList[j],endWord);
                                flag = true;
                                
                            }
                            surroudings.Add(wordList[j]);
                            wordList.RemoveAt(j);
                        }
                    }
                    for(int k=res.Count - 1; k >= 0; k--)
                    {
                        if (res[k].Count==len)
                            res.RemoveAt(k);
                    }

                }
                if (flag)
                    return res;
                beginSet = surroudings;
            }
           


            return Array.Empty<List<string>>();
        }

        void Add(List<IList<string>> ans,string wordbegin,string end)
        {
            
            foreach(var a in ans)
            {
                if (a[^1]== wordbegin)
                {

                    ans.Add(a.ToList());
                    a.Add(end);
                    break;

                }
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
                var res=f.FindLadders(beginWord, endWord,wordlist);
                foreach(var a in res)
                {
                    Console.WriteLine(string.Join(",",a));
                }
            }
        }

    }
}
