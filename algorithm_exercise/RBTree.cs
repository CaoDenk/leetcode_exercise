using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{


    internal class RBTree
    {
        RBTreeNode root;
        static readonly RBTreeNode TNULL=new RBTreeNode(0,color:Color.BLACK);

        public RBTree()
        {
            root = TNULL;
        }
        public void Insert(int key)
        {
            RBTreeNode node = new RBTreeNode(key)
            {
                left = TNULL,
                right = TNULL,
            };
            RBTreeNode y = null;
            RBTreeNode x = root;
            while(x!=TNULL)
            {
                y = x;
                if (node.key < x.key)
                    x = x.left;
                else if (node.key > x.key)
                    x = x.right;
                else
                    return;//相等不用做操作
            }
            node.parent = y; //更新parent指向，
            if(y==null)
            {
                root = node;
            }else if(node.key<y.key) 
            {
                y.left = node;
            }else
            {
                y.right= node;
            }
            if(node.parent==null)
            {
                node.color = Color.BLACK;
                return;
            }
            if (node.parent.parent == null)
                return;
            FixInsert(node);
        }

        private void FixInsert(RBTreeNode k) //消除红红相连
        {
            RBTreeNode u;//记录叔叔结点
            while(k.parent.color==Color.RED)
            {
                if(k.parent==k.parent.parent.right)//说明叔叔结点在右边
                {
                    u = k.parent.parent.left;
                    if(u.color==Color.RED) //如果叔叔和父亲结点都是红色
                    {
                        k.parent.color = Color.BLACK;//父亲结点变黑
                        u.color = Color.BLACK;
                        k.parent.parent.color = Color.RED;//爷爷结点变红
                        k = k.parent.parent;  //让k指向爷爷结点 递归
                    }else //叔叔结点不为红色(那么就是nil/TNULL)
                    {
                        if(k==k.parent.left)
                        {
                            k = k.parent;
                            RightRotate(k);
                        }
                        k.parent.color = Color.BLACK;
                        k.parent.parent.color= Color.RED;
                        LeftRotate(k.parent.parent);

                    }
                }else
                {
                    u = k.parent.parent.right;
                    if(u.color== Color.RED)
                    {
                        k.parent.color = Color.BLACK;
                        u.color = Color.BLACK;
                        k.parent.parent.color=Color.RED;
                        k=k.parent.parent;

                    }else
                    {
                        if (k == k.parent.right)
                        {
                            k=k.parent;
                            LeftRotate(k);
                        }

                        k.parent.color = Color.BLACK;
                        k.parent.parent.color = Color.RED;
                        RightRotate(k.parent.parent);

                    }
                }
                if (k == root)
                    break;
            }
            root.color=Color.BLACK;


        }
        void RightRotate(RBTreeNode x)
        {
            var y = x.left;
            x.left = y.right;
            if(y.right!=null)
            {
                y.right.parent = x;
            }
            y.parent = x.parent;
            if (x.parent == null) //如果x的parent为null 说明x为root 经调整后y变成根，
                root = y;
            else if (x.parent.left==x)
            {
                x.parent.left = y;
            }else
                x.parent.right = y;
            y.right = x;
            x.parent = y;

        }
        void LeftRotate(RBTreeNode x)
        {
            var y = x.right;
            x.right = y.left;
            if (y.left != TNULL)
                y.left.parent = x;
            y.parent = x.parent;
            if (x.parent == null)
                root = y;
            else if (x == x.parent.left)
                x.parent.left = y;
            else
                x.parent.right = y;
            y.left = x;
            x.parent = y;

        }

        RBTreeNode FindNode(int key)
        {
            var current = root;
            while(current != TNULL)
            {
                if (key < current.key)
                {
                    current = current.left;
                }
                else if (key > current.key)
                {
                    current = current.right;
                }
                else
                    return current;

            }
            return TNULL;
        }
        void Delete(int key)
        {
            var z=FindNode(key);
            if (z == TNULL)//没找到
                return;
            var y = z;
            var yOriginalColor=y.color;
            RBTreeNode x;
            //删除只有一个叶子结点的,进行交换
            if(z.left==TNULL)
            {
                x = z.right;
                Transplant(z, z.right);
            }else if(z.right==TNULL)
            {
                x=z.left;
                Transplant(z,z.left);
            }else //左右孩子结点都不为空，
            {
                y= GetMin(z.right);//找到右结点最小的，作为后继(找到左边最大的也可以)  //按照bst那样处理
                yOriginalColor=y.color;//?
                x = y.parent;
                if(y.parent==z)
                {
                    x.parent = y;
                }else
                {
                    Transplant(y,y.right);// y只可能有右结点
                    y.right = z.left;
                    y.left.parent = y;
                    y.color = z.color;
                }
            }
            if(yOriginalColor==Color.BLACK)
            {
                FixDelete(x);
            }


        }

        private void FixDelete(RBTreeNode x)
        {
            throw new NotImplementedException();
        }

        private void Transplant(RBTreeNode u, RBTreeNode v)//交换
        {
            //如果u的parent=TNULL
            //  u的
            if(u.parent==TNULL)
            {
                root = v;
            }else if(u==u.left.parent)
            {
                 u.left.parent= v ;
            }else
            {
                u.right.parent= v ;
            }
            v.parent = u;
        }

        RBTreeNode GetMin(RBTreeNode node)
        {
            while(node.left!=TNULL)
            {
                node=node.left;
            }
            return node;
        }
    }
}
