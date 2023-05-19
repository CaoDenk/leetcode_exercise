using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _MergeAlternately
    {
        public string MergeAlternately(string word1, string word2)
        {

            StringBuilder sb=new StringBuilder();
            int len1=word1.Length;
            int len2=word2.Length;
            for(int i=0; ;++i )
            {


                if(i>=len1)
                {
                    while(i<len2)
                    {
                        sb.Append(word2[i]);
                        ++i;
                    }
                    break;
                }
                if (i >= len2)
                {
                    while (i < len1)
                    {
                        sb.Append(word1[i]);
                        ++i;
                    }
                    break;
                }
                sb.Append(word1[i]);
                sb.Append(word2[i]);

            }
            return sb.ToString();
        }
    }
}
