using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{

    [Serializable]
    public class Bom_data
    {
        public Bom_data() { }
        public string id { set; get; }
        public string bom_no { set; get; }
        public string bom_column_name { set; get; }
        public string bom_column_value { set; get; }
    }
}
