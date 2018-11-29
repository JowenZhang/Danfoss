using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 数据IR分析结果视图
    /// </summary>
    public class DataAnalysisIRView
    {
        public string eqmIrTitle
        {
            set;
            get;
        }
        public string eqmIrxAxisName
        {
            set;
            get;
        }
        public string eqmIryAxisSingleName
        {
            set;
            get;
        }

        public string eqmIryAxisGainName
        {
            set;
            get;
        }

        public List<string> eqmxAxisValue
        {
            set;
            get;
        }

        public List<decimal> eqmyAxisSingleValue
        {
            set;
            get;
        }

        public List<decimal> eqmyAxisGainValue
        {
            set;
            get;
        }

        public string eqmIrBottomTitle
        {
            set;
            get;
        }

        public string dailyIrTitle
        {
            set;
            get;
        }
        public string dailyIrxAxisName
        {
            set;
            get;
        }
        public string dailyIryAxisName
        {
            set;
            get;
        }
        public List<string> dailyxAxisValue
        {
            set;
            get;
        }
        public List<decimal> dailyyAxisValue
        {
            set;
            get;
        }
    }
}
