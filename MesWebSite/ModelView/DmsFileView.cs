using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 文件视图
    /// </summary>
    [Serializable]
    public class DmsFileView
    {
        public string id
        {
            set;
            get;
        }
        public string file_no
        {
            set;
            get;
        }
        public string file_name
        {
            set;
            get;
        }
        public string file_extension
        {
            set;
            get;
        }
        public string file_type_no
        {
            set;
            get;
        }
        public string file_type_name
        {
            set;
            get;
        }
        public string file_version
        {
            set;
            get;
        }
        public string file_desc
        {
            set;
            get;
        }
        public string eqm_no
        {
            set;
            get;
        }
        public string file_md5
        {
            set;
            get;
        }
        public string is_passed
        {
            set;
            get;
        }
        public string file_status
        {
            set;
            get;
        }
        public string ralate_file_name
        {
            set;
            get;
        }
        public string valid_date_start
        {
            set;
            get;
        }
        public string valid_date_end
        {
            set;
            get;
        }
        public string file_info
        {
            get;
            set;
        }

        public string login_user_no
        {
            set;
            get;
        }
        public string login_user_name
        {
            set;
            get;
        }
    }
}
