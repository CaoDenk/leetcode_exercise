using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _GenerateParenthesis
    {
        List<string> result = new List<string>();
        public IList<string> GenerateParenthesis(int n)
        {
          
            StringBuilder sb = new StringBuilder();
            solve(0,2*n, sb);

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count">左括号数量</param>
        /// <param name="n"></param>
        /// <param name="sb"></param>
        void solve(int count,int n,StringBuilder sb)
        {
            if(sb.Length == n)
            {
  
                result.Add(sb.ToString());
                 //   sb = new StringBuilder();
                    return;
                 
            }
            if (count > 0)
            {
                sb.Append(')');

                solve(count - 1, n, sb);
                sb.Remove(sb.Length - 1,1);

            }
            if (n-sb.Length >count)
            {
                sb.Append('(');
               
                solve(count+1,n,sb);
                sb.Remove(sb.Length - 1, 1);
            }

         


        }

        //public void solve2(int leftCount,int n,StringBuilder sb)
        //{

        //    if (sb.Length < n)
        //    {
        //        sb.Append('(');
        //        solve2(leftCount,n,sb);
                
        //    }

           
       
        //    if (sb.Length < n)
        //    {
        //        return;
        //    }


        //    sb.Append(')');
        //    solve2(leftCount, n, sb);
            
           

        //}

        public static void Main()
        {
            _GenerateParenthesis g = new();
            g.GenerateParenthesis(2);
            foreach(var s in g.result)
            {

                Console.WriteLine(s);
            }

        }


    }
}
