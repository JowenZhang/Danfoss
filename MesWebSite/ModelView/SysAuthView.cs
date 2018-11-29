using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    [Serializable]
    public class SysAuthView
    {
        public string id { set; get; }
        public string auth_no { set; get; }
        public string auth_name { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string auth_group_no { set; get; }
        public string auth_group_name { set; get; }
        public string menu_no { set; get; }
    }
}
