using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Stc_bas
    {
        public string id { get; set; }
        public string field_name { get; set; }
        public string display_name { get; set; }
        public string english_name { get; set; }
        public int column_width { get; set; }
        public bool is_checkbox { get; set; }
        public int? align { get; set; }

    }
}
