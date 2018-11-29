using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 内部类，基础的Spc信息
    /// </summary>
    internal class BasicSpcInfo
    {
        internal double SampleMax { set; get; }
        internal double SampleMin { set; get; }
        internal int SampleCount { set; get; }
        internal double Average { set; get; }
        internal double Wrange { set; get; }
        internal double StandardDeviation { set; get; }
        internal double Capability { set; get; }
        internal double Centernal { set; get; }
        internal int GroupQty { set; get; }
        internal double GroupDistance { set; get; }
        internal double GroupStartValue { set; get; }
        internal struct Boundary 
        {
           internal double Max;
           internal double Min;
        }
        internal string Capable { set; get; }

    }
}
