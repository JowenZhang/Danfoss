using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 车间视图类
    /// </summary>
    [Serializable]
    public class PdmWorkshopView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string workshop_no { set; get; }
        public string workshop_name { set; get; }
        public string factory_no { set; get; }
        public string factory_name { set; get; }
    }
}
