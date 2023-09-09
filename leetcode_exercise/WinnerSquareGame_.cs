using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1510. 石子游戏 IV
    /// </summary>
    internal class WinnerSquareGame_
    {
        public bool WinnerSquareGame(int n)
        {
            if(n==1)
                return true;
            if(n==2) return false;
            bool[] win= new bool[n+1];
            int[] square = new int[n];
            int lastSquare = 0;
            for (int i = 1; lastSquare <= n; ++i)
            {
                lastSquare += (i << 1) - 1;
                square[i] = lastSquare;
            }
            for (int i=1;i<=n;++i)
            {    
               
                for (int j=1;j*j<=i;++j)
                {
                    if (!win[i - j*j])
                    {                      
                        win[i] = true;
                        break;
                    }
                }
                
            }
            return win[^1];
        }

        static void Main(string[] args)
        {
            WinnerSquareGame_ w = new();
            //Console.WriteLine($"{w.WinnerSquareGame(2)}");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 1; i <= 20000; i++)
            {
                w.WinnerSquareGame(i);
               // Console.WriteLine($"{i},{w.WinnerSquareGame(i)}");
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }
    }
}
