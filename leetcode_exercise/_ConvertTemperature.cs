using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _ConvertTemperature
    {
        public double[] ConvertTemperature(double celsius)
        {
            return new double[] {celsius+273.15d,celsius*1.80d+32d };
        }
    }
}
