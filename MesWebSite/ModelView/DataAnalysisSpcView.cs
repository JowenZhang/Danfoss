using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    //数据分析SPC视图
    public class DataAnalysisSpcView
    {
        public string dotTitle 
        { 
            set;
            get; 
        }
        public double yAxisMax 
        { 
            set;
            get; 
        }
        public double yAxisMin
        {
            set;
            get;
        }
        public List<int> dotxAxisData
        {
            set;
            get;
        }
        public List<double> dotyAxisData
        {
            set;
            get;
        }
        public double avarage
        { 
            set; 
            get; 
        }
        public double upLimit
        {
            set;
            get;
        }
        public double lowerLimit
        {
            set;
            get;
        }
        public double min
        {
            set;
            get;
        }
        public double max
        {
            set;
            get;
        }

        public double normal
        {
            set;
            get;
        }

        public List<double> spcxAxisData
        {
            set;
            get;
        }
        public List<int> spcyAxisCountData
        {
            set;
            get;
        }
        public List<double> spcyAxisCurveData
        {
            set;
            get;
        }

        public string tips
        {
            set;
            get;
        }

        public string spcTitle
        {
            set;
            get;
        }
    }
}
