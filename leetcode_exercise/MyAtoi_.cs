using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MyAtoi_
    {
        public int MyAtoi(string s)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    continue;
                }
                if (char.IsDigit(s[i]) || s[i]=='-')
                {
                    do
                    {
                        sb.Append(s[i]);
                        ++i;
                    } while (i < s.Length && char.IsDigit(s[i]));
                }
                else if (s[i]=='+')
                {
                    ++i;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        sb.Append(s[i]);
                        ++i;
                    } ;
                }
                break;
            }
            if( sb.Length == 0 )
                return 0;
            if (sb[0] == '-' && sb.Length == 1)
                return 0;
            var ret=BigInteger.Parse(sb.ToString());
            if(ret<int.MinValue)
            {
                return int.MinValue;
            }
            if(ret>int.MaxValue)
            {
                return int.MaxValue;
            }

            return  (int)ret;
        }
      
        static void Main(string[] args)
        {
            MyAtoi_ my = new();
            Console.WriteLine(my.MyAtoi("3.14159"));
        }

    }
}
