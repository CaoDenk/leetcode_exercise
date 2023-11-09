using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 22. 括号生成
    /// </summary>
    internal class _GenerateParenthesis
    {
       
        public IList<string> GenerateParenthesis(int n)
        {
          

            List<string> result = new List<string>();
            GenerateParenthesis(n,0,0,result,new StringBuilder());
            return result;
        }
        void GenerateParenthesis(int n,int leftCount,int rightCount,IList<string> list,StringBuilder sb)
        {
            if (sb.Length == n * 2)
            {
                list.Add(sb.ToString());
                return;
            }
            if(leftCount==0)
            {
                sb.Append('(');
                GenerateParenthesis(n, leftCount + 1,rightCount, list, sb);
                sb.Remove(sb.Length - 1, 1);
            }
            else if(leftCount<n) 
            {
                sb.Append('(');
                GenerateParenthesis(n, leftCount+1,rightCount, list, sb);
                sb.Remove(sb.Length - 1, 1);
                if(leftCount>rightCount)
                {
                    sb.Append(')');
                    GenerateParenthesis(n, leftCount, rightCount + 1, list, sb);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            else
            {
                int start = sb.Length;
                sb.Append(Enumerable.Repeat(')',2*n-start).ToArray());
                GenerateParenthesis(n, leftCount, rightCount+1, list, sb);
                sb.Remove(start, 2 * n - start);
            }

        }

       

 
        public static void Main()
        {
            _GenerateParenthesis g = new();
            var res= g.GenerateParenthesis(3);
            foreach(var s in res)
            {

                Console.WriteLine(s);
            }

        }


    }
}
