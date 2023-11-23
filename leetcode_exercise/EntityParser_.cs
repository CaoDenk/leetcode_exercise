using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1410. HTML 实体解析器
    /// </summary>
    internal class EntityParser_
    {
        public string EntityParser(string text)
        {
            string[] str = { "quot;" , "apos;" , "amp;", "gt;", "lt;", "frasl;" };
            char[] rep = { '"', '\'', '&', '>', '<', '/' };

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < text.Length;)
            {
                if (text[i]!='&' )
                {
                    sb.Append(text[i++]);
                    continue;
                }
              
                for(int j = 0;j<str.Length;j++)
                {
                    if (text[(i+1)..].StartsWith(str[j]))
                    {
                        sb.Append(rep[j]);
                        i += str[j].Length+1;
                        goto Label;
                    }
                }

                sb.Append(text[i++]);
            Label:
                continue;
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            EntityParser_ e = new();
            {
                string text = "&amp; is an HTML entity but &ambassador; is not.";
                Console.WriteLine(e.EntityParser(text));
            }
            {
                string text = "and I quote: &quot;...&quot;";
                Console.WriteLine(e.EntityParser(text));
            }
            {
                string text = "&amp; is an HTML entity but &ambassador; is not.";
                Console.WriteLine(e.EntityParser(text));
            }
        }
    }
}
