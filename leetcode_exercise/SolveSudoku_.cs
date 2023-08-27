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
    internal class SolveSudoku_
    {
        public void SolveSudoku(char[][] board)
        {
            BackTracing(board);
        }

        bool BackTracing(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {

                    if (board[i][j] != '.') continue;
                    for (char c = '1'; c <= '9'; ++c)
                    {

                        bool isvalid = IsValid(i, j, c, board);
                        if (isvalid)
                        {
                            board[i][j] = c;
                            bool success= BackTracing(board);
                            if (success)
                                return true;
                            board[i][j] = '.';
                        }
                    }
                }
            }
            return true;
        }

        bool IsValid(int row,int col, char val,char[][] board)
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
