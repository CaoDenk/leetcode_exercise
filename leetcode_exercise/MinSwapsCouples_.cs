using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 765. 情侣牵手
    /// 挖坑
    /// </summary>
    internal class MinSwapsCouples_
    {
        public int MinSwapsCouples(int[] row)
        {
            List<(int, int)> wrong = new();
            for(int i=0;i<row.Length;i+=2)
            {
                if (!IsPaired(row[i], row[i+1]))
                {
                    wrong.Add((row[i], row[i+1])); 
                }
            }
            if (wrong.Count == 0) return 0;

            int mulWrong = 0;
            while(wrong.Count > 0)
            {
                for (int j = wrong.Count - 1; j >= 0; j--)
                {
                    for (int i=j-1;  i>=0; --i)
                    {
                        if (j >= wrong.Count)
                            break;
                        if(WrongHandle(wrong,i,j)>0)
                        {
                            mulWrong++;
                        }
                       
                    }
                }
            }
          
            return mulWrong;
        }
        bool IsPaired(int id1,int id2)=> (id1^1)==id2;
        int  WrongHandle(List<(int,int)>wrong,int i,int j )
        {
            switch((IsPaired(wrong[i].Item1, wrong[j].Item1), IsPaired(wrong[i].Item2, wrong[j].Item2)))
            {
                case (true, true):
                    wrong.RemoveAt(j);
                    wrong.RemoveAt(i);
                    return 2;
                case (true, false):
                    wrong[i]= (wrong[i].Item2, wrong[j].Item2);
                    wrong.RemoveAt(j);
                    return 1;
                case (false, true):
                    wrong[i] = (wrong[i].Item1, wrong[j].Item1);
                    wrong.RemoveAt(j);
                    return 1;
                default:
                    break;
            }

            switch ((IsPaired(wrong[i].Item1, wrong[j].Item2), IsPaired(wrong[i].Item2, wrong[j].Item1)))
            {
                case (true, true):
                    wrong.RemoveAt(j);
                    wrong.RemoveAt(i);
                    return 2;
                case (true, false):
                    wrong[i] = (wrong[i].Item2, wrong[j].Item1);
                    wrong.RemoveAt(j);
                    return 1;
                case (false, true):
                    wrong[i] = (wrong[i].Item1, wrong[j].Item2);
                    wrong.RemoveAt(j);
                    return 1;
                default:
                    break;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            MinSwapsCouples_ m = new();
            {
                int[] row = [0, 2, 1, 3];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [3, 2, 0, 1];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [5, 4, 2, 6, 3, 1, 0, 7];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [1, 4, 0, 5, 8, 7, 6, 3, 2, 9];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [10, 7, 4, 2, 3, 0, 9, 11, 1, 5, 6, 8];//=4
                Console.WriteLine(m.MinSwapsCouples(row));
            }
            {
                int[] row = [4, 6, 1, 3, 5, 7, 12, 13, 15, 11, 0, 10, 2, 8, 9, 14];
                Console.WriteLine(m.MinSwapsCouples(row));
            }
        }
    }
}
