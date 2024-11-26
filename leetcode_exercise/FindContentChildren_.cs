using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeature
{
    /// <summary>
    /// 455. 分发饼干
    /// </summary>
    internal class FindContentChildren_
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);//胃口值
            Array.Sort(s);//饼干大小
            int j=0;
            int count = 0;
            for(int i=0;i<g.Length;++i)
            {
                for(;j<s.Length;++j)
                {
                    if (s[j] >= g[i])
                    {
                        ++count;
                        ++j;
                        break;
                    }
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            FindContentChildren_ f = new();
            int[] g=[1, 2, 3];
            int[] s=[1, 1];
            Console.WriteLine(f.FindContentChildren(g,s));
        }
    }
}
