using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Stc_tbl_eqm
    {
        public Stc_tbl_eqm() { }
        public string id { set; get; }
        public string function_name { set; get; }
        public string column_name { set; get; }
        public string eqm_no { set; get; }
        public string display_name { set; get; }
        public int column_width { set; get; }
        public int column_index { set; get; }
        public bool is_checkbox { set; get; }
        public int align { set; get; }
    }
    
}
