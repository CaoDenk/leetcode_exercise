using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class SplitNum_
    {
        public int SplitNum(int num)
        {
            List<int> list = new List<int>();
            do
            {
                num = Math.DivRem(num, 10, out int rem);
                list.Add(rem);
            } while (num!=0);
            if (list.Count == 2)
                return list[0] + list[1];
            list.Sort();
            int splitLen = Math.DivRem(list.Count, 2, out int remainder);
            if(remainder!=0) return (int)Math.Pow(10, splitLen) * list[0] + SplitNum(list, 1);
            return SplitNum(list,0);
            
        }
        int SplitNum(List<int> list,int offset)
        {
            if(list.Count-offset==2)
                return list[offset] + list[offset+1];
            int num1 = 0;
            int num2 = 0;    
            while(offset < list.Count)
            {
                num1 = num1 * 10 + list[offset++];
                if (offset >= list.Count)
                    break;
                num2 = num2 * 10 + list[offset++];
            }
            return num1 + num2;
        }

        static void Main(string[] args)
        {
            SplitNum_ s = new();
            Console.WriteLine(s.SplitNum(4325));
            Console.WriteLine(s.SplitNum(687));
            Console.WriteLine(s.SplitNum(11));
            Console.WriteLine(s.SplitNum(958351976));
        }
    }
}
