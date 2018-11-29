using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 数据分析柱状图类
    /// </summary>
    public class DataAnalysisBarView
    {
        public string title_text
        {
            set;
            get;
        }
        public string xAxis_name
        { 
            set;
            get;
        }
        public string yAxis_name
        {
            set;
            get;
        }
        public List<string> xAxis_data
        {
            set;
            get;
        }
        public List<string> yAxis_data
        {
            set;
            get;
        }
        public int Count 
        { 
            set;
            get; 
        }
        public List<DataAnalysisValuePairView> Rows
        {
            set;
            get;
        }
    }
}
