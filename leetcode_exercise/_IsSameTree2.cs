﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _IsSameTree2
    {

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
                return p == q;
            if (p.val == q.val)
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            else return false;

        }

    }
}
