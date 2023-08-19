using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 获取excel表头
    /// </summary>
    internal class _ConvertToTitle
    {

        char[] init()
        {
            char[] ret = new char[26];
            for(int i=0;i<26;++i)
            {
                ret[i] = (char)('A' + i);
            }
            return ret;
        }
        /// <summary>
        /// 0->A
        /// 25->Z
        /// 26 AA
        /// 27 AB
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public string ConvertToTitle(int columnNumber)
        {
          
            Stack<int> ints = new Stack<int>();
            var map = init();
            do
            {
                --columnNumber;
                columnNumber = Math.DivRem(columnNumber, 26, out int i);
                ints.Push(i);

            }while(columnNumber!=0);

            char[] ret = new char[ints.Count];
            for(int i=0;i<ret.Length;++i)
            {
                ret[i] = map[ints.Pop()];
            }
            return new string(ret);
        }
        static void Main(string[] args)
        {
            _ConvertToTitle c = new();
            //{
            //    var str = c.ConvertToTitle(28);
            //    Console.WriteLine(str);
            //}
            //{
            //    var str = c.ConvertToTitle(28);
            //    Console.WriteLine(str);
            //}
            //{
            //    var str = c.ConvertToTitle(26);
            //    Console.WriteLine(str);
            //}

            //{
            //    var str = c.ConvertToTitle(28 - 1);
            //    Console.WriteLine(str);
            //}
            //{
            //    var str = c.ConvertToTitle(701);
            //    Console.WriteLine(str);
            //}
            //{
            //    var str = c.ConvertToTitle(2147483647);
            //    Console.WriteLine(str);
            //}
            //{
            //    var str = c.ConvertToTitle(52);
            //    Console.WriteLine(str);
            //}
            for (int i = 1; i < 1000; i++)
            {
                var str = c.ConvertToTitle(i);
                Console.WriteLine($"{i}={str}");
            }
        }
    }
}
