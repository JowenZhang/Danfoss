using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelView
{
    /// <summary>
    /// 子生产订单视图
    /// </summary>
    [Serializable]
    public class MpoItemView
    {
        public string id
        {
            set;
            get;
        }
        public string status_no
        {
            set;
            get;
        }
        public string status_name
        {
            set;
            get;
        }
        public string mpo_no
        {
            set;
            get;
        }
        public string item_no
        {
            set;
            get;
        }
        public string serial_no
        {
            set;
            get;
        }
        public string item_qty
        {
            set;
            get;
        }
        public string part_no
        {
            set;
            get;
        }
        public string hope_product_time
        {
            set;
            get;
        }
        public string print_time
        {
            set;
            get;
        }
    }
}
