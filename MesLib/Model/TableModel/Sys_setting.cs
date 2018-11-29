using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    /// <summary>
    /// 系统设定类
    /// </summary>
    [Serializable]
    public class Sys_setting
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public DateTime crt_time { set; get; }
        public string crt_user_no { set; get; }
        public string crt_user_name { set; get; }
        public string setting_no { set; get; }
        public string setting_name { set; get; }
        public string setting_display_name { set; get; }
        public string setting_value { set; get; }
    }
}
