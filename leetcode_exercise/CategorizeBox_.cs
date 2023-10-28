using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2525. 根据规则将箱子分类
    /// </summary>
    internal class CategorizeBox_
    {
        public string CategorizeBox(int length, int width, int height, int mass)
        {
            string res = null;
            if (length >= 1_0000 || width >= 1_0000 || height >= 1_0000 || (long)length * width * height >= 10_0000_0000)
            {
                res = "Bulky";
            }
            return (res, mass)
            switch
            {
                (null, >= 100) => "Heavy",
                ({ }, >= 100) => "Both",
                ({ }, _) => res,
                _ => "Neither",
            };
        }
        static void Main(string[] args)
        {
            CategorizeBox_ c = new();
            Console.WriteLine(c.CategorizeBox(3223,1271,2418,749));

        }
    }
}
