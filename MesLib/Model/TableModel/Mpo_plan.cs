using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.TableModel
{
    [Serializable]
    public class Mpo_plan
    {
        public string id { set; get; }
        public DateTime? plan_date { set; get; }
        public decimal? plan_qty { set; get; }
    }
}
