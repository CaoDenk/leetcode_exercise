using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{

    /// <summary>
    /// 解析力扣里面的[[]]数组
    /// </summary>
    internal class ParseMatrix
    {
        static object ParseString(string expression,Type type)
        {
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '[')
                {

                }
            }
            return null;
        }

        object ParseArray(string expression,ref int i,Type type)
        {
            List<object> list = new List<object>();
            for (; i < expression.Length; i++)
            {
                if (char.IsWhiteSpace(expression[i]))
                    continue;
                switch(expression[i])
                {


                    case '[':
                        ++i;
                        list.Add(ParseArray(expression, ref i,type));
                        break;
                    case ']':
                        return list;

                    default:
                        StringBuilder sb = new StringBuilder();
                        sb.Append(expression[i]);
                        while (expression[i + 1] != ',' && expression[i+1]!=']')
                        {
                            ++i;
                            sb.Append(expression[i]);
                        }
                 
                        break;
                        
                }


                }
            
            return null;

        }



        public static T[][] Parse2DString<T>(string expression)
        {

            List<T[]> list = new();



            return list.ToArray();
        }

        public static T[] Parse1DString<T>(string expression)
        {
            List<T> list = new();



            return list.ToArray();
        }
    }
}
