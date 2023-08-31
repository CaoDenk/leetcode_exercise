using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 76. 最小覆盖子串
    /// </summary>
    internal class MinWindow_
    {
       
        public string MinWindow(string s, string t)
        {
            if (s.Length < t.Length)
                return string.Empty;
            if(t.Length==1)
            {
                if (s.Contains(t)) return t;
                else return string.Empty;
            }
            string ans = $"{s}\0";
            HashSet<char> keys = new();
            var table = Destruct(t,keys);
            var newTable = new int[123];
            Deque d = new Deque();
            int i=0;
            for (; i < s.Length && table[s[i]] == 0; ++i) ;            

            for (int j = i; j < s.Length; ++j)
            {
                if (table[s[j]]>0)
                {
                    d.AddBack(j);
                    if (++newTable[s[j]] >= table[s[j]])
                    {
                        keys.Remove(s[j]);
                        if (keys.Count == 0)//找到了一个解
                        {
                            int pos = i;
                            while (--newTable[s[i]] >= table[s[i]])
                            {
                                i = d.PopFront();
                                pos = i;
                            }
                            string str = s[pos..(j + 1)];
                            ans = ans.Length < str.Length ? ans : str;
                            keys.Add(s[i]);
                            i = d.PopFront();
                        }
                    }
                }
            }
            return ans.Length>s.Length?string.Empty:ans;
        }
        int[] Destruct(string s, HashSet<char> keys)
        {
            int[] table=new int[123];
            foreach(char c in s)
            {
                ++table[c];
                keys.Add(c);
            }           
            return table;
        }

        internal class Deque
        {
            int[] _Data = new int[128];
            int Offset = 1;
            int len = -1;
            public void AddBack(int value)
            {
                _Data[Offset + len++] = value;
                if (Offset + len >= _Data.Length)
                {
                    Grow();
                }
            }
            void Grow()
            {
                int newLen = _Data.Length * 2;
                var newData = new int[newLen];
                Array.Copy(_Data, Offset, newData, 1, len);
                _Data = newData;
                Offset = 1;
            }
            public int PopFront()
            {
                len--;
                return _Data[Offset++];
            }

        }


        static void Main(string[] args)
        {
            MinWindow_ m = new();
            Console.WriteLine(m.MinWindow("ADOBECODEBANC", "ABC"));
            //Console.WriteLine(m.MinWindow("ABDC", "ABC"));
            //Console.WriteLine(m.MinWindow("a", "a"));
            //Console.WriteLine(m.MinWindow("aa", "aa"));
            //Console.WriteLine(m.MinWindow("abc", "bc"));
            Console.WriteLine(m.MinWindow("bba", "ab"));
        }
    }
}
