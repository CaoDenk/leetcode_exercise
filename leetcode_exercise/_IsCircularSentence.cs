using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2490. 回环句
    /// </summary>
    internal class _IsCircularSentence
    {
        public bool IsCircularSentence1(string sentence)
        {
            string[] strings = sentence.Split(' ');
            int len = strings.Length;
            for (int i=0; i<len-1; i++)
            {
                if(strings[i][^1] != strings[i + 1][0])
                    return false;
            }
            if (strings[0][0] != strings[^1][^1])
                return false;
            return true;

        }

        public bool IsCircularSentence(string sentence)
        {
            if (sentence[0] != sentence[^1])
                return false;
            for(int i=1;i<sentence.Length-1;++i)
            {
                if (sentence[i]==' ')
                {
                    if (sentence[i-1] != sentence[i+1])
                            return false;
                }
            }
            return true;

        }
    }
}
