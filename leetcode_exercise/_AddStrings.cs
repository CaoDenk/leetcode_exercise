using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 415. 字符串相加
    /// </summary>
    internal class _AddStrings
    {
        public string AddStrings(string num1, string num2)
        {
            //return Convert.ToString(int.Parse(num1)+int.)
            if(num1.Length<num2.Length)
            {
                (num1,num2)=(num2,num1);
            }

            int diff=num1.Length-num2.Length;
            char[] str2 = new char[diff];
            Array.Fill(str2,'0',0,diff);
            num2 =new string(str2)+num2;
            char[] ret=new char[num1.Length+1];
            int flag = 0;
            for(int i = num1.Length-1; i >=0; i--)
            {
                (flag, ret[i+1])= Add(num1[i], num2[i],flag);
            }
            if (flag == 1)
            {
                ret[0] = '1';
                return new string(ret);
            }else
                return new string(ret,1,num1.Length);

        }
        (int,char) Add(char c1,char c2,int flag)
        {
            int i1 = c1 - '0';
            int i2 = c2 - '0';
            int num;
            char c;
            if((num=i1+i2 +flag)> 9) 
            {
                c = map[num - 10];
                flag = 1;
            }else
            {
                c = map[num];
                flag = 0;
            }
            return (flag, c);
        }

        static char[] map = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];


        static void Main(string[] args)
        {
            _AddStrings a = new();
            var ret=a.AddStrings("11", "123");
            Console.WriteLine(ret);
        }
    }
}
