using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 停机原因视图
    /// </summary>
    [Serializable]
    public class EqmJamCauseView
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
        public string crt_user_no
        {
            set;
            get;
        }
        public string crt_user_name
        {
            set;
            get;
        }
        public string crt_time
        {
            set;
            get;
        }
        public string upd_user_no
        {
            set;
            get;
        }
        public string upd_user_name
        {
            set;
            get;
        }
        public string upd_time
        {
            set;
            get;
        }
        public string jam_cause_no
        {
            set;
            get;
        }
        public string jam_cause_name
        {
            set;
            get;
        }
        public string jam_cause_py
        {
            set;
            get;
        }
        public string jam_cause_type_no
        {
            set;
            get;
        }
        public string jam_cause_is_default
        {
            set; 
            get;
        }
    }
}
