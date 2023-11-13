using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 剑指 Offer 33. 二叉搜索树的后序遍历序列
    /// 效率太低
    /// </summary>
    internal class VerifyPostorder_
    {
        public bool VerifyPostorder(int[] postorder)
        {
            bool flag = true;
            int start = 0;
            Recursive(postorder, ref flag,  start, postorder.Length - 1,int.MaxValue);
            return flag;
        }
        /// <summary>
        /// start和end都包含
        /// </summary>
        /// <param name="postorder"></param>
        /// <param name="flag"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="maxLimit"></param>
        /// <param name="minLimit"></param>
        void Recursive(int[] postorder,ref bool flag,int start, int end,int maxLimit) 
        {
            if (!flag)
                return;
            if(start<=end)
            {
                int bigger = end - 1;
                while (bigger >= 0 && postorder[bigger] > postorder[end])
                {
                    if (postorder[bigger]>maxLimit)
                    {
                        flag = false;
                        return;
                    }
                    bigger--;
                }
                if (bigger >= 0)
                {
                    Recursive(postorder, ref flag, bigger+1, end-1, maxLimit);//右子树
                    Recursive(postorder, ref flag, start, bigger, postorder[end]); //左子树
                }
                else
                {
                    Recursive(postorder, ref flag, start, end - 1, maxLimit);
                }
            }

        }
        static void Main(string[] args)
        {
            VerifyPostorder_ v = new();
            Console.WriteLine(v.VerifyPostorder([1, 6, 3, 2, 5]));
            Console.WriteLine(v.VerifyPostorder([1, 3, 2, 6, 5]));
            Console.WriteLine(v.VerifyPostorder([4, 8, 6, 12, 16, 14, 10]));
            Console.WriteLine(v.VerifyPostorder([4, 6, 12, 8, 16, 14, 10]));
        }
    }
}
