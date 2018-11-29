using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 工厂视图类
    /// </summary>
    [Serializable]
    public class SysFactoryView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string factory_no { set; get; }
        public string factory_name { set; get; }
        public string factory_name_py { set; get; }
        public string factory_type { set; get; }
        public string company_no { set; get; }
        public string company_name { set; get; }
    }
}
