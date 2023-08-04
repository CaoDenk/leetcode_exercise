using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _CountDigitOne
    {
        public int CountDigitOne(int n)
        {
            // mulk 表示 10^k
            // 在下面的代码中，可以发现 k 并没有被直接使用到（都是使用 10^k）
            // 但为了让代码看起来更加直观，这里保留了 k
            long mulk = 1;
            int ans = 0;
            for (int k = 0; n >= mulk; ++k)
            {
                ans += (int)(n / (mulk * 10) * mulk) + (int)Math.Min(Math.Max(n % (mulk * 10) - mulk + 1, 0), mulk);
                mulk *= 10;
            }
            return ans;
        }

        static void Main()
        {
            _CountDigitOne _CountDigitOne = new _CountDigitOne();
            Console.WriteLine(_CountDigitOne.CountDigitOne(824883294));

        }
    }
}
