using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 151. 反转字符串中的单词
    /// </summary>
    internal class ReverseWords_
    {
        public string ReverseWords(string s)
        {
 
            string[] strings = Split(s);
            return string.Join(" ", strings);
        }
        string[] Split(string s)
        {

            int i = 0;
            int len=s.Length;
            List<string> strings = new List<string>();
            while(i<len)
            {
                if (s[i] == ' ')
                {
                    i++;
                }else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(s[i]);
                    ++i;
                    while(i<len)
                    {
                        if (s[i] != ' ')
                        {
                            stringBuilder.Append(s[i]);
                            ++i;
                        }
                        else break;          
                    }
                    strings.Add(stringBuilder.ToString());
                }


            }
             strings.Reverse();
            return strings.ToArray();
        }
        static void Main(string[] args)
        {
            ReverseWords_ r = new();
           var ret= r.ReverseWords("the sky is blue");
            Console.WriteLine(ret);
        }
    }
}
