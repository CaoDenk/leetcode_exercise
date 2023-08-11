using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class LRUCache
    {
        Dictionary<int, DLinkedNode> cache=new();

        class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;
            public DLinkedNode() { }
            public DLinkedNode(int _key, int _value) { key = _key; value = _value; }
        }
        private int size;
        private int capacity;
        private DLinkedNode head, tail;




        public LRUCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;
            // 使用伪头部和伪尾部节点
            head = new DLinkedNode();
            tail = new DLinkedNode();
            head.next = tail;
            tail.prev = head;

        }

        public int Get(int key)
        {
            DLinkedNode node = cache.GetValueOrDefault(key);
            if (node == null)
            {
                return -1;
            }
            // 如果 key 存在，先通过哈希表定位，再移到头部
            MoveToHead(node);
            return node.value;
        }

        public void Put(int key, int value)
        {

            if (cache.TryGetValue(key, out DLinkedNode node))
            {
                // 如果 key 不存在，创建一个新的节点
                DLinkedNode newNode = new DLinkedNode(key, value);
                // 添加进哈希表
                cache.Add(key, newNode);
                // 添加至双向链表的头部
                AddToHead(newNode);
                ++size;
                if (size > capacity)
                {
                    // 如果超出容量，删除双向链表的尾部节点
                    DLinkedNode tail = RemoveTail();
                    // 删除哈希表中对应的项
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                // 如果 key 存在，先通过哈希表定位，再修改 value，并移到头部
                node.value = value;
                MoveToHead(node);
            }


        }
        private void AddToHead(DLinkedNode node)
        {
            node.prev = head;
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
        }

        private void RemoveNode(DLinkedNode node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void MoveToHead(DLinkedNode node)
        {
            RemoveNode(node);
            AddToHead(node);
        }

        private DLinkedNode RemoveTail()
        {
            DLinkedNode res = tail.prev;
            RemoveNode(res);
            return res;
        }


    }
}
