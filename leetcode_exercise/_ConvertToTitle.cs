using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 获取excel表头  //提交失败
    /// </summary>

    internal class _ConvertToTitle
    {

        char[] init()
        {
            char[] ret = new char[27];
            ret[0] ='Z';
            for(int i=0;i<26;++i)
            {
                ret[i+1] = (char)('A' + i);
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
            bool flag = false;
            do
            {
                if(columnNumber<27)
                {
                    if (!flag)
                        ints.Push(columnNumber);
                    else
                        ints.Push(columnNumber-1);
                    break;
                }
                columnNumber = Math.DivRem(columnNumber, 26, out int i);
                flag = true;
                
                ints.Push(i);
                if (columnNumber == 0)
                {
                    break;
                 }
                

            } while (true);
            
            char[] chars = new char[ints.Count];
            int count=ints.Count;

            for(int i=0; i<count ; i++)
            {
                chars[i] = map[ints.Pop()];
            }
            return new string(chars);
        }
        static void Main(string[] args)
        {
            _ConvertToTitle c = new();
            {
                var str = c.ConvertToTitle(27);
                Console.WriteLine(str);
            }
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
            //for (int i = 1; i < 1000; i++)
            //{
            //    var str = c.ConvertToTitle(i);
            //    Console.WriteLine($"{i}={str}");
            //}
        }
    }
}
