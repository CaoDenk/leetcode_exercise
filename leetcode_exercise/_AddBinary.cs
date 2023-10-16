using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 67. 二进制求和
    /// </summary>
    internal class _AddBinary
    {
        public string AddBinary(string a, string b)
        {
           
            if(a.Length<b.Length)  (a,b)=(b,a);
            int maxLen = a.Length;
            char[] chars = new char[maxLen+1];
            
            bool jinwei = false;
            int i, j;
            for(i = a.Length - 1, j=b.Length-1;j>=0 ; --i,--j)
            {
                (jinwei, chars[i+1]) = Add(a[i], b[j],jinwei);
            }
            for(;i>=0;--i)
            {   
                if(jinwei)
                {
                    (jinwei, chars[i + 1]) = Add(a[i], '0', jinwei);
                }else
                {
                    Array.Copy(a.ToCharArray(), 0, chars, 1, i + 1);
                    return new string(chars, 1, chars.Length - 1);
                }               
            }
            if (jinwei)
            {
                chars[0]= '1';
                return new string(chars);
            }
            else
            {
                return new string(chars, 1, chars.Length - 1);
            }

        }

        static (bool,char) Add(char c1,char c2,bool b)
        {

            return (c1, c2, b) switch
            {
                ('0', '0', false) => (false, '0'),
                ('0', '1', false) or ('0', '0', true) or ('1', '0', false) => (false, '1'),
                ('1', '1', false) or ('0', '1', true) or ('1', '0', true) => (true, '0'),
                _ => (true, '1'),
            };
        }
        static void Main()
        {
            _AddBinary addBinary = new _AddBinary();
            Console.WriteLine(addBinary.AddBinary("11","1"));
        }


    }
}
