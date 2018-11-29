using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 公司视图类
    /// </summary>
    [Serializable]
    public class SysCompanyView
    {
        public string id{get;set;}
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string company_no { set; get; }
        public string company_name { set; get; }
        public string company_py { set; get; }
        public string company_type { set; get; }
        public string group_no { set; get; }
        public string group_name { set; get; }
    }
}
