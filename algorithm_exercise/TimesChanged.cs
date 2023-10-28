using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class TimesChanged
    {
        class Graph
        {
            public List<Graph> next;
            public int inNumber;

        }

        List<Graph> Make(int[] dep)
        {
            Graph[] graphics = new Graph[dep.Length];
            for (int i = 0;i<dep.Length;i++)
            {
                int prev = dep[i];
                graphics[prev].next.Add(graphics[i]);
                graphics[i].inNumber++;
            }
            return graphics.ToList();
        }
        public int[] GetChanged(int[] dep)
        {

            for(int i = 0;i<dep.Length;++i)
            {

            }


            return default;
        }
    }
}
