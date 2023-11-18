using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _IsValid
    {
        string un = "])}";//第一次出现时抛异常
        string value;
        readonly Dictionary<char, char> dir = new Dictionary<char, char>()
        {
                {'(',')' },
                {'{','}' },
                {'[',']' },
        };
       
        public bool check()
        {
            int i = 0;
            for (; i < value.Length; i++)
            {
                if (un.Contains(value[i]))
                {
                    return false;
                }
                if (dir.Keys.Contains(value[i]))
                {
                    try
                    {
                        parse(ref i, dir[value[i]]);
                    }catch
                    {
                        return false;
                    }
                 
                }
            }
            return true;
        }

        void parse(ref int i, char c)
        {
            i++;
            for (; i < value.Length; i++)
            {
                if (value[i] == c)
                    return;
                if (un.Contains(value[i]))
                {
                    throw new Exception(c + " is illegal");
                }
                if (dir.Keys.Contains(value[i]))
                {
                    parse(ref i, dir[value[i]]);
                }
            }
            throw new Exception(c + " Not Found");

        }

        public bool IsValid(string s)
        {
            value = s;
            return check();
        }

        public static void Main(string[] args)
        {
            _IsValid isv= new();
            isv.value = "]";
            Console.WriteLine(isv.check());
        
        }
    }
}
