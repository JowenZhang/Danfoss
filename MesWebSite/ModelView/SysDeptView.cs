using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 部门视图类
    /// </summary>
    [Serializable]
    public class SysDeptView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string dept_no { set; get; }
        public string dept_name { set; get; }
        public string dept_name_py { set; get; }
        public string dept_type { set; get; }
        public string company_no { set; get; }
        public string company_name { set; get; }
    }
}
