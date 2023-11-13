using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 68. 文本左右对齐
    /// </summary>
    internal class FullJustify_
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            int start = 0;
            List<string> result = new List<string>();
            while(start< words.Length)
            {
                result.Add(BuildLine(words,maxWidth,ref start));
            }
            return result;
        }

        string BuildLine(string[] words, int maxWidth,ref int start)
        {
            StringBuilder sb = new();
            int len = 0;
            int k = start;
            int count=0;
            for(; start<words.Length;++start )
            {
                len += words[start].Length;
                if(len+count<=maxWidth)
                {
                    ++count;
                }else
                {
                    len -= words[start].Length;
                    break;
                }
            }
            int spaceCount = maxWidth - len;
            if (count > 1)
            {
                int every = Math.DivRem(spaceCount, count-1, out int rem);
                if (start != words.Length)
                {
                    char[] chars= new char[every+1];
                    Array.Fill(chars, ' ');
                    int j = 0;
                    for (; j < count - 1; j++)
                    {
                        if (rem > 0)
                        {
                            sb.Append(words[k+j]).Append(chars);
                            --rem;
                        }
                        else
                            sb.Append(words[k + j]).Append(chars[..^1]);

                    }
                    sb.Append(words[k + j]);
                }else
                {
                    int j = 0;
                    for (; j < count - 1; j++)
                    {
                        sb.Append(words[k + j]).Append(' ');
                    }
                    char[] chars = new char[spaceCount - j];
                    Array.Fill(chars, ' ');
                    sb.Append(words[k+j]).Append(chars);
                }
            }else
            {
                char[] chars = new char[spaceCount];
                Array.Fill(chars, ' ');
                sb.Append(words[k]).Append(chars);
            }

            return sb.ToString();
        }
        static void Main(string[] args)
        {
            FullJustify_ f = new();
            //{
            //    string[] words = { "This", "is", "an", "example", "of", "text", "justification." };
            //    var res = f.FullJustify(words, 16);
            //    foreach(string s in res)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            //{
            //    string[] words = { "What", "must", "be", "acknowledgment", "shall", "be" };
            //    var res = f.FullJustify(words, 16);
            //    foreach (string s in res)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            {
                string[] words = ["Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do"];
                var res = f.FullJustify(words, 16);
                foreach (string s in res)
                {
                    Console.WriteLine(s);
                }
            }
        }

    }
}
