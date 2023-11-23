using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 917. 仅仅反转字母
    /// </summary>
    internal class ReverseOnlyLetters_
    {
        
            public string ReverseOnlyLetters(string s)
            {

                char[] buffer =s.ToCharArray();
                for (int i = 0 , k = s.Length - 1;  i < s.Length;)
                {
                    if (char.IsLetter(s[i]))
                    {
                        if (char.IsLetter(s[k]))
                        {
                            buffer[i++] = s[k--];
                        }
                        else
                        {
                            buffer[k] = s[k];
                            k--;
                        }
                    }
                    else
                    {
                        buffer[i] = s[i];
                        ++i;
                    }
                }
                return new string(buffer);
            }

        

    }
}
   