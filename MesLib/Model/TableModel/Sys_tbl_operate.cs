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
    public class Sys_tbl_operate
    {
        public string id { get; set; }
        public string status_no { get; set; }
        public string status_name { get; set; }
        public string tbl_operate_no { get; set; }
        public string tbl_operate_type { get; set; }
        public string tbl_operate_table_name { get; set; }
        public string tbl_operate_table_key { get; set; }
    }
}
