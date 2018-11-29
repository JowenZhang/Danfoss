using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 生产线视图
    /// </summary>
    [Serializable]
    public class PdmLineView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string line_no { set; get; }
        public string line_name { set; get; }
        public string line_desc { set; get; }
        public string workshop_no { set; get; }
        public string workshop_name { set; get; }
    }
}
