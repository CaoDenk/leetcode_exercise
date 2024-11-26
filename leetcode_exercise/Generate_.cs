using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 118. 杨辉三角
    /// </summary>
    internal class Generate_
    {
        public IList<IList<int>> Generate(int numRows)
        {
           

            List<IList<int>> l= new List<IList<int>>();
            if (numRows == 0)
                return l;
            l.Add(new List<int>() { 1 });
            if (numRows == 1)
            {          
                return l;
            }
            l.Add(new List<int>() { 1, 1 });
            if (numRows == 2)
            {
                return l;
            }

            for (int i = 2; i < numRows;++i)
            {
                List<int> ints = new List<int>() { 1};
                
                for(int j = 0;j<i-1;++j)
                {
                    ints.Add(l[^1][j] + l[^1][j + 1]);
                }
                ints.Add(1);
                l.Add(ints);
            }
            return l;
        }

    }
}
