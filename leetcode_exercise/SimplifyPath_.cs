using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 71. 简化路径
    /// 挖坑
    /// </summary>
    internal class SimplifyPath_
    {
        class Path
        {
            public Path(bool isHome) 
            {
                this.isHome = isHome;
            }
            bool isHome { get; set; } = false;
            Stack<string> path=new Stack<string>();
            Stack<string> Back()
            {
                if(path.Count>0)
                {
                    path.Pop();
                }
                return path;
            }
            public void Add(string dir)
            {
                if (dir == "..")
                    Back();
                else if (dir == ".")
                    return;
                else
                    path.Push(dir);
            }

            public override string ToString()
            {
                var list = path.Reverse();
                var p = string.Join("/", list);
                if (isHome)
                {
                    return $"/{p}";
                }
                else
                    return p;
            }
        }
        public string SimplifyPath(string path)
        {
            if (path.Length == 0)
                return "";
            Path p= new Path(path[0]=='/');
            var list = path.Split('/');
            foreach (var item in list)
            {
                if (item.Length == 0)
                    continue;
                p.Add(item);
            }

            return p.ToString();
        }
    }
}
