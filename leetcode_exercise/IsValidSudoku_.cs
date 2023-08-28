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
        
           for(int i=0;i<board.Length;++i)
            {
                for(int j = 0; j < board[i].Length;++j)
                {
                    if (board[i][j] == '.') continue;
                    char c= board[i][j];
                    board[i][j]= '.';
                    if (!IsValid(i, j, c,board))
                        return false;
                    board[i][j] = c;
                }
            }
            return true;
        }
        bool IsValid(int row, int col, char val, char[][] board)
        {
            for (int i = 0; i < 9; i++)
            { // 判断行里是否重复
                if (board[row][i] == val)
                {
                    return false;
                }
            }
            for (int j = 0; j < 9; j++)
            { // 判断列里是否重复
                if (board[j][col] == val)
                {
                    return false;
                }
            }
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = startRow; i < startRow + 3; i++)
            { // 判断9方格里是否重复
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (board[i][j] == val)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
