using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// SPC设定视图类
    /// </summary>
    [Serializable]
    public class SysSpcSettingView
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
        public string spc_setting_no
        {
            set;
            get;
        }
        public string eqm_no
        {
            set;
            get;
        }
        public string spc_setting_name
        {
            set;
            get;
        }
    }
}
