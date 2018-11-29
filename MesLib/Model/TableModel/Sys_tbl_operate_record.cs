using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Sys_tbl_operate_record
    {
        public string id { get; set; }
        public string status_no { get; set; }
        public string status_name { get; set; }
        public string tbl_oprate_type { get; set; }
        public string tbl_name { get; set; }
        public DateTime? tbl_operate_time { get; set; }
    }
}
