using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2698. 求一个整数的惩罚数
    /// copy
    /// </summary>
    internal class PunishmentNumber_
    {
       
            public int PunishmentNumber(int n)
            {
                int res = 0;
                for (int i = 1; i <= n; i++)
                {
                    string s = (i * i).ToString();
                    if (DFS(s, 0, 0, i))
                    {
                        res += i * i;
                    }
                }
                return res;
            }

            public bool DFS(string s, int pos, int tot, int target)
            {
                if (pos == s.Length)
                {
                    return tot == target;
                }
                int sum = 0;
                for (int i = pos; i < s.Length; i++)
                {
                    sum = sum * 10 + s[i] - '0';
                    if (sum + tot > target)
                    {
                        break;
                    }
                    if (DFS(s, i + 1, sum + tot, target))
                    {
                        return true;
                    }
                }
                return false;
            }

        static void Main(string[] args)
        {
            PunishmentNumber_ p = new();
            {
                int res = p.PunishmentNumber(1478);
                Console.WriteLine(res);
            }
            
        }

    }
}
