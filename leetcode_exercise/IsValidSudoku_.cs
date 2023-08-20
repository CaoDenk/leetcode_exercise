using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 37. 解数独
    /// 挖坑
    /// </summary>
    internal class IsValidSudoku_
    {
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<char> set = new HashSet<char>();
            //先判断行
            foreach (char[] b in board)
            {
                //判断行
             
                foreach (char c in b)
                {
                 
                    if (c == '.')
                        continue;
                    if(set.Contains(c))
                        return false;
                    set.Add(c);
                    
                }
                set.Clear();
            }
            for(int row=0; row<board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == '.')
                        continue;

                    if (set.Contains(board[row][col]))
                        return false;
                    set.Add(board[row][col]);


                }
            }
            //判断列
           


            return true;
        }
    }
}
