using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 79. 单词搜索
    /// </summary>
    internal class Exist_
    {
        public bool Exist(char[][] board, string word)
        {
            for(int i=0;i<board.Length;++i)
            {
                for(int j = 0; j < board[0].Length;++j)
                {
                    if (board[i][j] == word[0])
                    {
                        bool[,] visited = new bool[board.Length, board[0].Length];
                        visited[i, j] = true;
                        if(Recursive(i,j,board ,word,1,visited))
                        {
                            return true;
                        }
                        visited[i, j] = false;
                    }
                }
            }

            return false;
        }

   
 
        bool Recursive(int i, int j, char[][] board, string word, int offset, bool[,] visited)
        {
            if (word.Length == offset)
                return true;

            if (i - 1 >= 0 && board[i - 1][j] == word[offset] && !visited[i - 1, j])
            {
                visited[i - 1, j] = true;
                bool ret = Recursive(i - 1, j, board, word, offset + 1, visited);
                if (ret) return true;
                visited[i - 1, j] = false;

            }
            if (i + 1 < board.Length && board[i + 1][j] == word[offset] && !visited[i + 1, j])
            {
                visited[i + 1, j] = true;
                bool ret = Recursive(i + 1, j, board, word, offset + 1, visited);
                if (ret) return true;
                visited[i + 1, j] = false;
            }
            if (j + 1 < board[0].Length && board[i][j + 1] == word[offset] && !visited[i, j + 1])
            {
                visited[i, j + 1] = true;
                bool ret = Recursive(i, j + 1, board, word, offset + 1, visited);
                if (ret) return true;
                visited[i, j + 1] = false;
            }
            if (j - 1 >= 0 && board[i][j - 1] == word[offset] && !visited[i, j - 1])
            {
                visited[i, j - 1] = true;
                bool ret = Recursive(i, j - 1, board, word, offset + 1, visited);
                if (ret) return true;
                visited[i, j - 1] = false;
            }

            return false;
        }
        static void Main(string[] args)
        {
            Exist_ e = new();
            //{
            //    //A","B","C","E"],["S","F","E","S"],["A","D","E","E
            //    char[][] board = new char[3][];
            //    board[0] = new char[] { 'A', 'B', 'C', 'E' };
            //    board[1] = new char[] { 'S', 'F', 'C', 'S' };
            //    board[2] = new char[] { 'A', 'D', 'E', 'E' };
            //    Console.WriteLine(e.Exist(board, "ABCB"));
            //}
            {
                //A","B","C","E"],["S","F","E","S"],["A","D","E","E
                char[][] board = new char[3][];
                board[0] = new char[] { 'A', 'B', 'C', 'E' };
                board[1] = new char[] { 'S', 'F', 'E', 'S' };
                board[2] = new char[] { 'A', 'D', 'E', 'E' };
                Console.WriteLine(e.Exist(board, "ABCESEEEFS"));
            }
            //{
            //    char[][] board=new char[1][];
            //    board[0] = new char[] { 'a', 'b' };
            //    Console.WriteLine(e.Exist(board, "ab"));

            //}
        }
    }
}
