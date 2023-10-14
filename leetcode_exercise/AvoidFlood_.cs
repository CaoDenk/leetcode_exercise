using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1488. 避免洪水泛滥
    /// 挖坑
    /// </summary>
    internal class AvoidFlood_
    {
        public int[] AvoidFlood(int[] rains)
        {
            int[] res=new int[rains.Length];
            bool[] visited=new bool[rains.Length];
            HashSet<int> filled=new HashSet<int>();
            for(int i=0; i < rains.Length;++i)
            {
                if (rains[i]!=0)
                {
                    if (filled.Contains(rains[i]))
                    {
                        return Array.Empty<int>();
                    }
                    filled.Add(rains[i]);
                    res[i] = -1;

                }else
                {
                    res[i] = 1;
                    for (int j=i;j<rains.Length;++j)
                    {
                        if (rains[j]!=0&&!visited[j]&&filled.Count>0&&filled.Contains(rains[j]))
                        {
                            visited[i] = true;
                            filled.Remove(rains[j]);
                            res[i] = rains[j];
                            break;
                        }

                    }

                }
            }

            return res;
        }

        static void Main(string[] args)
        {
            AvoidFlood_ a = new();
            var res = a.AvoidFlood(new int[] { 69, 0, 0, 0, 69 });
            Console.WriteLine(string.Join(",",res));
        }


    }
}
