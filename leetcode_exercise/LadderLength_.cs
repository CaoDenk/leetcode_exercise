using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 127. 单词接龙
    /// 双向bfs
    /// </summary>
    internal class LadderLength_
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {

            if (!wordList.Contains(endWord))
                return 0;
            HashSet<string> beginSet = new HashSet<string>() { beginWord };
            HashSet<string> endSet = new HashSet<string>() { endWord };
            int step = 2;
            HashSet<string> surroudings;
            while (beginSet.Count > 0 && endSet.Count > 0)
            {
                surroudings = new HashSet<string>();
                for (int i = 0; i < beginSet.Count; i++)
                {
                    string word = beginSet.ElementAt(i);

                    wordList.Remove(word);
                    int count = wordList.Count - 1;
                    for (int j = count; j >= 0; j--)
                    {
                        if (Compare(word, wordList[j]))
                        {
                            if (endSet.Contains(wordList[j]))
                                return step;
                            surroudings.Add(wordList[j]);
                            wordList.RemoveAt(j);
                        }
                    }
                }
                //Console.WriteLine("beginset: "+string.Join(",",beginSet)+"\tsurroudings: " + string.Join(",",surroudings));
                step++;
                beginSet = surroudings;
            }
            return 0;
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
            LadderLength_ l = new();
            {
                //beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
                string beginWord = "hit";
                string endWord = "cog";
                List<string> wordList = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
                Console.WriteLine(l.LadderLength(beginWord, endWord, wordList));
            }
            //{
            //    //beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
            //    string beginWord = "hit";
            //    string endWord = "cog";
            //    List<string> wordList = new List<string>() { "hot", "dot", "dog", "lot", "log" };
            //    Console.WriteLine(l.LadderLength(beginWord, endWord, wordList));
            //}
            //{
            //    //beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
            //    string beginWord = "hit";
            //    string endWord = "cog";
            //    List<string> wordList = new List<string>() { "hot", "cog", "dot", "dog", "hit", "lot", "log" };
            //    Console.WriteLine(l.LadderLength(beginWord, endWord, wordList));
            //}
            {
                //beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
                string beginWord = "a";
                string endWord = "c";
                List<string> wordList = new List<string>() { "a", "b", "c" };
                Console.WriteLine(l.LadderLength(beginWord, endWord, wordList));
            }
            {
                //["hot","cog","dog","tot","hog","hop","pot","dot"]
                string beginWord = "hot";
                string endWord = "dog";
                List<string> wordList = new List<string>() { "hot", "cog", "dog", "tot", "hog", "hop", "pot", "dot" };
                Console.WriteLine(l.LadderLength(beginWord, endWord, wordList));
            }
        }
    }
}
