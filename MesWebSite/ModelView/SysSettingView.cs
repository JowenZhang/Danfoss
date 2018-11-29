using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 系统设定视图类
    /// </summary>
    [Serializable]
    public class SysSettingView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string crt_time { set; get; }
        public string crt_user_no { set; get; }
        public string crt_user_name { set; get; }
        public string setting_no { set; get; }
        public string setting_name { set; get; }
        public string setting_display_name { set; get; }
        public string setting_value { set; get; }
    }
}
