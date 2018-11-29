using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Plm_pms_data
    {
        public Plm_pms_data() { }
        public string id { set; get; }
        public string plm_pms_no { set; get; }
        public string plm_pms_column_name { set; get; }
        public string plm_pms_column_value { set; get; }
    }
}
