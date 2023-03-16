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

            HashSet<int> startCol = new HashSet<int>();
            Action<int> ac= (int startCol) =>
            {
                List<(int, int)> l = new List<(int, int)>();
                bool[,] map = new bool[n, n];

                map[0,startCol] = true;

                for (int i = 1; i < n; ++i)
                {

                    for (int j = 0; j < n; ++j)
                    {
                        int errloc = 0;
                        if (!IsSafe(map, i, j))
                        {
                            ++errloc;
                            if (errloc == n)
                            {
                                l.Clear();
                                return;
                            }

                        }
                        else
                        {
                            map[i, j] = true;
                            //l.Add((i, j));
                        }

                    }

                }
            };
            for(int k=0; k < n; ++k)
            {
                ac(k);
            }
          
            
            return null;

        }

        void  recur(bool[,] map,int startRow)
        {

            for(int q=0;q<map.GetLength(1);++q)
            {
                int errloc = 0;
                if (!IsSafe(map, startRow, q))
                {
                    ++errloc;
                    if (errloc == map.Rank)
                    {
                        //l.Clear();
                        return;
                    }

                }
                else
                {
                    map[startRow, q] = true;

                    //l.Add((i, j));
                }

            }


        }

        bool IsSafe(bool[,] map,int i,int j)
        {
            //bool ret = true;
            for(int row = 0; row < map.GetLength(0);++row)
            {
                if (map[row, j])
                {
                    return false;
                }
            }
            for (int col = 0; col < map.GetLength(1); ++col)
            {
                if (map[i, col])
                {
                    return false;
                }
            }

            {
                int m = i, n = j;
                while(m>=0&&n>=0)
                {

                    if (map[m, n])
                        return false;
                    --m;
                    --n;
                }

            }

            {
                int m = i, n = j;
                while (m >= 0 && n<map.GetLength(1))
                {

                    if (map[m, n])
                        return false;
                    --m;
                    ++n;
                }

            }
            {
                int m = i, n = j;
                while (m < map.GetLength(0) && n >=0)
                {

                    if (map[m, n])
                        return false;
                    ++m;
                    --n;
                }

            }

            {
                int m = i, n = j;
                while (m < map.GetLength(0) && n <map.GetLength(1))
                {

                    if (map[m, n])
                        return false;
                    ++m;
                    ++n;
                }
            }

            return true; ;

        }


    }
}
