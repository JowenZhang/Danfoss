using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 生产质量结果视图
    /// </summary>
    [Serializable]
    public class QcmQualityView
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
        public string quality_no
        {
            set;
            get;
        }
        public string quality_name
        {
            set;
            get;
        }
    }
}
