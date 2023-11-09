using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 201. 数字范围按位与
    /// </summary>
    internal class RangeBitwiseAnd_
    {
        /// <summary>
        /// 相当与获取公告前缀长
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int RangeBitwiseAnd(int left, int right)
        {
            while (left < right)
            {
                right &= right - 1;
            }
            return right;
        }
    }
}
