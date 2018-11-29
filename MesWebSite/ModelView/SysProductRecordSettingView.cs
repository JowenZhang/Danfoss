using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 生产记录系统设定控制视图
    /// </summary>
    public class SysProductRecordSettingView
    {
        public string id { set; get; }
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
        public string product_record_no
        {
            set;
            get;
        }
        public string product_record_name
        {
            set;
            get;
        }
        public string eqm_no
        {
            set;
            get;
        }
        public string row_index
        {
            set;
            get;
        }
        public string col_index
        {
            set;
            get;
        }
    }
}
