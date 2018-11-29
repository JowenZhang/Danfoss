using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 质检评定结果视图
    /// </summary>
    [Serializable]
    public class QcmQaResultView
    {

        public string id
        {
            set;
            get;
        }
        public string status_no
        {
            set;
            get;
        }
        public string status_name
        {
            set;
            get;
        }
        public string result_no
        {
            set;
            get;
        }
        public string result_name
        {
            set;
            get;
        }
    }
}
