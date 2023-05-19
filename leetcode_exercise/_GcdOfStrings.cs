using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _GcdOfStrings
    {
        public string GcdOfStrings(string str1, string str2)
        {
            //StringBuilder sb = new StringBuilder();
            
            string ret=string.Empty;
            string minstr;
            int len;
            if(str1.Length>str2.Length)
            {
                minstr = str2;
                len = str2.Length;

            }else
            {
                minstr = str1;
                len = str1.Length;
            }
            

            if (len == 0)
                return ret;

            len= GetLargestCommonDivisor(str1.Length,str2.Length);
            for (int i=1; i<=len;++i)
            {
                string s = minstr[0..i];
                if (CanDivBy(str1,s) &&CanDivBy(str2 ,s))
                {
                    ret= s;
                }

            }
            return ret;
        }

        bool CanDivBy(string s, string str)
        {
            int len = str.Length;
          
            if (s.Length%len!=0)
                return false;
            int num = s.Length / len;
            for (int i=0; i < num; i++)
            {
                string substr = s[(len * i)..(len * (i + 1))];
                if (str !=substr)
                {
                    return false;
                }

            }
            return true;
            
        }
        int GetLargestCommonDivisor(int n1, int n2)
        {
            int max = n1 > n2 ? n1 : n2;
            int min = n1 < n2 ? n1 : n2;
            int remainder;
            while (min != 0)
            {
                remainder = max % min;
                max = min;
                min = remainder;
            }
            return max;
        }
        static void Main()
        {
            _GcdOfStrings g = new();
            {
                //string str1 = "ABCABC";
                //string str2 = "ABC";
                //Console.WriteLine(g.GcdOfStrings(str1,str2));
            }
            {
                string str1 = "ABABAB";
                string str2 = "ABAB";
                Console.WriteLine(g.GcdOfStrings(str1, str2));
            }



        }
    }
}
