using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    ///283. 移动零给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
    /// </summary>
    internal class _MoveZeroes
    {
        public void MoveZeroes2(int[] nums)
        {

            LinkedList<int> list = new LinkedList<int>(nums);
            int count = 0;

            while(list.Remove(0))
            {
                count++;
            }
            for(int i = 0; i < count;++i)
            {
                list.AddLast(0);
            }
            list.ToArray().CopyTo(nums,0);

        }
        public void MoveZeroes(int[] nums)
        {
            int[] backup=new int[nums.Length];
            int j=0;
            for(int i=0; i<nums.Length; i++)
            {
                if (nums[i]!=0)
                {
                    backup[j] = nums[i];
                    j++;
                }
            }

            Array.Copy(backup, 0, nums, 0, j);
            Array.Fill(nums,0,j,nums.Length-j);
        }
    }
}
