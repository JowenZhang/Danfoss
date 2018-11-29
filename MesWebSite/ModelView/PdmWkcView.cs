using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 工作中心视图类
    /// </summary>
    [Serializable]
    public class PdmWkcView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string wkc_no { set; get; }
        public string wkc_name { set; get; }
        public string wkc_card_no { set; get; }
        public string wkc_type { set; get; }
        public string factory_no { set; get; }
        public string workshop_no { set; get; }
        public string line_no { set; get; }
    }
}
