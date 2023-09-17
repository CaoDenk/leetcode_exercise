using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise2
{
    /// <summary>
    /// 146. LRU 缓存
    /// </summary>
    /// 

    class Node
    {
        public Node pre;
        public Node next;
        public int value;
        public int key;
        public Node(int key,int value) 
        {
            this.key = key;
            this.value=value;
        } 

    }
    public class LRUCache
    {
        
        int capacity;
        Node hair=new Node(0,0);
        Node tail=new Node(0,0);
        Dictionary<int, Node> map=new Dictionary<int, Node>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            hair.next = tail;
            tail.pre = hair;
        }

        public int Get(int key)
        {
            if(map.TryGetValue(key,out var node))
            {
                Remove(node);
                AddTail(node);
                return node.value;
            }else return -1;
        }

        public void Put(int key, int value)
        {
            
            if(map.TryGetValue(key,out var node))
            {
                Remove(node);
                node.value = value;
                AddTail(node);
            }
            else if(map.Count >= capacity)
            {
                Node head = hair.next;
                Remove(head);
                map.Remove(head.key);

                head.key = key;
                head.value = value;
                map[key] = head;
                AddTail(head);

            }else
            {
                Node n = new Node(key, value);
                AddTail(n);
                map[key] = n;
            }
        }
        void AddTail(Node n)
        {
            var prenode = tail.pre;
            prenode.next = n;
            n.pre = prenode;

            n.next= tail;
            tail.pre= n;

        }
        void Remove(Node n)
        {
            Node pre = n.pre;
            Node next = n.next;
            pre.next = next;
            next.pre = pre;
        }

        //static void Main(string[] args)
        //{   //["LRUCache","put","put","get","put","get","put","get","get","get"]
        //    //[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]

        //    LRUCache l = new(2);
        //    l.Put(1, 1);
        //    l.Put(2, 2);
        //    Console.WriteLine(l.Get(1));
        //    l.Put(3, 3);
        //    Console.WriteLine(l.Get(2));
        //}
    }
}
