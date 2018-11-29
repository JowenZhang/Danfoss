using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 设备视图
    /// </summary>
    [Serializable]
    public class PdmEqmView
    {
        public string id { set; get; }
        public string status_no { set; get; }
        public string status_name { set; get; }
        public string eqm_no { set; get; }
        public string eqm_name { set; get; }
        public string eqm_desc { set; get; }
        public string eqm_index { set; get; }
        public string wkc_no { set; get; }
        public string eqm_status { set; get; }
        public string eqm_lock { set; get; }
    }
}
