using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 将长度为len的集合分成 group，要求最小的minSize 最大的maxSize
    /// </summary>
    internal class SplitGroup
    {

        List<List<int>> ints = new List<List<int>>();
        public List<List<int>> Split(int len, int group, int minSize, int maxSize)
        {
            List<int> l = new List<int>();
            Cur(len, group, minSize, maxSize, l);
            return ints;
        }

        void Cur(int len, int group, int minSize, int maxSize, List<int> l)
        {
            --group;
            if (group == 0)
            {
                if (len <= maxSize)
                {
                    List<int> gp = new List<int>(l.ToArray())
                    {
                        len
                    };
                    ints.Add(gp);
                }
                return;
            }
            int max = len - (group) * minSize;
            max = Math.Min(max, maxSize);
            for (int i = minSize; i <= max; ++i)
            {
                l.Add(i);
                Cur(len - i, group, minSize, maxSize, l);
                l.RemoveAt(l.Count - 1);
            }
        }
        static void Main(string[] args)
        {
            SplitGroup s = new();
            var ret = s.Split(11, 4, 1, 3);
            foreach (var i in ret)
            {
                Console.WriteLine(string.Join(",", i));
            }
        }
    }
}
