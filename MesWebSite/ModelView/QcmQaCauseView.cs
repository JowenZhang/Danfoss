using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 质量异常原因视图
    /// </summary>
    [Serializable]
    public class QcmQaCauseView
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
        public string qa_cause_no
        {
            set;
            get;
        }
        public string qa_cause_name
        {
            set;
            get;
        }
        public string qa_cause_py
        {
            set;
            get;
        }
        public string qa_cause_is_default
        {
            set;
            get;
        }
        public string factory_no
        {
            set;
            get;
        }
    }
}
