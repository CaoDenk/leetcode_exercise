using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class BNodeUtils
    {
        static void PreVisit(BNode node)
        {
            if(node == null) return;
            Console.WriteLine($"[val={node.val},level={node.level}]");
            PreVisit(node.left);
            PreVisit(node.right);
        }
        public static void PreVisitNode(BNode node)
        {
            PreVisit(node);
            //Console.WriteLine();
        }

    }
}
