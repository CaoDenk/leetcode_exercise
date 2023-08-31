using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 65. 有效数字
    /// </summary>
    internal class IsNumber_
    {
   
        public bool IsNumber(string s)
        {
            int ePos = -1;
            for(int i=0; i < s.Length;++i)
            {
                if ( s[i] is 'e' or 'E')
                {
                    if(ePos==-1)
                        ePos = i;
                    else
                        return false;
                }
            }
            if(ePos==0) return false;
            if(ePos<0) return CheckNumber(s);
            else
            {
                bool res=Check(s[(ePos + 1)..], out bool flag,true);
                if(!res||!flag)
                    return false;
                return CheckNumber(s[..ePos]);
            }
        }

        bool Check(string s,out bool flag,bool canHaveSign)//是否是整数
        {
            flag = false;
            if (s.Length == 0)
            {
                return true;
            }
            int i = 0;
            if (canHaveSign)
            {
                if (s[i] is '+' or '-')
                {
                    ++i;
                }
            } 
            for (; i < s.Length; ++i)
            {               
                if (!char.IsDigit(s[i]))
                {               
                    return false;
                }
                flag = true;
            }
            return true;
        }

        bool CheckNumber(string s)
        {
            int dotPos = s.IndexOf('.');
            if (dotPos >= 0)
            {
               
                bool res = Check(s[(dotPos + 1)..], out bool b1,false);
                if (!res )
                    return false;
                bool res2 = Check(s[0..dotPos], out bool b2,true);
                return res2 && (b1 || b2);
            }
            else
            {
               bool res=  Check(s, out bool b, true);
               return res && b;
            }
        }



        static void Main(string[] args)
        {
            IsNumber_ i = new();
            Console.WriteLine(i.IsNumber("0"));
            Console.WriteLine(i.IsNumber("1e."));
            Console.WriteLine(i.IsNumber("10e"));
            Console.WriteLine(i.IsNumber(".-4"));
            Console.WriteLine(i.IsNumber("+.8"));
            //Console.WriteLine(i.IsNumber("Infinity"));

        }
    }
}
