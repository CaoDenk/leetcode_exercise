using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 反转单词
    /// </summary>
    internal class WordsReverse
    {

        string Reverse(string words)
        {

            int len=words.Length;
            char[] charArray=words.ToCharArray();
            Reverse(charArray, 0, len);
            int k = 0;
            int v = 0;
            while(k<len)
            {
                while (k < len && charArray[k] != ' ')
                {
                    k++;
                }
                Reverse(charArray,v, k);
                ++k;
                v = k;
            }
            return new string(charArray);
        }

        void Reverse(char[] charArray, int i,int j)
        {
            --j;
            for (; i < j; ++i, --j)
            {
                (charArray[i], charArray[j]) = (charArray[j], charArray[i]);
            }
        }

        static void Main(string[] args)
        {
            WordsReverse w=new WordsReverse();
            {
                Console.WriteLine(w.Reverse("Tom caught Jerry"));
            }
        }

    }
}
