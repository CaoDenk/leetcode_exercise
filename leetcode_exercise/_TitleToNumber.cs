using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 171. Excel 表列序号
    /// </summary>
    internal class _TitleToNumber
    {
        Dictionary<char,int> init()
        {
            Dictionary<char,int> dict = new Dictionary<char,int>();
            for (int i = 0; i < 26; ++i)
            {
                dict[(char)('A' + i)] = i;
            }
            return dict;
        }
        public int TitleToNumber(string columnTitle)
        {
            int exp = 0;
            int num = 0;
            var dict=init();
            for(int i=columnTitle.Length-1; i>=0; --i)
            {
                // num =(int)Math.Pow(num,exp) +(1+ dict[columnTitle[i]]);
                char c = columnTitle[i];
                int j = dict[c];
                int expnum = (int)Math.Pow(26, exp);
                num = expnum * (1 + j) +num;

                exp++;
            }
            return num;
        }

        //public int ConvertToTitle(int columnNumber)
        //{

        //    Stack<char> ints = new Stack<char>();
        //    var map = init();
        //    do
        //    {
        //        --columnNumber;
        //        columnNumber = Math.DivRem(columnNumber, 26, out int i);
        //        ints.Push(i);

        //    } while (columnNumber != 0);

        //    int[] ret = new int[ints.Count];
        //    for (int i = 0; i < ret.Length; ++i)
        //    {
        //        ret[i] = map[ints.Pop()];
        //    }

        //    return 0;
        //}
        static void Main(string[] args)
        {
            _TitleToNumber t = new();
            Console.WriteLine(t.TitleToNumber("A"));
            Console.WriteLine(t.TitleToNumber("AB"));
            Console.WriteLine(t.TitleToNumber("ZY"));
        }
    }
}
