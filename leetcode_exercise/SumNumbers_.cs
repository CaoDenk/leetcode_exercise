using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 129. 求根节点到叶节点数字之和
    /// </summary>
    internal class SumNumbers_
    {
        public int SumNumbers(TreeNode root)
        {
            long sum=0;

            PreVisit(root,new StringBuilder(),ref sum);

            return (int)sum;
        }
        void PreVisit(TreeNode root, StringBuilder sb, ref long sum)
        {
            sb.Append(root.val);
            if (root.left==null&&root.right==null)
            {
                Console.WriteLine(sb.ToString());
                sum += long.Parse(sb.ToString());
               
            }
           
            if (root.left != null)
            {
                PreVisit(root.left, sb, ref sum);
            }
             
            if(root.right != null)
            {
                PreVisit(root.right, sb, ref sum);
            }
            sb.Remove(sb.Length - 1, 1);


        }
        static void Main(string[] args)
        {
            SumNumbers_ s = new();
            {
                TreeNode root = Utils.Make(new int?[] { 1, 2, 3 });
                Console.WriteLine(s.SumNumbers(root));
            }
            {
                TreeNode root = Utils.Make(new int?[] { 4, 9, 0, 5, 1 });
                Console.WriteLine(s.SumNumbers(root));
            }
        }
    }
}
