using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 119. 杨辉三角 II
    /// </summary>
    internal class GetRow_
    {
        public IList<int> GetRow(int rowIndex)
        {
            
            List<int> l = new List<int>() { 1 };
            if (rowIndex == 0)
                return l;
            l.Add(1);
            if (rowIndex == 1)
            {
                return l;
            }
            l = new List<int>() { 1, 2, 1 };
            if (rowIndex == 2)
            {
                return l;
            }

            for (int i = 1; i <= rowIndex; ++i)
            {
                List<int> ints = new List<int>() { 1 };

                for (int j = 0; j < i - 1; ++j)
                {
                    ints.Add(l[j] + l[j + 1]);
                }
                ints.Add(1);
                l = ints;
            }
            return l;
           
        }

        public IList<int> Generate(int numRows)
        {


            List<int> l = new List<int>() { 1};
            if (numRows == 0)
                return l;
            l.Add(1);
            if (numRows == 1)
            {
                return l;
            }
            //l.Add(new List<int>() { 1 });
            l=new List<int>() { 1,2,1};
            if (numRows == 2)
            {
                return l;
            }

            for (int i = 2; i < numRows; ++i)
            {
                List<int> ints = new List<int>() { 1 };

                for (int j = 0; j < i - 1; ++j)
                {
                    ints.Add(l[j] + l[j + 1]);
                }
                ints.Add(1);
                l = ints;
            }
            return l;
        }

        static void Main(string[] args)
        {
            GetRow_ g = new();
            {
                var ret = g.GetRow(3);
                Console.WriteLine(string.Join(",",ret));
            }
        }
    }
}
