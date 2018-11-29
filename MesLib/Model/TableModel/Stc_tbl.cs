using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Stc_tbl
    {
        public string id { set; get; }
        public string table_name { set; get; }
        public string column_name { set; get; }
        public string display_name { set; get; }
        public string english_name { set; get; }
        public int column_width { set; get; }
        public int column_index { set; get; }
        public bool is_display { set; get; }
        public bool is_checkbok { set; get; }
        public int align { set; get; }
    }
}
