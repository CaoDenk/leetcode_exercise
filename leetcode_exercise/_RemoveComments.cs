using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 722. 删除注释
    /// </summary>
    internal class _RemoveComments
    {
      
            public IList<string> RemoveComments(string[] source)
            {
                List<string> ans = new List<string>();
                bool isBlock = false;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < source.Length; ++i)
                {

                    for (int j = 0; j < source[i].Length; j++)
                    {
                        if (!isBlock)
                        {
                            if (source[i][j] == '/')
                            {
                                if (j + 1 < source[i].Length)
                                {

                                    if (source[i][j + 1] == '/')
                                    {
                                        if (sb.Length > 0)
                                        {
                                            ans.Add(sb.ToString());
                                            sb.Clear();
                                        }
                                        break;
                                    }
                                    if (source[i][j + 1] == '*')
                                    {
                                        ++j;
                                        isBlock = true;
                                    }
                                    else
                                        sb.Append(source[i][j]);
                                }
                                else
                                {
                                    sb.Append(source[i][j]);
                                    ans.Add(sb.ToString());
                                    sb.Clear();
                                }

                            }
                            else
                                sb.Append(source[i][j]);
                            if (j + 1 == source[i].Length && sb.Length > 0)
                            {
                                ans.Add(sb.ToString());
                                sb.Clear();
                            }
                        }
                        else
                        {
                            if (source[i][j] == '*')
                            {
                                if (j + 1 < source[i].Length&& source[i][j + 1] == '/')
                                {
                                        ++j;
                                        isBlock = false;
                                }
                                if (j + 1 == source[i].Length && sb.Length > 0)
                                {
                                    ans.Add(sb.ToString());
                                    sb.Clear();
                                }
                            }
                        }
                    }
                }

                return ans;
            

        }

        static void Main(string[] args)
        {
            _RemoveComments r = new();
            #region
            //{
            //    string[] strs = new string[] { "/*Test program */", "int main()", "{ ", "  // variable declaration ", "int a, b, c;", "/* This is a test", "   multiline  ", "   comment for ", "   testing */", "a = b + c;", "}" };
            //    var ret = r.RemoveComments(strs);
            //    foreach (string str in ret)
            //    {
            //        Console.WriteLine(str);
            //    }
            //}
            //{
            //    string[] strs = new string[] { "a/*comment", "line", "more_comment*/b" };
            //    var ret = r.RemoveComments(strs);
            //    foreach (string str in ret)
            //    {
            //        Console.WriteLine(str);
            //    }
            //}

            //{
            //    string[] strs = new string[] { "int /*dd*/n,cc;", "/**/", "int line;" };
            //    var ret = r.RemoveComments(strs);
            //    foreach (string str in ret)
            //    {
            //        Console.WriteLine(str);
            //    }
            //}
            //{
            //    string[] strs = new string[] { "class test{", "public: ", "   int x = 1;", "   /*double y = 1;*/", "   char c;", "};" };
            //    foreach (string str in strs)
            //    {
            //        Console.WriteLine(str);
            //    }
            //    Console.WriteLine("********************************************");
            //    var ret = r.RemoveComments(strs);

            //    foreach (string str in ret)
            //    {
            //        Console.WriteLine(str);
            //    }

            //    Console.WriteLine("********************************************");
            //    var rightAns = new string[] { "class test{", "public: ", "   int x = 1;", "   ", "   char c;", "};" };
            //    foreach (string str in rightAns)
            //    {
            //        Console.WriteLine(str);
            //    }

            //}

            //{
            //    string[] strs = new string[] { "class test{", "public: ", "   int x = 1;", "   /*double y = 1;*/", "   char c;", "};" };
            //    foreach (string str in strs)
            //    {
            //        Console.WriteLine(str);
            //    }
            //    Console.WriteLine("********************************************");
            //    var ret = r.RemoveComments(strs);

            //    foreach (string str in ret)
            //    {
            //        Console.WriteLine(str);
            //    }

            //    Console.WriteLine("********************************************");
            //    var rightAns = new string[] { "class test{", "public: ", "   int x = 1;", "   ", "   char c;", "};" };
            //    foreach (string str in rightAns)
            //    {
            //        Console.WriteLine(str);
            //    }

            //}
            #endregion

            {
                //string[] strs = new string[] { "struct Node{", "    /*/ declare members;/**/", "    int size;", "    /**/int val;", "};" };
                //var ret = r.RemoveComments(strs);
                //foreach (string str in ret)
                //{
                //    Console.WriteLine(str);
                //}
            }
            {
                string[] strs = { "void func(int k) {", "// this function does nothing /*", "   k = k*2/4;", "   k = k/2;*/", "}" };
                foreach (string str in strs)
                {
                    Console.WriteLine(str);
                }
                var ret = r.RemoveComments(strs);
                foreach (string str in ret)
                {
                    Console.WriteLine(str);
                }
                string[] result =  { "void func(int k) {", "   k = k*2/4;", "   k = k/2;*/", "}" };
                foreach (string str in result)
                {
                    Console.WriteLine(str);
                }
                //Compare(ret.ToArray(), result);


            }
        }

        static void Compare(string[] a, string[] b)
        {
            //Debug.Assert(a.Length == b.Length);
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    for (int j = 0; j < a[i].Length;++j)
                    {
                        if ( a[i][j] != b[i][j])
                        {
                            Console.WriteLine($"从{i}行第{j}处不同");
                            Console.Write(a[i][0..j]);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(a[i][j..]+"\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(b[i][0..j]);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(b[i][j..]+"\n");
                            break;
                        }
                    }
                }
               
            }
        }
    }
}
