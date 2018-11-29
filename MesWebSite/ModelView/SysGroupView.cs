using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 集团视图类
    /// </summary>
    [Serializable]
    public class SysGroupView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string group_no { set; get; }
        public string group_name { set; get; }
    }
}
