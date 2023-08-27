using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _SolveNQueens
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            bool[,] map=new bool[n,n];
            List<IList<string>>  ans=new List<IList<string>>();
            BackTracing(ans,0, map,new bool[n]);
            return ans;
        }

        void BackTracing(List<IList<string>> ans,int row, bool[,] map, bool[] colFilled)
        {
            if (row >= colFilled.Length)
            {
                ans.Add(MapToList(map));
                return;
            }
            for(int i = 0; i < colFilled.Length; i++)
            {
                if (colFilled[i])
                {
                    continue;
                }else
                {
                    if(IsSafe(map,row,i))
                    {
                        map[row,i] = true;
                        colFilled[i] = true;
                        BackTracing(ans,row+1,map,colFilled);
                        map[row, i] = false;
                        colFilled[i] = false;
                    }
                    else
                    {
                        continue;
                    }
                }

            }  
        }

        bool IsSafe(bool[,] map,int i,int j)
        {

            {
                int m = i, n = j; //判断45度
                while (m >= 0 && n < map.GetLength(0))
                {

                    if (map[m, n])
                        return false;
                    --m;
                    ++n;
                }

            }
            {
                int m = i, n = j; //判断135度
                while (m >= 0 && n >=0)
                {

                    if (map[m, n])
                        return false;
                    --m;
                    --n;
                }
            }

            return true; ;

        }

        List<string> MapToList(bool[,] map)
        {
            StringBuilder sb = new StringBuilder(map.GetLength(0));
            List<string> res = new();
            for(int i=0; i<map.GetLength(0); i++)
            {
                for(int j=0;j<map.GetLength(1);++j)
                {
                    if (map[i,j])
                    {
                        sb.Append('Q');

                    }else
                    {
                        sb.Append('.');
                    }
                }
                res.Add(sb.ToString());
                sb.Clear();
            }
            return res ;
        }

        static void Main(string[] args)
        {
            _SolveNQueens s = new();
            {
                var res = s.SolveNQueens(4);
                foreach (var i in res)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
            {
                var res = s.SolveNQueens(3);
                foreach (var i in res)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
        }       

    }
}
