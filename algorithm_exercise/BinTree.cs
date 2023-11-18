using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class BinTree
    {

        void PreVisit(Node n)
        {
            Console.WriteLine(n.value);
            if(n.left != null)
                PreVisit(n.left);
            if(n.right != null)
                PreVisit(n.right);

        }

        void MidVisit(Node n)
        {
            if (n.left != null)
                MidVisit(n.left);
            Console.WriteLine(n.value);
            if (n.right != null)
                MidVisit(n.right);
        }

        void PostVisit(Node n)
        {
            if (n.left != null)
            PostVisit(n.left);
            if (n.right != null)
                PostVisit(n.right);
            Console.WriteLine(n.value);
        }
        static void Main()
        {

            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");
            Node G = new Node("G");
            Node H = new Node("H");
            Node I = new Node("I");
            Node J = new Node("J");
            Node K = new Node("K");
            Node L = new Node("L");
            Node M = new Node("M");
            Node N = new Node("N");

            A.left = B;
            A.right = D;
            B.left = E;
            E.right = L;
            D.left = H;
            D.right = J;
            H.left = M;
            H.right = I;

            BinTree tree = new BinTree();
            tree.PostVisit(A);

        }

    }
    class Node
    {
       public string value;
       public Node left;
       public Node right;

        public Node(string value)
        {
            this.value = value;
        }

    }

}
